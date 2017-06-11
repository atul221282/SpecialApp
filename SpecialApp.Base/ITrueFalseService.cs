using System;
using System.Threading.Tasks;

namespace SpecialApp.Base
{
    public interface ITrueFalseService
    {

        T On<T>(Func<bool> resultFunc, Func<T> whenTrue, Func<T> whenFalse);

        Task<T> On<T>(Func<bool> resultFunc, Func<Task<T>> whenTrue, Func<Task<T>> whenFalse);

        void OnTrue(Func<bool> resultFunc, Action action);

        T OnTrue<T>(Func<bool> resultFunc, Func<T> func);
    }
}