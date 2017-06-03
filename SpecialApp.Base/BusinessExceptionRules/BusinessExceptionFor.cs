using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SpecialApp.Base.BusinessExceptionRules
{
    public class BusinessExceptionFor<T> : IBusinessExceptionFor<T>
    {
        private Func<T> model;
        private readonly T Value;
        private readonly IBusinessException busEx;

        public BusinessExceptionFor(Func<T> model, IBusinessException busEx)
        {
            this.model = model;
            this.Value = this.model();
            this.busEx = busEx;
        }

        public IBusinessException When(Func<T, bool> func)
        {
            if (func(Value))
                busEx.Add("", "");

            return busEx;
        }
    }
}
