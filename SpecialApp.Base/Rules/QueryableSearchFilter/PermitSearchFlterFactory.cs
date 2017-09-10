using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public class PermitSearchFlterFactory<T> : IPermitSearchFlterFactory<T>
    {
        List<IListFIlter> filters = new List<IListFIlter>();

        /// <summary>
        /// Add filter.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IPermitSearchFlterFactory"/>.
        /// </returns>
        public IPermitSearchFlterFactory<T> AddFilter(IListFIlter filter)
        {
            this.filters.Add(filter);
            return this;
        }

        /// <summary>
        /// Run filters.
        /// </summary>
        public void RunFilters()
        {
            this.filters.ForEach(x =>
            {
                x.Execute();
            });
        }
    }
}
