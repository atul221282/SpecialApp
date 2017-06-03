using SpecialApp.Base.BusinessExceptionRules;
using System;
using System.Collections.Generic;

namespace SpecialApp.Base
{
    public interface IBusinessException
    {
        IDictionary<string, string> GetErrors();

        void Add(string key, string error);

        IBusinessException NullOrDefault<T>(T value, string error, string key = "");

        IBusinessException Empty(string value, string error, string key);

        IBusinessException ErrorWhen(Func<bool> func, string error, string key = "");

        IBusinessExceptionFor<T> RuleFor<T>(Func<T> model);

        void ThrowIfErrors();
    }
}