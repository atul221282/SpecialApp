using SpecialApp.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base
{
    public class EnsureNullOrEmpty
    {
        private readonly string value;
        private readonly IDictionary<bool, Func<string>> dict = new Dictionary<bool, Func<string>>();

        public EnsureNullOrEmpty(string value,Func<string> whenNullOrEmpty)
        {
            this.value = value;
            dict.Add(true, whenNullOrEmpty);
            dict.Add(false, () => value);
        }

        public string GetValue()
        {
            return dict[value.IsNullOrWhiteSpace()].Invoke();
        }
    }
}
