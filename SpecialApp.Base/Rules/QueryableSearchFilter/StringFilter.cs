using System;
using System.Collections.Generic;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public class StringFilter : IListFIlter
    {
        private readonly Action action;
        private readonly string value;

        public StringFilter(string value, Action action)
        {
            this.action = action;
            this.value = value;
        }

        public void Execute()
        {
            if (this.value.IsNotNullOrWhiteSpace())
                action();
        }
    }
}
