using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException
{
    public interface IBusinessErrorRules<T>
    {
        IAddBusinessError<T> When(Func<T, bool> func);

        IAddBusinessError<T> WhenEmpty(Func<T, string> action);

        IAddBusinessError<T> WhenNull<T1>(Func<T, T1> func);

        IDictionary<string, string> GetErrors();

        void ValidateAndThrow();
    }
}
