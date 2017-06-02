using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public static class FilterFactory
    {
        public static IListFilter CreateFilter(Func<bool> func, Action action)
        {
            return new ListFilter(Tuple.Create(func, action));
        }
    }
}
