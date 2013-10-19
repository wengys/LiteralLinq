using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Expression.Compiler.OrderBy
{
    public class OrderByTokenParser
    {
        private static readonly sbyte[] _OrderByParser_to_state_actions = new sbyte[] {
	0, 0, 0, 0, 0, 0, 0, 0,
	8, 0, 0, 0, 0, 0, 0, 0
};

        private static readonly sbyte[] _OrderByParser_from_state_actions = new sbyte[] {
	0, 0, 0, 0, 0, 0, 0, 0,
	9, 0, 0, 0, 0, 0, 0, 0
};

        private const int OrderByParser_start = 8;
        private const int OrderByParser_first_final = 8;
        private const int OrderByParser_error = -1;

        private const int OrderByParser_en_main = 8;

        public OrderByTokenCollection Parse(string expression)
        {
            TokenParseBuffer buffer = new TokenParseBuffer();
            Queue<Token> pathTokenBuffer = null;
            Token? directionTokenBuffer = null;
            OrderByTokenCollection tokenCollection = new OrderByTokenCollection();
            var data = expression;
            int p = 0, pe = data.Length, cs, eof = data.Length;
            int ts, te, act;
            string errSyntex;

            {
                cs = OrderByParser_start;
                ts = -1;
                te = -1;
                act = 0;
            }

            {
                if (p == pe)
                    goto _test_eof;
            _resume:
                switch (_OrderByParser_from_state_actions[cs])
                {
                    case 9:

                        { ts = p; }
                        break;

                    default: break;
                }

                switch (cs)
                {
                    case 8:
                        switch (data[p])
                        {
                            case '\u0020': goto tr14;
                            case '\u002c': goto tr2;
                            case '\u0049': goto tr15;
                            case '\u0069': goto tr15;
                            default: break;
                        }
                        if (9u <= data[p] && data[p] <= 13u)
                            goto tr14;
                        goto tr13;
                    case 9:
                        switch (data[p])
                        {
                            case '\u0020': goto tr1;
                            case '\u002c': goto tr2;
                            case '\u0049': goto tr3;
                            case '\u0069': goto tr3;
                            default: break;
                        }
                        if (9u <= data[p] && data[p] <= 13u)
                            goto tr1;
                        goto tr16;
                    case 0:
                        switch (data[p])
                        {
                            case '\u0020': goto tr1;
                            case '\u002c': goto tr2;
                            case '\u0049': goto tr3;
                            case '\u0069': goto tr3;
                            default: break;
                        }
                        if (9u <= data[p] && data[p] <= 13u)
                            goto tr1;
                        goto tr0;
                    case 10:
                        if (data[p] == 32u)
                            goto tr2;
                        if (9u <= data[p] && data[p] <= 13u)
                            goto tr2;
                        goto tr17;
                    case 1:
                        switch (data[p])
                        {
                            case '\u0054': goto tr4;
                            case '\u0074': goto tr4;
                            default: break;
                        }
                        goto tr0;
                    case 2:
                        if (data[p] == 46u)
                            goto tr5;
                        goto tr0;
                    case 3:
                        switch (data[p])
                        {
                            case '\u0020': goto tr6;
                            case '\u002c': goto tr6;
                            case '\u002e': goto tr6;
                            default: break;
                        }
                        if (data[p] > 13u)
                        {
                            if (40u <= data[p] && data[p] <= 41u)
                                goto tr6;
                        }
                        else if (data[p] >= 9u)
                            goto tr6;
                        goto tr7;
                    case 11:
                        switch (data[p])
                        {
                            case '\u0020': goto tr20;
                            case '\u0028': goto tr21;
                            case '\u0029': goto tr18;
                            case '\u002c': goto tr18;
                            case '\u002e': goto tr22;
                            default: break;
                        }
                        if (9u <= data[p] && data[p] <= 13u)
                            goto tr20;
                        goto tr19;
                    case 12:
                        switch (data[p])
                        {
                            case '\u0020': goto tr24;
                            case '\u0041': goto tr25;
                            case '\u0044': goto tr26;
                            case '\u0061': goto tr25;
                            case '\u0064': goto tr26;
                            default: break;
                        }
                        if (9u <= data[p] && data[p] <= 13u)
                            goto tr24;
                        goto tr23;
                    case 4:
                        switch (data[p])
                        {
                            case '\u0053': goto tr9;
                            case '\u0073': goto tr9;
                            default: break;
                        }
                        goto tr8;
                    case 5:
                        switch (data[p])
                        {
                            case '\u0043': goto tr10;
                            case '\u0063': goto tr10;
                            default: break;
                        }
                        goto tr8;
                    case 13:
                        if (data[p] == 32u)
                            goto tr28;
                        if (9u <= data[p] && data[p] <= 13u)
                            goto tr28;
                        goto tr27;
                    case 6:
                        switch (data[p])
                        {
                            case '\u0045': goto tr11;
                            case '\u0065': goto tr11;
                            default: break;
                        }
                        goto tr8;
                    case 7:
                        if (data[p] == 41u)
                            goto tr12;
                        goto tr8;
                    case 14:
                        switch (data[p])
                        {
                            case '\u0020': goto tr20;
                            case '\u002e': goto tr22;
                            default: break;
                        }
                        if (9u <= data[p] && data[p] <= 13u)
                            goto tr20;
                        goto tr18;
                    case 15:
                        switch (data[p])
                        {
                            case '\u0054': goto tr4;
                            case '\u0074': goto tr4;
                            default: break;
                        }
                        goto tr16;
                    default: break;
                }

            tr1: cs = 0; goto _again;
            tr3: cs = 1; goto _again;
            tr4: cs = 2; goto _again;
            tr5: cs = 3; goto f1;
            tr22: cs = 3; goto f17;
            tr11: cs = 4; goto f5;
            tr25: cs = 4; goto f20;
            tr9: cs = 5; goto f5;
            tr26: cs = 6; goto f20;
            tr21: cs = 7; goto f16;
            tr0: cs = 8; goto f0;
            tr6: cs = 8; goto f2;
            tr8: cs = 8; goto f4;
            tr13: cs = 8; goto f9;
            tr16: cs = 8; goto f11;
            tr17: cs = 8; goto f12;
            tr18: cs = 8; goto f13;
            tr23: cs = 8; goto f18;
            tr27: cs = 8; goto f21;
            tr14: cs = 9; goto f10;
            tr2: cs = 10; goto _again;
            tr7: cs = 11; goto f3;
            tr19: cs = 11; goto f14;
            tr20: cs = 12; goto f15;
            tr24: cs = 12; goto f19;
            tr28: cs = 12; goto f22;
            tr10: cs = 13; goto f5;
            tr12: cs = 14; goto f6;
            tr15: cs = 15; goto f10;

            f5:
                {
                    buffer.Append(data[p]);
                    Log(data[p]);
                }
                goto _again;
            f17:
                {
                    pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
                    Log("end path");
                }
                goto _again;
            f16:
                {
                    buffer.SetTokenType(TokenType.Method);
                    Log("switch method");
                }
                goto _again;
            f1:
                {
                    directionTokenBuffer = null;
                    pathTokenBuffer = new Queue<Token>();
                    Log("begin path exp");
                }
                goto _again;
            f19:

                { te = p + 1; }
                goto _again;
            f9:
                {
                    te = p + 1;
                    {
                        errSyntex = buffer.Current();
                        errSyntex = data.Substring(buffer.StartOffset, te - buffer.StartOffset);
                        throw new SyntexException(te, "语法错误。位于列{0}, {1}附近", te, errSyntex);
                    }
                }
                goto _again;
            f12:

                { te = p; p--; }
                goto _again;
            f11:
                {
                    te = p; p--;
                    {
                        errSyntex = buffer.Current();
                        errSyntex = data.Substring(buffer.StartOffset, te - buffer.StartOffset);
                        throw new SyntexException(te, "语法错误。位于列{0}, {1}附近", te, errSyntex);
                    }
                }
                goto _again;
            f4:

                { { p = ((te)) - 1; } }
                goto _again;
            f0:
                {
                    { p = ((te)) - 1; }
                    {
                        errSyntex = buffer.Current();
                        errSyntex = data.Substring(buffer.StartOffset, te - buffer.StartOffset);
                        throw new SyntexException(te, "语法错误。位于列{0}, {1}附近", te, errSyntex);
                    }
                }
                goto _again;
            f2:
                {
                    switch (act)
                    {
                        case 3:
                            {
                                { p = ((te)) - 1; }
                                errSyntex = buffer.Current();
                                errSyntex = data.Substring(buffer.StartOffset, te - buffer.StartOffset);
                                throw new SyntexException(te, "语法错误。位于列{0}, {1}附近", te, errSyntex);
                            }
                            break;

                        default:
                            { { p = ((te)) - 1; } }
                            break;
                    }
                }
                goto _again;
            f20:
                {
                    buffer.BeginBuffer(p);
                    buffer.SetTokenType(TokenType.Literal);
                    Log("dir");
                }

                {
                    buffer.Append(data[p]);
                    Log(data[p]);
                }
                goto _again;
            f18:
                {
                    tokenCollection.Append(pathTokenBuffer, directionTokenBuffer ?? new Token("ASC", TokenType.Literal, -1, -1));
                    Log("end path exp");
                }

                { te = p; p--; }
                goto _again;
            f15:

                { te = p + 1; }

                {
                    pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
                    Log("end path");
                }
                goto _again;
            f22:

                { te = p + 1; }

                {
                    directionTokenBuffer = buffer.EndBuffer(p);
                    Log("end dir");
                }
                goto _again;
            f6:

                { te = p + 1; }

                { act = 1; }
                goto _again;
            f10:

                { te = p + 1; }

                { act = 3; }
                goto _again;
            f13:
                {
                    pathTokenBuffer.Enqueue(buffer.EndBuffer(p));
                    Log("end path");
                }

                {
                    tokenCollection.Append(pathTokenBuffer, directionTokenBuffer ?? new Token("ASC", TokenType.Literal, -1, -1));
                    Log("end path exp");
                }

                { te = p; p--; }
                goto _again;
            f21:
                {
                    directionTokenBuffer = buffer.EndBuffer(p);
                    Log("end dir");
                }

                {
                    tokenCollection.Append(pathTokenBuffer, directionTokenBuffer ?? new Token("ASC", TokenType.Literal, -1, -1));
                    Log("end path exp");
                }

                { te = p; p--; }
                goto _again;
            f14:

                { te = p + 1; }

                {
                    buffer.Append(data[p]);
                    Log(data[p]);
                }

                { act = 1; }
                goto _again;
            f3:

                { te = p + 1; }

                {
                    buffer.BeginBuffer(p);
                    buffer.SetTokenType(TokenType.PropertyOrField);
                    Log("path");
                }

                {
                    buffer.Append(data[p]);
                    Log(data[p]);
                }

                { act = 1; }
                goto _again;

            _again:
                switch (_OrderByParser_to_state_actions[cs])
                {
                    case 8:

                        { ts = -1; }
                        break;

                    default: break;
                }

                if (++p != pe)
                    goto _resume;
            _test_eof: { }
                if (p == eof)
                {
                    switch (cs)
                    {
                        case 9: goto tr16;
                        case 0: goto tr0;
                        case 10: goto tr17;
                        case 1: goto tr0;
                        case 2: goto tr0;
                        case 3: goto tr6;
                        case 11: goto tr18;
                        case 12: goto tr23;
                        case 4: goto tr8;
                        case 5: goto tr8;
                        case 13: goto tr27;
                        case 6: goto tr8;
                        case 7: goto tr8;
                        case 14: goto tr18;
                        case 15: goto tr16;
                        default: break;
                    }
                }
            }

            return tokenCollection;
        }

        [System.Diagnostics.Conditional("DEBUG")]
        public void Log(object msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}