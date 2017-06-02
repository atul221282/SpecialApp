using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public class NullOrDefaultFilter<T> : IListFIlter
    {
        private Action p;
        private readonly T value;

        public NullOrDefaultFilter(T value, Action p)
        {
            this.p = p;
            this.value = value;
        }

        public void Execute()
        {
            if (value.IsNotNullOrDefault())
                p();
        }
    }
}
