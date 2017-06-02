using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public class PermitSearchFlterFactory<T> : IPermitSearchFlterFactory<T>
    {
        List<IListFIlter> filters = new List<IListFIlter>();
        private IEnumerable<T> listData;

        public PermitSearchFlterFactory(IEnumerable<T> listData)
        {
            this.listData = listData;

        }

        public IPermitSearchFlterFactory<T> AddFilter(IListFIlter filter)
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
