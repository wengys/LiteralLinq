
/* #line 1 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
﻿
/* #line 97 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
	public class OrderByTokenParser{

		
/* #line 13 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.cs" */
static readonly sbyte[] _OrderByParser_to_state_actions =  new sbyte [] {
	0, 0, 0, 0, 0, 5, 0, 0, 
	0, 0, 0, 0
};

static readonly sbyte[] _OrderByParser_from_state_actions =  new sbyte [] {
	0, 0, 0, 0, 0, 6, 0, 0, 
	0, 0, 0, 0
};

const int OrderByParser_start = 5;
const int OrderByParser_first_final = 5;
const int OrderByParser_error = -1;

const int OrderByParser_en_main = 5;


/* #line 109 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */

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
	        
/* #line 40 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.cs" */
	{
	cs = OrderByParser_start;
	ts = -1;
	te = -1;
	act = 0;
	}

/* #line 121 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */

	        
/* #line 47 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.cs" */
	{
	if ( p == pe )
		goto _test_eof;
_resume:
	switch ( _OrderByParser_from_state_actions[cs] ) {
	case 6:
/* #line 1 "NONE" */
	{ts = p;}
	break;
/* #line 55 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.cs" */
		default: break;
	}

	switch ( cs ) {
case 5:
	switch( data[p] ) {
		case '\u0020': goto tr7;
		case '\u002c': goto tr8;
		case '\u0049': goto tr9;
		case '\u0069': goto tr9;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr7;
	goto tr6;
case 6:
	switch( data[p] ) {
		case '\u0054': goto tr11;
		case '\u0074': goto tr11;
		default: break;
	}
	goto tr10;
case 7:
	switch( data[p] ) {
		case '\u0020': goto tr13;
		case '\u002e': goto tr14;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr13;
	goto tr12;
case 8:
	switch( data[p] ) {
		case '\u0020': goto tr16;
		case '\u0041': goto tr17;
		case '\u0044': goto tr18;
		case '\u0061': goto tr17;
		case '\u0064': goto tr18;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr16;
	goto tr15;
case 0:
	switch( data[p] ) {
		case '\u0053': goto tr1;
		case '\u0073': goto tr1;
		default: break;
	}
	goto tr0;
case 1:
	switch( data[p] ) {
		case '\u0043': goto tr2;
		case '\u0063': goto tr2;
		default: break;
	}
	goto tr0;
case 9:
	goto tr19;
case 2:
	switch( data[p] ) {
		case '\u0045': goto tr3;
		case '\u0065': goto tr3;
		default: break;
	}
	goto tr0;
case 3:
	switch( data[p] ) {
		case '\u0020': goto tr0;
		case '\u002c': goto tr0;
		case '\u002e': goto tr0;
		default: break;
	}
	if ( data[p] > 13u ) {
		if ( 40u <= data[p] && data[p] <= 41u )
			goto tr0;
	} else if ( data[p] >= 9u )
		goto tr0;
	goto tr4;
case 10:
	switch( data[p] ) {
		case '\u0020': goto tr22;
		case '\u0028': goto tr23;
		case '\u0029': goto tr20;
		case '\u002c': goto tr20;
		case '\u002e': goto tr24;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr22;
	goto tr21;
case 4:
	if ( data[p] == 41u )
		goto tr5;
	goto tr0;
case 11:
	switch( data[p] ) {
		case '\u0020': goto tr22;
		case '\u002e': goto tr24;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr22;
	goto tr20;
		default: break;
	}

	tr3: cs = 0; goto f1;
	tr17: cs = 0; goto f16;
	tr1: cs = 1; goto f1;
	tr18: cs = 2; goto f16;
	tr14: cs = 3; goto f13;
	tr24: cs = 3; goto f21;
	tr23: cs = 4; goto _again;
	tr0: cs = 5; goto f0;
	tr6: cs = 5; goto f6;
	tr7: cs = 5; goto f7;
	tr8: cs = 5; goto f8;
	tr10: cs = 5; goto f9;
	tr12: cs = 5; goto f11;
	tr15: cs = 5; goto f14;
	tr19: cs = 5; goto f17;
	tr20: cs = 5; goto f18;
	tr9: cs = 6; goto _again;
	tr11: cs = 7; goto f10;
	tr13: cs = 8; goto f12;
	tr16: cs = 8; goto f15;
	tr22: cs = 8; goto f20;
	tr2: cs = 9; goto f1;
	tr4: cs = 10; goto f2;
	tr21: cs = 10; goto f19;
	tr5: cs = 11; goto f3;

f13:
/* #line 4 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
	goto _again;
f1:
/* #line 24 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f15:
/* #line 1 "NONE" */
	{te = p+1;}
	goto _again;
f7:
/* #line 92 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p+1;}
	goto _again;
f8:
/* #line 93 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p+1;}
	goto _again;
f6:
/* #line 50 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p+1;{
		errSyntax=buffer.Current();
		errSyntax=data.Substring(buffer.StartOffset,te-buffer.StartOffset);
		throw new SyntaxException(te,"Syntax error. Offset:{0}, near \"{1}\"",te,errSyntax);
	}}
	goto _again;
f9:
/* #line 50 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p;p--;{
		errSyntax=buffer.Current();
		errSyntax=data.Substring(buffer.StartOffset,te-buffer.StartOffset);
		throw new SyntaxException(te,"Syntax error. Offset:{0}, near \"{1}\"",te,errSyntax);
	}}
	goto _again;
f0:
/* #line 91 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{{p = ((te))-1;}}
	goto _again;
f21:
/* #line 29 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 4 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
	goto _again;
f14:
/* #line 45 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}
/* #line 91 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p;p--;}
	goto _again;
f3:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 14 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.Method);
		Log("Recognise token method");
	}
	goto _again;
f19:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 24 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f20:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 29 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
	goto _again;
f10:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 39 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		directionTokenBuffer=null;
		pathTokenBuffer=new Queue<Token>();
		Log("Begin path expression");
	}
	goto _again;
f16:
/* #line 4 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
/* #line 19 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.Literal);
		Log("Recognise Token direction");
	}
/* #line 24 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f18:
/* #line 29 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 45 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}
/* #line 91 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p;p--;}
	goto _again;
f17:
/* #line 34 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		directionTokenBuffer=buffer.EndBuffer(p);
		Log("End direction token");
	}
/* #line 45 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}
/* #line 91 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p;p--;}
	goto _again;
f2:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 9 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.PropertyOrField);
		Log("Recognise token property");
	}
/* #line 24 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f12:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 4 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
/* #line 9 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.PropertyOrField);
		Log("Recognise token property");
	}
/* #line 29 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
	goto _again;
f11:
/* #line 4 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
/* #line 9 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.PropertyOrField);
		Log("Recognise token property");
	}
/* #line 29 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 45 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}
/* #line 91 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p;p--;}
	goto _again;

_again:
	switch ( _OrderByParser_to_state_actions[cs] ) {
	case 5:
/* #line 1 "NONE" */
	{ts = -1;}
	break;
/* #line 359 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.cs" */
		default: break;
	}

	if ( ++p != pe )
		goto _resume;
	_test_eof: {}
	if ( p == eof )
	{
	switch ( cs ) {
	case 6: goto tr10;
	case 7: goto tr12;
	case 8: goto tr15;
	case 0: goto tr0;
	case 1: goto tr0;
	case 9: goto tr19;
	case 2: goto tr0;
	case 3: goto tr0;
	case 10: goto tr20;
	case 4: goto tr0;
	case 11: goto tr20;
		default: break;
	}
	}

	}

/* #line 123 "C:/Users/Administrator/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */

	        return tokenCollection;
	    }

	    [System.Diagnostics.Conditional("DEBUG")]
	    private void Log(object msg)
	    {
	    	System.Diagnostics.Debug.WriteLine(msg);
	    }
	}
}