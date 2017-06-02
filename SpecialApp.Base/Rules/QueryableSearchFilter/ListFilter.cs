using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public class ListFilter : IListFilter
    {
        private Tuple<Func<bool>, Action> p;

        public ListFilter(Tuple<Func<bool>, Action> p)
        {
            this.p = p;
        }

        public void Execute()
        {
            if (p.Item1())
                p.Item2();
        }
    }
}
