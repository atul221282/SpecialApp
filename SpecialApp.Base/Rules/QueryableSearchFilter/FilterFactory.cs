using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public static class FilterFactory
    {
        public static IListFIlter CreateFilterWithFunc(Func<bool> func, Action action)
        {
            return new FuncWithFilter(Tuple.Create(func, action));
        }

        public static IListFIlter CreateNullOrDefault<T>(T value, Action action)
        {
            return new NullOrDefaultFilter<T>(value, action);
        }
    }
}
