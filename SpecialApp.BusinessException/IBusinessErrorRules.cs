using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException
{
    public interface IBusinessErrorRules<T>
    {
        IAddBusinessError<T> WhenEmpty(Func<T, bool> func);

        IAddBusinessError<T> WhenNull(Func<T, bool> func);

        IAddBusinessError<T> WhenNullOrDefault(Func<T, bool> func);

        void ThrowError();
    }
}
