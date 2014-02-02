namespace LiteralLinq.Expression.Compiler
{
    internal enum TokenType
    {
        Undefined,
        PropertyOrField,
        Method,
        Literal, //Any argument or setting
        Null
    }
}