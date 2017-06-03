using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException
{
    public interface IAddBusinessError<T>
    {
        IBusinessErrorRules<T> AddError(string key, string error);
    }
}
