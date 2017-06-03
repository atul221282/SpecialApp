using System.Collections.Generic;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public interface ISearchFlterFactory<T>
    {
        ISearchFlterFactory<T> AddFilter(IListFIlter filter);

        void RunFilters();
    }
}
