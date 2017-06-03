using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public class SearchFlterFactory<T> : ISearchFlterFactory<T>
    {
        List<IListFIlter> filters = new List<IListFIlter>();

        public ISearchFlterFactory<T> AddFilter(IListFIlter filter)
        {
            filters.Add(filter);
            return this;
        }

        public void RunFilters()
        {
            filters.ForEach(x =>
            {
                x.Execute();
            });
        }
    }
}
