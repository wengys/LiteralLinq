
/* #line 1 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
﻿
/* #line 88 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
	public class OrderByTokenParser{

		
/* #line 13 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.cs" */
static readonly sbyte[] _OrderByParser_to_state_actions =  new sbyte [] {
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 8, 0, 0, 0, 0, 0
};

static readonly sbyte[] _OrderByParser_from_state_actions =  new sbyte [] {
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 9, 0, 0, 0, 0, 0
};

const int OrderByParser_start = 10;
const int OrderByParser_first_final = 10;
const int OrderByParser_error = 0;

const int OrderByParser_en_main = 10;


/* #line 100 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */

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
	        
/* #line 40 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.cs" */
	{
	cs = OrderByParser_start;
	ts = -1;
	te = -1;
	act = 0;
	}

/* #line 112 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */

	        
/* #line 47 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.cs" */
	{
	if ( p == pe )
		goto _test_eof;
	if ( cs == 0 )
		goto _out;
_resume:
	switch ( _OrderByParser_from_state_actions[cs] ) {
	case 9:
/* #line 1 "NONE" */
	{ts = p;}
	break;
/* #line 57 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.cs" */
		default: break;
	}

	switch ( cs ) {
case 10:
	switch( data[p] ) {
		case '\u0020': goto tr12;
		case '\u0049': goto tr13;
		case '\u0069': goto tr13;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr12;
	goto tr1;
case 0:
	goto _out;
case 11:
	if ( data[p] == 32u )
		goto tr12;
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr12;
	goto tr14;
case 1:
	switch( data[p] ) {
		case '\u0054': goto tr0;
		case '\u0074': goto tr0;
		default: break;
	}
	goto tr1;
case 12:
	switch( data[p] ) {
		case '\u0020': goto tr16;
		case '\u002c': goto tr17;
		case '\u002e': goto tr18;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr16;
	goto tr15;
case 2:
	switch( data[p] ) {
		case '\u0020': goto tr3;
		case '\u0041': goto tr4;
		case '\u0044': goto tr5;
		case '\u0061': goto tr4;
		case '\u0064': goto tr5;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr3;
	goto tr2;
case 3:
	switch( data[p] ) {
		case '\u0053': goto tr6;
		case '\u0073': goto tr6;
		default: break;
	}
	goto tr2;
case 4:
	switch( data[p] ) {
		case '\u0043': goto tr7;
		case '\u0063': goto tr7;
		default: break;
	}
	goto tr2;
case 13:
	if ( data[p] == 44u )
		goto tr20;
	goto tr19;
case 5:
	switch( data[p] ) {
		case '\u0049': goto tr8;
		case '\u0069': goto tr8;
		default: break;
	}
	goto tr2;
case 6:
	switch( data[p] ) {
		case '\u0054': goto tr0;
		case '\u0074': goto tr0;
		default: break;
	}
	goto tr2;
case 7:
	switch( data[p] ) {
		case '\u0045': goto tr9;
		case '\u0065': goto tr9;
		default: break;
	}
	goto tr2;
case 8:
	switch( data[p] ) {
		case '\u0020': goto tr2;
		case '\u002c': goto tr2;
		case '\u002e': goto tr2;
		default: break;
	}
	if ( data[p] > 13u ) {
		if ( 40u <= data[p] && data[p] <= 41u )
			goto tr2;
	} else if ( data[p] >= 9u )
		goto tr2;
	goto tr10;
case 14:
	switch( data[p] ) {
		case '\u0020': goto tr23;
		case '\u0028': goto tr24;
		case '\u0029': goto tr21;
		case '\u002c': goto tr25;
		case '\u002e': goto tr26;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr23;
	goto tr22;
case 9:
	if ( data[p] == 41u )
		goto tr11;
	goto tr2;
case 15:
	switch( data[p] ) {
		case '\u0020': goto tr23;
		case '\u002c': goto tr25;
		case '\u002e': goto tr26;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr23;
	goto tr21;
		default: break;
	}

	tr1: cs = 0; goto _again;
	tr13: cs = 1; goto _again;
	tr3: cs = 2; goto _again;
	tr16: cs = 2; goto f11;
	tr23: cs = 2; goto f17;
	tr4: cs = 3; goto f2;
	tr9: cs = 3; goto f3;
	tr6: cs = 4; goto f3;
	tr17: cs = 5; goto f12;
	tr20: cs = 5; goto f15;
	tr25: cs = 5; goto f18;
	tr8: cs = 6; goto _again;
	tr5: cs = 7; goto f2;
	tr18: cs = 8; goto f13;
	tr26: cs = 8; goto f19;
	tr24: cs = 9; goto _again;
	tr2: cs = 10; goto f1;
	tr14: cs = 10; goto f9;
	tr15: cs = 10; goto f10;
	tr19: cs = 10; goto f14;
	tr21: cs = 10; goto f16;
	tr12: cs = 11; goto _again;
	tr0: cs = 12; goto f0;
	tr7: cs = 13; goto f4;
	tr22: cs = 14; goto f4;
	tr10: cs = 14; goto f5;
	tr11: cs = 15; goto f6;

f13:
/* #line 4 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
	goto _again;
f3:
/* #line 24 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f17:
/* #line 29 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
	goto _again;
f9:
/* #line 85 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p;p--;}
	goto _again;
f1:
/* #line 84 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{{p = ((te))-1;}}
	goto _again;
f19:
/* #line 29 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 4 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
	goto _again;
f18:
/* #line 29 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 45 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}
	goto _again;
f15:
/* #line 34 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		directionTokenBuffer=buffer.EndBuffer(p);
		Log("End direction token");
	}
/* #line 45 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}
	goto _again;
f6:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 14 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.Method);
		Log("Recognise token method");
	}
	goto _again;
f4:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 24 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f0:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 39 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		directionTokenBuffer=null;
		pathTokenBuffer=new Queue<Token>();
		Log("Begin path expression");
	}
	goto _again;
f11:
/* #line 4 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
/* #line 9 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.PropertyOrField);
		Log("Recognise token property");
	}
/* #line 29 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
	goto _again;
f2:
/* #line 4 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
/* #line 19 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.Literal);
		Log("Recognise Token direction");
	}
/* #line 24 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f16:
/* #line 29 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 45 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}
/* #line 84 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p;p--;}
	goto _again;
f14:
/* #line 34 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		directionTokenBuffer=buffer.EndBuffer(p);
		Log("End direction token");
	}
/* #line 45 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}
/* #line 84 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p;p--;}
	goto _again;
f5:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 9 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.PropertyOrField);
		Log("Recognise token property");
	}
/* #line 24 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f12:
/* #line 4 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
/* #line 9 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.PropertyOrField);
		Log("Recognise token property");
	}
/* #line 29 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 45 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}
	goto _again;
f10:
/* #line 4 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
/* #line 9 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.PropertyOrField);
		Log("Recognise token property");
	}
/* #line 29 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 45 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{
		tokenCollection.Append(pathTokenBuffer,directionTokenBuffer??new Token("ASC",TokenType.Literal,-1,-1));
		Log("End path expression");
	}
/* #line 84 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */
	{te = p;p--;}
	goto _again;

_again:
	switch ( _OrderByParser_to_state_actions[cs] ) {
	case 8:
/* #line 1 "NONE" */
	{ts = -1;}
	break;
/* #line 397 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.cs" */
		default: break;
	}

	if ( cs == 0 )
		goto _out;
	if ( ++p != pe )
		goto _resume;
	_test_eof: {}
	if ( p == eof )
	{
	switch ( cs ) {
	case 11: goto tr14;
	case 12: goto tr15;
	case 2: goto tr2;
	case 3: goto tr2;
	case 4: goto tr2;
	case 13: goto tr19;
	case 5: goto tr2;
	case 6: goto tr2;
	case 7: goto tr2;
	case 8: goto tr2;
	case 14: goto tr21;
	case 9: goto tr2;
	case 15: goto tr21;
		default: break;
	}
	}

	_out: {}
	}

/* #line 114 "D:/workplace/test/LiteralLinq/LiteralLinq/Expression/Compiler/OrderBy/OrderByTokenParser.rl" */

	        return tokenCollection;
	    }

	    public void Log(object msg)
	    {
	    	System.Diagnostics.Debug.WriteLine(msg);
	    }
	}
}