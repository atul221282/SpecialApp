using System;
using System.Collections.Generic;
using System.Text;

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

        public void ThrowIfErrors()
        {
            if (Errors.Count > 0)
                throw this;
        }

        public IDictionary<string, string> GetErrors()
        {
            return this.Errors;
        }
    }
}
