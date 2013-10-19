%%{
	machine OrderByParser;

	action beginPathToken {
		buffer.BeginBuffer(fpc);
		buffer.SetTokenType(TokenType.PropertyOrField);
		Log("path");
	}

	action beginDirectionToken {
		buffer.BeginBuffer(fpc);
		buffer.SetTokenType(TokenType.Literal);
		Log("dir");
	}

	action parseToken {
		buffer.Append(fc);
		Log(fc);
	}

	action endPathToken{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(fpc));
		Log("end path");
	}

	action raisePathToMethod{
		buffer.SetTokenType(TokenType.Method);
		Log("switch method");
	}

	action endDirectionToken{
		directionTokenBuffer=buffer.EndBuffer(fpc);
		Log("end dir");
	}

	action beginPathExpression {
		directionTokenBuffer=null;
		pathTokenBuffer=new Queue<Token>();
		Log("begin path exp");
	}

	action endPathExpression {
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("end path exp");
	}

	action generalError	{
		errSyntex=buffer.Current();
		errSyntex=data.Substring(buffer.StartOffset,te-buffer.StartOffset);
		throw new SyntexException(te,"语法错误。位于列{0}, {1}附近",te,errSyntex);
	}


	methodToken='()' >raisePathToMethod;

	propertyToken='.'^(space|/[\.\,\(\)]/)+  
					>beginPathToken 
					$parseToken 
					methodToken?
					%endPathToken ;
	property = /it/i propertyToken+ 
					>beginPathExpression; 

	direction= (/asc/i|/desc/i) 
					>beginDirectionToken 
					$parseToken 
					%endDirectionToken;

	expression =space* property (space+ direction? space*)* 
					%endPathExpression;

	expressionSep=space* ',' space*;

	main:=|*
		expression;
		expressionSep ;
		any=>generalError;
	*|;

}%%

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
	public class OrderByTokenParser{

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
	        string errSyntex;
	        %%write init;

	        %%write exec;

	        return tokenCollection;
	    }

	    [System.Diagnostics.Conditional("DEBUG")]
        public void Log(object msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }
	}
}