using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException
{
    public interface IBusinessRulesException
    {
        IBusinessErrorRules<T> RulesFor<T>(Func<T> modelFunc);
    }

    public interface IBusinessRulesError
    {
        void ThrowError(IDictionary<string, string> Errors);
    }
}
