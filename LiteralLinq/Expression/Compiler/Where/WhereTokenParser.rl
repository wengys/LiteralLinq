%%{
	machine TestParser;

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
	//	directionTokenBuffer=null;
	//	pathTokenBuffer=new Queue<Token>();
		temp=new Queue<Token>();
		Log("Begin path expression");
	}

	action endPathExpression {
		stackB.Push(WhereToken.Create(temp,WhereTokenType.MemberAccess));
		Log("End path expression");
	}

	action beginLiteral
	{
		Log("Begin literal token");
	}

	action endLiteral
	{
		Log("End literal token");
	}

	action beginSubExpression
	{
		Log("Begin sub expression");
	}

	action endSubExpression
	{
		Log("End sub expression");
	}

	action beginArray
	{
		Log("Begin array");
	}

	action endArray
	{
		Log("End array");
	}

	action beginOperator
	{
		Log("Begin operator");
	}

	action endOperator
	{
		Log("end operator");
	}

	action beginFormatter
	{
		Log("Begin operator");
	}

	action endFormatter
	{
		Log("End operator");
	}

	action readNull
	{
		Log("Read null");
	}

	action generalError	{
		errSyntax=buffer.Current();
		errSyntax=data.Substring(buffer.StartOffset,te-buffer.StartOffset);
		throw new SyntaxException(te,"Syntax error. Offset:{0}, near \"{1}\"",te,errSyntax);
	}

	leftBracket='[';
	rightBracket=']';
	leftParenthesis='(';
	rightParenthesis=')';
	
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

	nullValue=/null/i % readNull;

	formatter=space*'@' >beginFormatter space*literalToken %endFormatter;

	value=(literalToken formatter?)|nullValue;

	array=leftBracket > beginArray (space* literalToken space* ','?)* rightBracket >endArray formatter?;

	operator='<' >beginOperator (ascii-/[<>]/)+ $readChar '>' >endOperator;

	subExpression=leftParenthesis? >beginSubExpression pathExpression space* operator space* (value|array) rightParenthesis? %endSubExpression;

	main:=|*
		subExpression (space* operator space*  subExpression)*;
		space;
		',';
		#any=>generalError;
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

       		string data=expression;
       	    int p=0,pe=data.Length,cs=0,eof=data.Length,ts=0,te=0,act=0;
        	%%write init;
        	%%write exec;
        	return stackB;
       } 

        [System.Diagnostics.Conditional("DEBUG")]
	    public void Log(object msg)
	    {
	    	System.Diagnostics.Debug.WriteLine(msg);
	    }
    }
}