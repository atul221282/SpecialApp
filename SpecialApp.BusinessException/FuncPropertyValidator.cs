using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException
{
    public class FuncPropertyValidator<T> : IPropertyValidator
    {
        private readonly Func<T, bool> func;
        private T model;

        public FuncPropertyValidator(Func<T, bool> func,
            T model, KeyValuePair<string, string> errorMessage)
        {
            this.func = func;
            this.model = model;
            this.errorMessage = errorMessage;
        }

        public KeyValuePair<string, string> errorMessage { get; private set; }

        public bool Execute() => this.func(model);
    }
}
