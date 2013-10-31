%%{
	machine WhereParser;

	action beginToken {
		buffer.BeginBuffer(fpc);
		Log("Begin token");
	}

	action recogniseTokenProperty{
		buffer.SetTokenType(TokenType.PropertyOrField);
		Log("Recognise token property");
	}

	action recogniseTokenMethod{
		buffer.SetTokenType(TokenType.Method);
		Log("Recognise token method");
	}

	action readChar{
		buffer.Append(fc);
		Log(fc);
	}

	action endPathToken{
		temp.Enqueue(buffer.EndBuffer(fpc));
		Log("End path token");
	}

	action beginPathExpression {
		temp=new Queue<Token>();
		Log("Begin path expression");
	}

	action endPathExpression {
		if(temp.Count==0)
		{
			buffer.BeginBuffer(fpc);
			buffer.SetTokenType(TokenType.PropertyOrField);
			temp.Enqueue(buffer.EndBuffer(fpc));
		}
		stackB.Push(WhereToken.Create(temp,WhereTokenType.MemberAccess));
		Log("End path expression");
	}

	action beginLiteral
	{
		buffer.BeginBuffer(fpc);
		buffer.SetTokenType(TokenType.Literal);
		Log("Begin literal token");
	}

	action endLiteral
	{
		var curToken=buffer.EndBuffer(fpc);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}

	action beginValue
	{
		temp=new Queue<Token>();
		Log("Begin value");
	}

	action endValue
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Value));
		Log("End value");
	}

	action readNull
	{
		buffer.BeginBuffer(fpc-4);
		buffer.SetTokenType(TokenType.Null);
		temp.Enqueue(buffer.EndBuffer(fpc));
		Log("Read null");
	}

	action beginFormatter
	{
		temp=new Queue<Token>();
		Log("Begin formatter");
	}

	action endFormatter
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Formatter));
		Log("End formatter");
	}

	action beginArray
	{
		temp=new Queue<Token>();
		Log("Begin array");
	}

	action endArray
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.ValueArray));
		Log("End array");
	}

	action beginOperator
	{
		buffer.BeginBuffer(fpc);
		buffer.SetTokenType(TokenType.Literal);
		temp=new Queue<Token>();
		Log("Begin operator");
	}

	action endOperator
	{
		var curOperToken=buffer.EndBuffer(fpc);
		var curOperPriority=WhereOperatorTable.GetOperatorPriority(curOperToken.TokenText);
		while(stackA.Count>0 && stackA.Peek().Priority<curOperPriority)
		{
			stackB.Push(stackA.Pop());
		}
		temp.Enqueue(curOperToken);
		stackA.Push(WhereToken.Create(temp,WhereTokenType.Operator,curOperPriority));
		Log("End operator");
	}

	action readLeftParenthesis
	{
		buffer.BeginBuffer(fpc);
		buffer.SetTokenType(TokenType.Literal);
		buffer.Append('(');
		var curOperToken=buffer.EndBuffer(fpc);
		var curOperPriority=WhereOperatorTable.GetOperatorPriority(curOperToken.TokenText);
		temp=new Queue<Token>();
		temp.Enqueue(curOperToken);
		stackA.Push(WhereToken.Create(temp,WhereTokenType.LeftParenthesis,curOperPriority));
		Log("(");
	}

	action readRightParenthesis
	{
		while(stackA.Peek().Type!=WhereTokenType.LeftParenthesis)
		{
			stackB.Push(stackA.Pop());
			if(stackA.Count==0)
			{
        		throw new SyntaxException(te,"Redundant parenthesis. Offset:{0}, near \"{1}\"",ts,")");
			}
		}
		stackA.Pop();
		Log(")");
	}

	action beginSubExpression
	{
		Log(fpc.ToString());
		Log("Begin sub expression");
	}

	action endSubExpression
	{
		Log(fpc.ToString());
		Log("End sub expression");
	}

	action generalError	{
		errSyntax=buffer.Current();
        errSyntax = data.Substring(buffer.StartOffset, te < buffer.StartOffset ? buffer.EndOffset  - buffer.StartOffset: te - buffer.StartOffset);
		throw new SyntaxException(te,"Syntax error. Offset:{0}, near \"{1}\"",buffer.StartOffset,errSyntax);
	}

	leftBracket='[';
	rightBracket=']';
	leftParenthesis='(' > readLeftParenthesis;
	rightParenthesis=')' > readRightParenthesis;
	
	propertyToken='.'
					>beginToken
				  ^(space|/[\.\,\(\)<>]/)+  
					>recogniseTokenProperty
					$readChar 
					%endPathToken ;

	methodToken='.' 
					>beginToken 
				^(space|/[\.\,\(\)<>]/)+
					$readChar
				'()' 
					>recogniseTokenMethod
					%endPathToken;

	pathExpression =/it/i 
					@beginPathExpression
					(propertyToken|methodToken)* zlen
					%endPathExpression;

	literalToken='\''
				>beginLiteral 
			(any-'\''|'\\\'')* 
				$readChar 
			zlen'\''
				%endLiteral;

	nullValue=/null/i %readNull;

	formatter=space*'@' >beginFormatter space*literalToken %endFormatter;

	value=((literalToken >beginValue %endValue formatter?)|(nullValue >beginValue %endValue)) ;

	array=leftBracket > beginArray (space* (literalToken|nullValue) space* ','?)* rightBracket >endArray formatter?;

	operator='<' >beginOperator (ascii-/[<>]/)+ $readChar '>' >endOperator;

	subExpression= pathExpression >beginSubExpression space* operator space* (value|array)  %endSubExpression;

	main:=|*
		subExpression;
		space;
		operator;
		leftParenthesis;
		rightParenthesis;
		any=>generalError;
		*|;
}%%

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler.Where
{
    public class WhereTokenParser
    {
       %%write data;
       public IEnumerable<WhereToken> Parse(string expression)
       {
       		TokenParseBuffer buffer = new TokenParseBuffer();
       		
       		Stack<WhereToken> stackA=new Stack<WhereToken>();
       		Stack<WhereToken> stackB=new Stack<WhereToken>();

       		Queue<Token> temp=null;
       		string errSyntax;
       		string data=expression;
       	    int p=0,pe=data.Length,cs=0,eof=data.Length,ts=0,te=0,act=0;
        	%%write init;
        	%%write exec;

        	while(stackA.Count>0)
        	{
        		var curOper=stackA.Pop();
        		if(curOper.Type==WhereTokenType.LeftParenthesis)
        		{
        			var errToken=curOper.Tokens.Peek();
        			throw new SyntaxException(te,"Redundant parenthesis. Offset:{0}, near \"{1}\"",errToken.StartOffset,errToken.TokenText);
        		}
        		stackB.Push(curOper);
        	}

        	return stackB.Reverse();
       } 

        [System.Diagnostics.Conditional("DEBUG")]
	    private void Log(object msg)
	    {
	    	System.Diagnostics.Debug.WriteLine(msg);
	    }
    }
}