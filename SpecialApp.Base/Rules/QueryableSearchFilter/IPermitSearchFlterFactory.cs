using System.Collections.Generic;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public interface IPermitSearchFlterFactory<T>
    {
        IPermitSearchFlterFactory<T> AddFilter(IPermitSearchFilter<T> filter);

        IEnumerable<T> RunFilters();
    }
}
