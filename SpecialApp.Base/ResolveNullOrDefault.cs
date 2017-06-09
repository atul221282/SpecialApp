using System;
using System.Collections.Generic;

namespace SpecialApp.Base
{
    public class ResolveNullOrDefault<T>
    {
        private T value;
        private IDictionary<bool, Func<T>> dict = new Dictionary<bool, Func<T>>();

        public ResolveNullOrDefault(T v, Func<T> whenNullOrDefault)
        {
            this.value = v;
            dict.Add(false, whenNullOrDefault);
            dict.Add(true, () => this.value);
        }

        public T GetValue()
        {
            var result= dict[value.IsNotNullOrDefault()].Invoke();
            return result;
        }
    }
}