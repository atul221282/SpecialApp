using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public class PermitSearchFlterFactory<T> : IPermitSearchFlterFactory<T>
    {
        List<IListFilter> filters = new List<IListFilter>();
        private IEnumerable<T> listData;

        public PermitSearchFlterFactory(IEnumerable<T> listData)
        {
            this.listData = listData;

        }

        public IPermitSearchFlterFactory<T> AddFilter(IListFilter filter)
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
