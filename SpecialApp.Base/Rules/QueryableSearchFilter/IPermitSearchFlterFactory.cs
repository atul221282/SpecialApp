﻿using System.Collections.Generic;

namespace SpecialApp.Base.Rules.QueryableSearchFilter
{
    public interface IPermitSearchFlterFactory<T>
    {
        IPermitSearchFlterFactory<T> AddFilter(IListFIlter filter);

        void RunFilters();
    }
}
