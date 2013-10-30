
/* #line 1 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
﻿
/* #line 222 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler.Where
{
    public class WhereTokenParser
    {
       
/* #line 13 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.cs" */
static readonly byte[] _WhereParser_to_state_actions =  new byte [] {
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 47, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0
};

static readonly byte[] _WhereParser_from_state_actions =  new byte [] {
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 48, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0
};

const int WhereParser_start = 51;
const int WhereParser_first_final = 51;
const int WhereParser_error = -1;

const int WhereParser_en_main = 51;


/* #line 234 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
       public IEnumerable<WhereToken> Parse(string expression)
       {
       		TokenParseBuffer buffer = new TokenParseBuffer();
       		
       		Stack<WhereToken> stackA=new Stack<WhereToken>();
       		Stack<WhereToken> stackB=new Stack<WhereToken>();

       		Queue<Token> temp=null;
       		string errSyntax;
       		string data=expression;
       	    int p=0,pe=data.Length,cs=0,eof=data.Length,ts=0,te=0,act=0;
        	
/* #line 52 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.cs" */
	{
	cs = WhereParser_start;
	ts = -1;
	te = -1;
	act = 0;
	}

/* #line 246 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
        	
/* #line 58 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.cs" */
	{
	if ( p == pe )
		goto _test_eof;
_resume:
	switch ( _WhereParser_from_state_actions[cs] ) {
	case 48:
/* #line 1 "NONE" */
	{ts = p;}
	break;
/* #line 66 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.cs" */
		default: break;
	}

	switch ( cs ) {
case 51:
	switch( data[p] ) {
		case '\u0020': goto tr112;
		case '\u0028': goto tr113;
		case '\u0029': goto tr114;
		case '\u003c': goto tr115;
		case '\u0049': goto tr116;
		case '\u0069': goto tr116;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr112;
	goto tr111;
case 52:
	if ( data[p] == 61u )
		goto tr1;
	if ( data[p] > 59u ) {
		if ( 63u <= data[p] && data[p] <= 127u )
			goto tr1;
	} else
		goto tr1;
	goto tr117;
case 0:
	if ( data[p] == 62u )
		goto tr2;
	if ( data[p] > 59u ) {
		if ( 61u <= data[p] && data[p] <= 127u )
			goto tr1;
	} else
		goto tr1;
	goto tr0;
case 53:
	switch( data[p] ) {
		case '\u0054': goto tr118;
		case '\u0074': goto tr118;
		default: break;
	}
	goto tr117;
case 1:
	switch( data[p] ) {
		case '\u0020': goto tr3;
		case '\u002e': goto tr4;
		case '\u003c': goto tr5;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr3;
	goto tr0;
case 2:
	switch( data[p] ) {
		case '\u0020': goto tr6;
		case '\u003c': goto tr7;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr6;
	goto tr0;
case 3:
	if ( data[p] == 61u )
		goto tr8;
	if ( data[p] > 59u ) {
		if ( 63u <= data[p] && data[p] <= 127u )
			goto tr8;
	} else
		goto tr8;
	goto tr0;
case 4:
	if ( data[p] == 62u )
		goto tr9;
	if ( data[p] > 59u ) {
		if ( 61u <= data[p] && data[p] <= 127u )
			goto tr8;
	} else
		goto tr8;
	goto tr0;
case 5:
	switch( data[p] ) {
		case '\u0020': goto tr10;
		case '\u0027': goto tr11;
		case '\u004e': goto tr12;
		case '\u005b': goto tr13;
		case '\u006e': goto tr12;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr10;
	goto tr0;
case 6:
	switch( data[p] ) {
		case '\u0027': goto tr16;
		case '\u005c': goto tr17;
		default: break;
	}
	goto tr15;
case 54:
	switch( data[p] ) {
		case '\u0020': goto tr120;
		case '\u0040': goto tr121;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr120;
	goto tr119;
case 7:
	switch( data[p] ) {
		case '\u0020': goto tr19;
		case '\u0040': goto tr20;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr19;
	goto tr18;
case 8:
	switch( data[p] ) {
		case '\u0020': goto tr21;
		case '\u0027': goto tr22;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr21;
	goto tr18;
case 9:
	switch( data[p] ) {
		case '\u0027': goto tr24;
		case '\u005c': goto tr25;
		default: break;
	}
	goto tr23;
case 55:
	goto tr122;
case 10:
	switch( data[p] ) {
		case '\u0027': goto tr26;
		case '\u005c': goto tr25;
		default: break;
	}
	goto tr23;
case 56:
	switch( data[p] ) {
		case '\u0027': goto tr24;
		case '\u005c': goto tr25;
		default: break;
	}
	goto tr23;
case 11:
	switch( data[p] ) {
		case '\u0027': goto tr27;
		case '\u005c': goto tr17;
		default: break;
	}
	goto tr15;
case 57:
	switch( data[p] ) {
		case '\u0020': goto tr123;
		case '\u0027': goto tr16;
		case '\u0040': goto tr124;
		case '\u005c': goto tr17;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr123;
	goto tr15;
case 12:
	switch( data[p] ) {
		case '\u0020': goto tr28;
		case '\u0027': goto tr16;
		case '\u0040': goto tr29;
		case '\u005c': goto tr17;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr28;
	goto tr15;
case 13:
	switch( data[p] ) {
		case '\u0020': goto tr30;
		case '\u0027': goto tr31;
		case '\u005c': goto tr17;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr30;
	goto tr15;
case 58:
	switch( data[p] ) {
		case '\u0020': goto tr125;
		case '\u0027': goto tr24;
		case '\u0040': goto tr126;
		case '\u005c': goto tr25;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr125;
	goto tr23;
case 14:
	switch( data[p] ) {
		case '\u0020': goto tr32;
		case '\u0027': goto tr24;
		case '\u0040': goto tr33;
		case '\u005c': goto tr25;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr32;
	goto tr23;
case 15:
	switch( data[p] ) {
		case '\u0020': goto tr34;
		case '\u0027': goto tr35;
		case '\u005c': goto tr25;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr34;
	goto tr23;
case 16:
	switch( data[p] ) {
		case '\u0055': goto tr36;
		case '\u0075': goto tr36;
		default: break;
	}
	goto tr0;
case 17:
	switch( data[p] ) {
		case '\u004c': goto tr37;
		case '\u006c': goto tr37;
		default: break;
	}
	goto tr0;
case 18:
	switch( data[p] ) {
		case '\u004c': goto tr38;
		case '\u006c': goto tr38;
		default: break;
	}
	goto tr0;
case 59:
	goto tr127;
case 19:
	switch( data[p] ) {
		case '\u0020': goto tr39;
		case '\u0027': goto tr40;
		case '\u004e': goto tr41;
		case '\u005d': goto tr42;
		case '\u006e': goto tr41;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr39;
	goto tr14;
case 20:
	switch( data[p] ) {
		case '\u0020': goto tr39;
		case '\u0027': goto tr40;
		case '\u004e': goto tr41;
		case '\u006e': goto tr41;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr39;
	goto tr14;
case 21:
	switch( data[p] ) {
		case '\u0027': goto tr44;
		case '\u005c': goto tr45;
		default: break;
	}
	goto tr43;
case 22:
	switch( data[p] ) {
		case '\u0020': goto tr46;
		case '\u0027': goto tr47;
		case '\u002c': goto tr48;
		case '\u004e': goto tr49;
		case '\u005d': goto tr50;
		case '\u006e': goto tr49;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr46;
	goto tr14;
case 23:
	switch( data[p] ) {
		case '\u0020': goto tr51;
		case '\u0027': goto tr40;
		case '\u002c': goto tr52;
		case '\u004e': goto tr41;
		case '\u005d': goto tr42;
		case '\u006e': goto tr41;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr51;
	goto tr14;
case 24:
	switch( data[p] ) {
		case '\u0055': goto tr53;
		case '\u0075': goto tr53;
		default: break;
	}
	goto tr14;
case 25:
	switch( data[p] ) {
		case '\u004c': goto tr54;
		case '\u006c': goto tr54;
		default: break;
	}
	goto tr14;
case 26:
	switch( data[p] ) {
		case '\u004c': goto tr55;
		case '\u006c': goto tr55;
		default: break;
	}
	goto tr14;
case 27:
	switch( data[p] ) {
		case '\u0020': goto tr56;
		case '\u0027': goto tr57;
		case '\u002c': goto tr58;
		case '\u004e': goto tr59;
		case '\u005d': goto tr60;
		case '\u006e': goto tr59;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr56;
	goto tr14;
case 60:
	switch( data[p] ) {
		case '\u0020': goto tr19;
		case '\u0040': goto tr20;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr19;
	goto tr128;
case 28:
	switch( data[p] ) {
		case '\u0027': goto tr61;
		case '\u005c': goto tr45;
		default: break;
	}
	goto tr43;
case 29:
	switch( data[p] ) {
		case '\u0020': goto tr62;
		case '\u0027': goto tr63;
		case '\u002c': goto tr64;
		case '\u004e': goto tr65;
		case '\u005c': goto tr45;
		case '\u005d': goto tr66;
		case '\u006e': goto tr65;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr62;
	goto tr43;
case 30:
	switch( data[p] ) {
		case '\u0020': goto tr67;
		case '\u0027': goto tr68;
		case '\u002c': goto tr69;
		case '\u004e': goto tr70;
		case '\u005c': goto tr45;
		case '\u005d': goto tr71;
		case '\u006e': goto tr70;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr67;
	goto tr43;
case 31:
	switch( data[p] ) {
		case '\u0020': goto tr72;
		case '\u0027': goto tr68;
		case '\u004e': goto tr70;
		case '\u005c': goto tr45;
		case '\u005d': goto tr71;
		case '\u006e': goto tr70;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr72;
	goto tr43;
case 32:
	switch( data[p] ) {
		case '\u0020': goto tr72;
		case '\u0027': goto tr68;
		case '\u004e': goto tr70;
		case '\u005c': goto tr45;
		case '\u006e': goto tr70;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr72;
	goto tr43;
case 33:
	switch( data[p] ) {
		case '\u0027': goto tr44;
		case '\u0055': goto tr73;
		case '\u005c': goto tr45;
		case '\u0075': goto tr73;
		default: break;
	}
	goto tr43;
case 34:
	switch( data[p] ) {
		case '\u0027': goto tr44;
		case '\u004c': goto tr74;
		case '\u005c': goto tr45;
		case '\u006c': goto tr74;
		default: break;
	}
	goto tr43;
case 35:
	switch( data[p] ) {
		case '\u0027': goto tr44;
		case '\u004c': goto tr75;
		case '\u005c': goto tr45;
		case '\u006c': goto tr75;
		default: break;
	}
	goto tr43;
case 36:
	switch( data[p] ) {
		case '\u0020': goto tr76;
		case '\u0027': goto tr77;
		case '\u002c': goto tr78;
		case '\u004e': goto tr79;
		case '\u005c': goto tr45;
		case '\u005d': goto tr80;
		case '\u006e': goto tr79;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr76;
	goto tr43;
case 61:
	switch( data[p] ) {
		case '\u0020': goto tr81;
		case '\u0027': goto tr44;
		case '\u0040': goto tr82;
		case '\u005c': goto tr45;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr81;
	goto tr43;
case 37:
	switch( data[p] ) {
		case '\u0020': goto tr81;
		case '\u0027': goto tr44;
		case '\u0040': goto tr82;
		case '\u005c': goto tr45;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr81;
	goto tr43;
case 38:
	switch( data[p] ) {
		case '\u0020': goto tr83;
		case '\u0027': goto tr84;
		case '\u005c': goto tr45;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr83;
	goto tr43;
case 39:
	switch( data[p] ) {
		case '\u0020': goto tr85;
		case '\u0027': goto tr86;
		case '\u002c': goto tr87;
		case '\u004e': goto tr88;
		case '\u005c': goto tr25;
		case '\u005d': goto tr89;
		case '\u006e': goto tr88;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr85;
	goto tr23;
case 40:
	switch( data[p] ) {
		case '\u0020': goto tr90;
		case '\u0027': goto tr91;
		case '\u002c': goto tr92;
		case '\u004e': goto tr93;
		case '\u005c': goto tr25;
		case '\u005d': goto tr94;
		case '\u006e': goto tr93;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr90;
	goto tr23;
case 62:
	switch( data[p] ) {
		case '\u0027': goto tr44;
		case '\u005c': goto tr45;
		default: break;
	}
	goto tr43;
case 41:
	switch( data[p] ) {
		case '\u0020': goto tr95;
		case '\u0027': goto tr91;
		case '\u004e': goto tr93;
		case '\u005c': goto tr25;
		case '\u005d': goto tr94;
		case '\u006e': goto tr93;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr95;
	goto tr23;
case 42:
	switch( data[p] ) {
		case '\u0020': goto tr95;
		case '\u0027': goto tr91;
		case '\u004e': goto tr93;
		case '\u005c': goto tr25;
		case '\u006e': goto tr93;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr95;
	goto tr23;
case 43:
	switch( data[p] ) {
		case '\u0027': goto tr24;
		case '\u0055': goto tr96;
		case '\u005c': goto tr25;
		case '\u0075': goto tr96;
		default: break;
	}
	goto tr23;
case 44:
	switch( data[p] ) {
		case '\u0027': goto tr24;
		case '\u004c': goto tr97;
		case '\u005c': goto tr25;
		case '\u006c': goto tr97;
		default: break;
	}
	goto tr23;
case 45:
	switch( data[p] ) {
		case '\u0027': goto tr24;
		case '\u004c': goto tr98;
		case '\u005c': goto tr25;
		case '\u006c': goto tr98;
		default: break;
	}
	goto tr23;
case 46:
	switch( data[p] ) {
		case '\u0020': goto tr99;
		case '\u0027': goto tr100;
		case '\u002c': goto tr101;
		case '\u004e': goto tr102;
		case '\u005c': goto tr25;
		case '\u005d': goto tr103;
		case '\u006e': goto tr102;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr99;
	goto tr23;
case 63:
	switch( data[p] ) {
		case '\u0020': goto tr32;
		case '\u0027': goto tr24;
		case '\u0040': goto tr33;
		case '\u005c': goto tr25;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr32;
	goto tr23;
case 47:
	switch( data[p] ) {
		case '\u0020': goto tr0;
		case '\u002c': goto tr0;
		case '\u002e': goto tr0;
		case '\u003c': goto tr0;
		case '\u003e': goto tr0;
		default: break;
	}
	if ( data[p] > 13u ) {
		if ( 40u <= data[p] && data[p] <= 41u )
			goto tr0;
	} else if ( data[p] >= 9u )
		goto tr0;
	goto tr104;
case 48:
	switch( data[p] ) {
		case '\u0020': goto tr106;
		case '\u0028': goto tr107;
		case '\u0029': goto tr0;
		case '\u002c': goto tr0;
		case '\u002e': goto tr108;
		case '\u003c': goto tr109;
		case '\u003e': goto tr0;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr106;
	goto tr105;
case 49:
	if ( data[p] == 41u )
		goto tr110;
	goto tr0;
case 50:
	switch( data[p] ) {
		case '\u0020': goto tr106;
		case '\u002e': goto tr108;
		case '\u003c': goto tr109;
		default: break;
	}
	if ( 9u <= data[p] && data[p] <= 13u )
		goto tr106;
	goto tr0;
		default: break;
	}

	tr1: cs = 0; goto f1;
	tr118: cs = 1; goto f55;
	tr6: cs = 2; goto _again;
	tr3: cs = 2; goto f3;
	tr106: cs = 2; goto f42;
	tr5: cs = 3; goto f5;
	tr7: cs = 3; goto f6;
	tr109: cs = 3; goto f45;
	tr8: cs = 4; goto f1;
	tr10: cs = 5; goto _again;
	tr9: cs = 5; goto f7;
	tr15: cs = 6; goto f1;
	tr11: cs = 6; goto f8;
	tr19: cs = 7; goto _again;
	tr120: cs = 7; goto f57;
	tr21: cs = 8; goto _again;
	tr20: cs = 8; goto f14;
	tr121: cs = 8; goto f58;
	tr23: cs = 9; goto f1;
	tr22: cs = 9; goto f15;
	tr25: cs = 10; goto f1;
	tr17: cs = 11; goto f1;
	tr28: cs = 12; goto f1;
	tr123: cs = 12; goto f60;
	tr30: cs = 13; goto f1;
	tr29: cs = 13; goto f18;
	tr124: cs = 13; goto f61;
	tr32: cs = 14; goto f1;
	tr125: cs = 14; goto f62;
	tr34: cs = 15; goto f1;
	tr33: cs = 15; goto f20;
	tr126: cs = 15; goto f63;
	tr12: cs = 16; goto f9;
	tr36: cs = 17; goto _again;
	tr37: cs = 18; goto _again;
	tr52: cs = 19; goto _again;
	tr13: cs = 19; goto f10;
	tr48: cs = 19; goto f22;
	tr58: cs = 19; goto f25;
	tr39: cs = 20; goto _again;
	tr43: cs = 21; goto f1;
	tr40: cs = 21; goto f15;
	tr47: cs = 21; goto f23;
	tr57: cs = 21; goto f26;
	tr44: cs = 22; goto _again;
	tr51: cs = 23; goto _again;
	tr46: cs = 23; goto f22;
	tr56: cs = 23; goto f25;
	tr41: cs = 24; goto _again;
	tr49: cs = 24; goto f22;
	tr59: cs = 24; goto f25;
	tr53: cs = 25; goto _again;
	tr54: cs = 26; goto _again;
	tr55: cs = 27; goto _again;
	tr45: cs = 28; goto f1;
	tr61: cs = 29; goto f1;
	tr68: cs = 29; goto f15;
	tr63: cs = 29; goto f23;
	tr77: cs = 29; goto f26;
	tr67: cs = 30; goto f1;
	tr62: cs = 30; goto f28;
	tr76: cs = 30; goto f31;
	tr69: cs = 31; goto f1;
	tr64: cs = 31; goto f28;
	tr78: cs = 31; goto f31;
	tr72: cs = 32; goto f1;
	tr70: cs = 33; goto f1;
	tr65: cs = 33; goto f28;
	tr79: cs = 33; goto f31;
	tr73: cs = 34; goto f1;
	tr74: cs = 35; goto f1;
	tr75: cs = 36; goto f1;
	tr81: cs = 37; goto f1;
	tr83: cs = 38; goto f1;
	tr82: cs = 38; goto f18;
	tr84: cs = 39; goto f15;
	tr90: cs = 40; goto f1;
	tr85: cs = 40; goto f33;
	tr99: cs = 40; goto f38;
	tr92: cs = 41; goto f1;
	tr87: cs = 41; goto f33;
	tr101: cs = 41; goto f38;
	tr95: cs = 42; goto f1;
	tr93: cs = 43; goto f1;
	tr88: cs = 43; goto f33;
	tr102: cs = 43; goto f38;
	tr96: cs = 44; goto f1;
	tr97: cs = 45; goto f1;
	tr98: cs = 46; goto f1;
	tr4: cs = 47; goto f4;
	tr108: cs = 47; goto f44;
	tr105: cs = 48; goto f1;
	tr104: cs = 48; goto f41;
	tr107: cs = 49; goto f43;
	tr110: cs = 50; goto _again;
	tr0: cs = 51; goto f0;
	tr2: cs = 51; goto f2;
	tr14: cs = 51; goto f11;
	tr18: cs = 51; goto f13;
	tr111: cs = 51; goto f48;
	tr112: cs = 51; goto f49;
	tr113: cs = 51; goto f50;
	tr114: cs = 51; goto f51;
	tr117: cs = 51; goto f54;
	tr119: cs = 51; goto f56;
	tr122: cs = 51; goto f59;
	tr127: cs = 51; goto f64;
	tr128: cs = 51; goto f65;
	tr115: cs = 52; goto f52;
	tr116: cs = 53; goto f53;
	tr16: cs = 54; goto f12;
	tr24: cs = 55; goto _again;
	tr26: cs = 56; goto f16;
	tr35: cs = 56; goto f19;
	tr27: cs = 57; goto f17;
	tr31: cs = 58; goto f19;
	tr38: cs = 59; goto _again;
	tr42: cs = 60; goto f21;
	tr50: cs = 60; goto f24;
	tr60: cs = 60; goto f27;
	tr66: cs = 61; goto f29;
	tr71: cs = 61; goto f30;
	tr80: cs = 61; goto f32;
	tr86: cs = 62; goto f34;
	tr91: cs = 62; goto f36;
	tr100: cs = 62; goto f39;
	tr89: cs = 63; goto f35;
	tr94: cs = 63; goto f37;
	tr103: cs = 63; goto f40;

f4:
/* #line 4 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
	goto _again;
f43:
/* #line 14 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.Method);
		Log("Recognise token method");
	}
	goto _again;
f1:
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f55:
/* #line 29 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp=new Queue<Token>();
		Log("Begin path expression");
	}
	goto _again;
f3:
/* #line 34 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		if(temp.Count==0)
		{
			buffer.BeginBuffer(p);
			buffer.SetTokenType(TokenType.PropertyOrField);
			temp.Enqueue(buffer.EndBuffer(p));
		}
		stackB.Push(WhereToken.Create(temp,WhereTokenType.MemberAccess));
		Log("End path expression");
	}
	goto _again;
f15:
/* #line 46 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		Log("Begin literal token");
	}
	goto _again;
f22:
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
	goto _again;
f9:
/* #line 61 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp=new Queue<Token>();
		Log("Begin value");
	}
	goto _again;
f25:
/* #line 73 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p-4);
		buffer.SetTokenType(TokenType.Null);
		temp.Enqueue(buffer.EndBuffer(p));
		Log("Read null");
	}
	goto _again;
f14:
/* #line 81 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp=new Queue<Token>();
		Log("Begin formatter");
	}
	goto _again;
f10:
/* #line 93 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp=new Queue<Token>();
		Log("Begin array");
	}
	goto _again;
f6:
/* #line 105 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		temp=new Queue<Token>();
		Log("Begin operator");
	}
	goto _again;
f7:
/* #line 113 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curOperToken=buffer.EndBuffer(p);
		var curOperPriority=WhereOperatorTable.GetOperatorPriority(curOperToken.TokenText);
		while(stackA.Count>0 && stackA.Peek().Priority<curOperPriority)
		{
			stackB.Push(stackA.Pop());
		}
		temp.Enqueue(curOperToken);
		stackA.Push(WhereToken.Create(temp,WhereTokenType.Operator,curOperPriority));
		Log("End operator");
	}
	goto _again;
f12:
/* #line 1 "NONE" */
	{te = p+1;}
	goto _again;
f49:
/* #line 216 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{te = p+1;}
	goto _again;
f48:
/* #line 164 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{te = p+1;{
		errSyntax=buffer.Current();
        errSyntax = data.Substring(buffer.StartOffset, te < buffer.StartOffset ? buffer.EndOffset : te - buffer.StartOffset);
		throw new SyntaxException(te,"Syntax error. Offset:{0}, near \"{1}\"",buffer.StartOffset,errSyntax);
	}}
	goto _again;
f54:
/* #line 164 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{te = p;p--;{
		errSyntax=buffer.Current();
        errSyntax = data.Substring(buffer.StartOffset, te < buffer.StartOffset ? buffer.EndOffset : te - buffer.StartOffset);
		throw new SyntaxException(te,"Syntax error. Offset:{0}, near \"{1}\"",buffer.StartOffset,errSyntax);
	}}
	goto _again;
f13:
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{{p = ((te))-1;}}
	goto _again;
f0:
/* #line 164 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{{p = ((te))-1;}{
		errSyntax=buffer.Current();
        errSyntax = data.Substring(buffer.StartOffset, te < buffer.StartOffset ? buffer.EndOffset : te - buffer.StartOffset);
		throw new SyntaxException(te,"Syntax error. Offset:{0}, near \"{1}\"",buffer.StartOffset,errSyntax);
	}}
	goto _again;
f11:
/* #line 1 "NONE" */
	{	switch( act ) {
	case 6:
	{{p = ((te))-1;}
		errSyntax=buffer.Current();
        errSyntax = data.Substring(buffer.StartOffset, te < buffer.StartOffset ? buffer.EndOffset : te - buffer.StartOffset);
		throw new SyntaxException(te,"Syntax error. Offset:{0}, near \"{1}\"",buffer.StartOffset,errSyntax);
	}
	break;
	default:
	{{p = ((te))-1;}}
	break;
	}
	}
	goto _again;
f41:
/* #line 9 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.SetTokenType(TokenType.PropertyOrField);
		Log("Recognise token property");
	}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f28:
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
	goto _again;
f31:
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
/* #line 73 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p-4);
		buffer.SetTokenType(TokenType.Null);
		temp.Enqueue(buffer.EndBuffer(p));
		Log("Read null");
	}
	goto _again;
f18:
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
/* #line 81 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp=new Queue<Token>();
		Log("Begin formatter");
	}
	goto _again;
f44:
/* #line 24 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 4 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		Log("Begin token");
	}
	goto _again;
f42:
/* #line 24 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 34 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		if(temp.Count==0)
		{
			buffer.BeginBuffer(p);
			buffer.SetTokenType(TokenType.PropertyOrField);
			temp.Enqueue(buffer.EndBuffer(p));
		}
		stackB.Push(WhereToken.Create(temp,WhereTokenType.MemberAccess));
		Log("End path expression");
	}
	goto _again;
f5:
/* #line 34 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		if(temp.Count==0)
		{
			buffer.BeginBuffer(p);
			buffer.SetTokenType(TokenType.PropertyOrField);
			temp.Enqueue(buffer.EndBuffer(p));
		}
		stackB.Push(WhereToken.Create(temp,WhereTokenType.MemberAccess));
		Log("End path expression");
	}
/* #line 105 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		temp=new Queue<Token>();
		Log("Begin operator");
	}
	goto _again;
f33:
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f23:
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 46 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		Log("Begin literal token");
	}
	goto _again;
f57:
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 67 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Value));
		Log("End value");
	}
	goto _again;
f8:
/* #line 61 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp=new Queue<Token>();
		Log("Begin value");
	}
/* #line 46 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		Log("Begin literal token");
	}
	goto _again;
f38:
/* #line 73 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p-4);
		buffer.SetTokenType(TokenType.Null);
		temp.Enqueue(buffer.EndBuffer(p));
		Log("Read null");
	}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f26:
/* #line 73 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p-4);
		buffer.SetTokenType(TokenType.Null);
		temp.Enqueue(buffer.EndBuffer(p));
		Log("Read null");
	}
/* #line 46 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		Log("Begin literal token");
	}
	goto _again;
f20:
/* #line 81 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp=new Queue<Token>();
		Log("Begin formatter");
	}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f2:
/* #line 113 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curOperToken=buffer.EndBuffer(p);
		var curOperPriority=WhereOperatorTable.GetOperatorPriority(curOperToken.TokenText);
		while(stackA.Count>0 && stackA.Peek().Priority<curOperPriority)
		{
			stackB.Push(stackA.Pop());
		}
		temp.Enqueue(curOperToken);
		stackA.Push(WhereToken.Create(temp,WhereTokenType.Operator,curOperPriority));
		Log("End operator");
	}
/* #line 217 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{te = p+1;}
	goto _again;
f50:
/* #line 126 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		buffer.Append('(');
		var curOperToken=buffer.EndBuffer(p);
		var curOperPriority=WhereOperatorTable.GetOperatorPriority(curOperToken.TokenText);
		temp=new Queue<Token>();
		temp.Enqueue(curOperToken);
		stackA.Push(WhereToken.Create(temp,WhereTokenType.LeftParenthesis,curOperPriority));
		Log("(");
	}
/* #line 218 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{te = p+1;}
	goto _again;
f51:
/* #line 139 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
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
/* #line 219 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{te = p+1;}
	goto _again;
f65:
/* #line 159 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		Log(p.ToString());
		Log("End sub expression");
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{te = p;p--;}
	goto _again;
f16:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f19:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 46 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		Log("Begin literal token");
	}
	goto _again;
f21:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 99 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.ValueArray));
		Log("End array");
	}
	goto _again;
f52:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 105 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		temp=new Queue<Token>();
		Log("Begin operator");
	}
	goto _again;
f60:
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 67 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Value));
		Log("End value");
	}
	goto _again;
f45:
/* #line 24 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp.Enqueue(buffer.EndBuffer(p));
		Log("End path token");
	}
/* #line 34 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		if(temp.Count==0)
		{
			buffer.BeginBuffer(p);
			buffer.SetTokenType(TokenType.PropertyOrField);
			temp.Enqueue(buffer.EndBuffer(p));
		}
		stackB.Push(WhereToken.Create(temp,WhereTokenType.MemberAccess));
		Log("End path expression");
	}
/* #line 105 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		temp=new Queue<Token>();
		Log("Begin operator");
	}
	goto _again;
f62:
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 67 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Value));
		Log("End value");
	}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f58:
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 67 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Value));
		Log("End value");
	}
/* #line 81 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp=new Queue<Token>();
		Log("Begin formatter");
	}
	goto _again;
f17:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{act = 1;}
	goto _again;
f36:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 46 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		Log("Begin literal token");
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{act = 1;}
	goto _again;
f24:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 99 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.ValueArray));
		Log("End array");
	}
	goto _again;
f27:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 73 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p-4);
		buffer.SetTokenType(TokenType.Null);
		temp.Enqueue(buffer.EndBuffer(p));
		Log("Read null");
	}
/* #line 99 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.ValueArray));
		Log("End array");
	}
	goto _again;
f37:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 99 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.ValueArray));
		Log("End array");
	}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f53:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 153 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		Log(p.ToString());
		Log("Begin sub expression");
	}
/* #line 164 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{act = 6;}
	goto _again;
f61:
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 67 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Value));
		Log("End value");
	}
/* #line 81 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp=new Queue<Token>();
		Log("Begin formatter");
	}
	goto _again;
f63:
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 67 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Value));
		Log("End value");
	}
/* #line 81 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		temp=new Queue<Token>();
		Log("Begin formatter");
	}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f56:
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 67 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Value));
		Log("End value");
	}
/* #line 159 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		Log(p.ToString());
		Log("End sub expression");
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{te = p;p--;}
	goto _again;
f59:
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 87 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Formatter));
		Log("End formatter");
	}
/* #line 159 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		Log(p.ToString());
		Log("End sub expression");
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{te = p;p--;}
	goto _again;
f64:
/* #line 73 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p-4);
		buffer.SetTokenType(TokenType.Null);
		temp.Enqueue(buffer.EndBuffer(p));
		Log("Read null");
	}
/* #line 67 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.Value));
		Log("End value");
	}
/* #line 159 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		Log(p.ToString());
		Log("End sub expression");
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{te = p;p--;}
	goto _again;
f30:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
/* #line 99 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.ValueArray));
		Log("End array");
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{act = 1;}
	goto _again;
f34:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 46 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		Log("Begin literal token");
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{act = 1;}
	goto _again;
f35:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 99 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.ValueArray));
		Log("End array");
	}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f39:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 73 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p-4);
		buffer.SetTokenType(TokenType.Null);
		temp.Enqueue(buffer.EndBuffer(p));
		Log("Read null");
	}
/* #line 46 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p);
		buffer.SetTokenType(TokenType.Literal);
		Log("Begin literal token");
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{act = 1;}
	goto _again;
f40:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 73 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p-4);
		buffer.SetTokenType(TokenType.Null);
		temp.Enqueue(buffer.EndBuffer(p));
		Log("Read null");
	}
/* #line 99 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.ValueArray));
		Log("End array");
	}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
	goto _again;
f29:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
/* #line 53 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		var curToken=buffer.EndBuffer(p);
		curToken.TokenText=curToken.TokenText.Replace("\\'","'");
		temp.Enqueue(curToken);
		Log("End literal token");
	}
/* #line 99 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.ValueArray));
		Log("End array");
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{act = 1;}
	goto _again;
f32:
/* #line 1 "NONE" */
	{te = p+1;}
/* #line 19 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.Append(data[p]);
		Log(data[p]);
	}
/* #line 73 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		buffer.BeginBuffer(p-4);
		buffer.SetTokenType(TokenType.Null);
		temp.Enqueue(buffer.EndBuffer(p));
		Log("Read null");
	}
/* #line 99 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{
		stackB.Push(WhereToken.Create(temp,WhereTokenType.ValueArray));
		Log("End array");
	}
/* #line 215 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */
	{act = 1;}
	goto _again;

_again:
	switch ( _WhereParser_to_state_actions[cs] ) {
	case 47:
/* #line 1 "NONE" */
	{ts = -1;}
	break;
/* #line 1564 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.cs" */
		default: break;
	}

	if ( ++p != pe )
		goto _resume;
	_test_eof: {}
	if ( p == eof )
	{
	switch ( cs ) {
	case 52: goto tr117;
	case 0: goto tr0;
	case 53: goto tr117;
	case 1: goto tr0;
	case 2: goto tr0;
	case 3: goto tr0;
	case 4: goto tr0;
	case 5: goto tr0;
	case 6: goto tr14;
	case 54: goto tr119;
	case 7: goto tr18;
	case 8: goto tr18;
	case 9: goto tr18;
	case 55: goto tr122;
	case 10: goto tr18;
	case 56: goto tr122;
	case 11: goto tr14;
	case 57: goto tr119;
	case 12: goto tr18;
	case 13: goto tr18;
	case 58: goto tr119;
	case 14: goto tr18;
	case 15: goto tr18;
	case 16: goto tr0;
	case 17: goto tr0;
	case 18: goto tr0;
	case 59: goto tr127;
	case 19: goto tr14;
	case 20: goto tr14;
	case 21: goto tr14;
	case 22: goto tr14;
	case 23: goto tr14;
	case 24: goto tr14;
	case 25: goto tr14;
	case 26: goto tr14;
	case 27: goto tr14;
	case 60: goto tr128;
	case 28: goto tr14;
	case 29: goto tr14;
	case 30: goto tr14;
	case 31: goto tr14;
	case 32: goto tr14;
	case 33: goto tr14;
	case 34: goto tr14;
	case 35: goto tr14;
	case 36: goto tr14;
	case 61: goto tr128;
	case 37: goto tr18;
	case 38: goto tr18;
	case 39: goto tr18;
	case 40: goto tr18;
	case 62: goto tr122;
	case 41: goto tr18;
	case 42: goto tr18;
	case 43: goto tr18;
	case 44: goto tr18;
	case 45: goto tr18;
	case 46: goto tr18;
	case 63: goto tr128;
	case 47: goto tr0;
	case 48: goto tr0;
	case 49: goto tr0;
	case 50: goto tr0;
		default: break;
	}
	}

	}

/* #line 247 "C:/Users/Դʢ/Desktop/LiteralLinq/LiteralLinq/Expression/Compiler/Where/WhereTokenParser.rl" */

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