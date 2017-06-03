using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException
{
    public class StringPropertyValidator : IPropertyValidator
    {
        private readonly Func<string, bool> func;
        private readonly string model;

        public KeyValuePair<string, string> errorMessage { get; private set; }

        public StringPropertyValidator(Func<string, bool> func, string model, KeyValuePair<string, string> erroroMessage)
        {
            this.func = func;
            this.errorMessage = errorMessage;
            this.model = model;
        }

        public bool Execute() => this.func(model);
    }
}
