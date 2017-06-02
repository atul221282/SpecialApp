using System.Collections.Generic;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public interface IPermitSearchFilter<T>
    {
        IEnumerable<T> Execute(IEnumerable<T> listData);
    }
}
