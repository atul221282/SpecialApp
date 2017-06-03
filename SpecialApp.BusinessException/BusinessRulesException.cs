using System;
using System.Collections;
using System.Collections.Generic;

namespace SpecialApp.BusinessException
{
    public class BusinessRulesException : Exception, IBusinessRulesException
    {
        List<Tuple<IAddBusinessError, IPropertyValidator>> list;

        public BusinessRulesException() : base()
        {
            this.list = new List<Tuple<IAddBusinessError, IPropertyValidator>>();
        }

        public IBusinessErrorRules<T> RulesFor<T>(Func<T> modelFunc)
        {
            return new BusinessErrorRules<T>(modelFunc(), list);
        }
    }
}
