using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteralLinq.Spec
{
    public interface ISpecification<T>
    {
        System.Linq.Expressions.Expression<Func<T, bool>> IsSatisfiedBy();
    }
}