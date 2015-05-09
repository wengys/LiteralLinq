using LiteralLinq.Expression;
using LiteralLinq.Expression.Compiler;
using LiteralLinq.Expression.Compiler.Where;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Spec
{
    public class LiteralSpecification<T> : ISpecification<T>
    {
        private static ValueConverterCollection _converters = ValueConverterCollection.Instance;

        public LiteralSpecification(string exp)
        {
            this.StringExpression = exp;
        }

        public System.Linq.Expressions.Expression<Func<T, bool>> IsSatisfiedBy()
        {
            if (string.IsNullOrWhiteSpace(this.StringExpression))
            {
                throw new SyntaxException(-1, "Syntax empty.");
            }
            WhereCompiler wc = new WhereCompiler(_converters);
            var exp = (System.Linq.Expressions.Expression<Func<T, bool>>)wc.Compile<T>(this.StringExpression);
            return exp;
        }

        public string StringExpression { get; private set; }
    }
}