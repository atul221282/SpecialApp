using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Base
{
    public class TrueFalseService : ITrueFalseService
    {
        public T On<T>(Func<bool> resultFunc, Func<T> whenTrue, Func<T> whenFalse)
        {
            if (resultFunc() == true)
                return whenTrue();

            return whenFalse();
        }

        public async Task<T> On<T>(Func<bool> resultFunc, Func<Task<T>> whenTrue, Func<Task<T>> whenFalse)
        {
            if (resultFunc?.Invoke() == true)
                return await whenTrue?.Invoke();

            return await whenFalse?.Invoke();
        }

        public void OnTrue(Func<bool> resultFunc, Action action)
        {
            if (resultFunc())
                action();
        }

        public T OnTrue<T>(Func<bool> resultFunc, Func<T> func)
        {
            if (resultFunc())
                return func();

            return default(T);
        }
    }
}
