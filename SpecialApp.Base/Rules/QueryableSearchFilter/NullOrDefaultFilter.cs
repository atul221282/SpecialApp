using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public class NullOrDefaultFilter<TList, TFuncParam> : IPermitSearchFilter<TList>
    {
        private Tuple<TFuncParam, Func<TFuncParam, IEnumerable<TList>>> p;

        public NullOrDefaultFilter(Tuple<TFuncParam, Func<TFuncParam, IEnumerable<TList>>> p)
        {
            this.p = p;
        }

        public IEnumerable<TList> Execute(IEnumerable<TList> listData)
        {
            if (p.Item1.IsNotNullOrDefault())
                listData = p.Item2(p.Item1);

            return listData;
        }
    }
}
