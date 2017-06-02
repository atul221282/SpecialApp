using System.Collections.Generic;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public interface IPermitSearchFlterFactory<T>
    {
        IPermitSearchFlterFactory<T> AddFilter(IListFilter filter);

        void RunFilters();
    }
}
