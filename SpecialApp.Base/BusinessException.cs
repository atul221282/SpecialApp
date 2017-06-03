using SpecialApp.Base.BusinessExceptionRules;
using System;
using System.Collections.Generic;

namespace SpecialApp.Base
{
    public class BusinessException : Exception, IBusinessException
    {
        private readonly IDictionary<string, string> Errors;

        public BusinessException() : base()
        {
            this.Errors = new Dictionary<string, string>();
        }

        public void Add(string key, string error)
        {
            Errors.Add(key, error);
        }

        public IBusinessException ErrorWhen(Func<bool> func, string error, string key = "")
        {
            if (func())
                Errors.Add(key, error);

            return this;
        }

        public IBusinessException NullOrDefault<T>(T value, string error, string key = "")
        {
            if (value.IsNullOrDefault())
                Errors.Add(key ?? nameof(T), error);

            return this;
        }

        public IBusinessException Empty(string value, string error, string key)
        {
            if (value.IsNotNullOrWhiteSpace())
                Errors.Add(key, error);

            return this;
        }

        public void ThrowIfErrors()
        {
            if (Errors.Count > 0)
                throw this;
        }

        public IDictionary<string, string> GetErrors()
        {
            return this.Errors;
        }

        public IBusinessExceptionFor<T> RuleFor<T>(Func<T> model)
        {
            return new BusinessExceptionFor<T>(model, this);
        }
    }
}