using System;
using System.Collections;
using System.Collections.Generic;

namespace SpecialApp.BusinessException
{
    public class BusinessRulesException : Exception, IBusinessRulesException, IBusinessRulesError
    {
        List<Tuple<IAddBusinessError, IPropertyValidator>> list;
        IDictionary<string, string> Errors;

        public BusinessRulesException() : base()
        {
            this.list = new List<Tuple<IAddBusinessError, IPropertyValidator>>();
        }

        public IBusinessErrorRules<T> RulesFor<T>(Func<T> modelFunc)
        {
            return new BusinessErrorRules<T>(modelFunc(), list, this);
        }

        public IDictionary<string, string> GetErrors()
        {
            return this.Errors;
        }

        public void ThrowError(IDictionary<string, string> Errors)
        {
            this.Errors = Errors;
            if (Errors.Count > 0)
                throw this;
        }
    }
}
