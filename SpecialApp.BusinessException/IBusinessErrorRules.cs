using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException
{
    public interface IBusinessErrorRules<T>
    {
        IAddBusinessError<T> When(Func<T, bool> func);

        IAddBusinessError<T> WhenEmpty(Func<T, string> action);

        IDictionary<string, string> GetErrors();

        void ValidateAndThrow();
    }
}
