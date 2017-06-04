using SpecialApp.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException.PropertyValidator
{
    public class NullPropertyValidator<T, T1> : IPropertyValidator, INullPropertyValidator
    {
        private readonly Func<T, T1> func;
        private T model;

        public NullPropertyValidator(Func<T, T1> func, T model)
        {
            this.func = func;
            this.model = model;
        }

        public bool Execute() => model.IsNullOrDefault() || func(model).IsNullOrDefault();
    }
}
