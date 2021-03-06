﻿%%{
	machine OrderByParser;

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

	action recogniseTokenDirection {
		buffer.SetTokenType(TokenType.Literal);
		Log("Recognise Token direction");
	}

	action readChar{
		buffer.Append(fc);
		Log(fc);
	}

	action endPathToken{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(fpc));
		Log("End path token");
	}

	action endDirectionToken{
		directionTokenBuffer=buffer.EndBuffer(fpc);
		Log("End direction token");
	}

	action beginPathExpression {
		directionTokenBuffer=null;
		pathTokenBuffer=new Queue<Token>();
		Log("Begin path expression");
	}

	action endPathExpression {
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}

	action generalError	{
		errSyntax=buffer.Current();
		errSyntax=data.Substring(buffer.StartOffset,te-buffer.StartOffset);
		throw new SyntaxException(te,"Syntax error. Offset:{0}, near \"{1}\"",te,errSyntax);
	}

	leftParenthesis='(';

	rightParenthesis=')';

	propertyToken='.'
					>beginToken
				  ^(space|/[\.\,\(\)]/)+  
					>recogniseTokenProperty
					$readChar 
					%endPathToken ;

	methodToken='.' 
					>beginToken 
				^(space|/[\.\,\(\)]/)+
					$readChar
				leftParenthesis rightParenthesis 
					>recogniseTokenMethod
					%endPathToken;

	selfToken=zlen 
					>beginToken >recogniseTokenProperty
					>endPathToken;

	directionToken= (/asc/i|/desc/i) 
					>beginToken 
					>recogniseTokenDirection
					$readChar 
					%endDirectionToken;

	pathExpression =/it/i 
					@beginPathExpression
					((propertyToken|methodToken)*|selfToken) space* (space+ directionToken)?
					%endPathExpression;

	main:=|*
		pathExpression;
		space;
		',';
		any=>generalError;
		*|;

}%%

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
	internal class OrderByTokenParser{

		%%write data;

	    public OrderByTokenCollection Parse(string expression)
	    {
	        TokenParseBuffer buffer = new TokenParseBuffer();
	        Queue<Token> pathTokenBuffer=null;
	        Token? directionTokenBuffer=null;
	        OrderByTokenCollection tokenCollection = new OrderByTokenCollection();
	        var data = expression;
	        int p = 0, pe = data.Length, cs,eof=data.Length;
	        int ts,te,act;
	        string errSyntax;
	        %%write init;

	        %%write exec;

	        return tokenCollection;
	    }

	    [System.Diagnostics.Conditional("DEBUG")]
	    private void Log(object msg)
	    {
	    	System.Diagnostics.Debug.WriteLine(msg);
	    }
	}
}