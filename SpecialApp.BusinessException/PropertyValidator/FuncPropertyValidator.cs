using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException.PropertyValidator
{
    public class FuncPropertyValidator<T> : IPropertyValidator
    {
        private readonly Func<T, bool> func;
        private T model;

        public FuncPropertyValidator(Func<T, bool> func, T model)
        {
            this.func = func;
            this.model = model;
        }

        public bool Execute() => this.func(model);
    }
}
