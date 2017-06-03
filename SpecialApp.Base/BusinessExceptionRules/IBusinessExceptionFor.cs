using System;

namespace SpecialApp.Base.BusinessExceptionRules
{
    public interface IBusinessExceptionFor<T>
    {
        IBusinessException When(Func<T, bool> func);
    }
}