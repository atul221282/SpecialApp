using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException
{
    public class AddBusinessError<T> : IAddBusinessError<T>, IAddBusinessError
    {
        private IBusinessErrorRules<T> rules;
        public KeyValuePair<string, string> errorMessage { get; private set; }

        public AddBusinessError(IBusinessErrorRules<T> rules)
        {
            this.rules = rules;
        }

        public IBusinessErrorRules<T> AddError(string key, string error)
        {
            errorMessage = new KeyValuePair<string, string>(key, error);
            return rules;
        }
    }
}
