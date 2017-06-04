using SpecialApp.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException.PropertyValidator
{
    public class StringPropertyValidator<T> : IPropertyValidator
    {
        private readonly Func<T, string> func;
        private readonly T model;

        public KeyValuePair<string, string> errorMessage { get; private set; }

        public StringPropertyValidator(Func<T, string> func, T model)
        {
            this.func = func;
            this.model = model;
        }

        public bool Execute() => this.func(model).IsNotNullOrWhiteSpace();
    }
}
