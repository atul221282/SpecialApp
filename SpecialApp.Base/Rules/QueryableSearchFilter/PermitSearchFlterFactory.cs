using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public class PermitSearchFlterFactory<T> : IPermitSearchFlterFactory<T>
    {
        List<IPermitSearchFilter<T>> filters = new List<IPermitSearchFilter<T>>();
        private IEnumerable<T> listData;

        public PermitSearchFlterFactory(IEnumerable<T> listData)
        {
            this.listData = listData;

        }

        public IPermitSearchFlterFactory<T> AddFilter(IPermitSearchFilter<T> filter)
        {
            filters.Add(filter);
            return this;
        }

        public IEnumerable<T> RunFilters()
        {
            filters.ForEach(x =>
            {
                listData = x.Execute(listData);
            });
            return listData;
        }


    }
}
