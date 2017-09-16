using Monad;
using SpecialApp.Base.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base
{
    public static class OptionExtensions
    {
        public static IOnTrue<T> When<T>(this Option<T> value, Func<bool> func)
        {
            return new OnTrue<T>(func);
        }
    }

    public class OnTrue<T> : IOnTrue<T>
    {
        private Func<bool> _conditionFunc;

        public OnTrue(Func<bool> conditionFunc)
        {
            _conditionFunc = conditionFunc;
        }

        public IOnFalse<T> Then(Func<T> func)
        {
            return new OnFalse<T>(func, _conditionFunc);
        }
    }

    public class OnFalse<T> : IOnFalse<T>
    {
        private Func<T> _whenTrueFunc;
        private readonly Func<bool> _conditionFunc;

        public OnFalse(Func<T> whenTrueFunc, Func<bool> conditionFunc)
        {
            _whenTrueFunc = whenTrueFunc;
            _conditionFunc = conditionFunc;
        }

        public Either<IErrorResponse, T> Else(Func<IErrorResponse> func)
        {
            if (_conditionFunc())
                return Either.Right<IErrorResponse, T>(_whenTrueFunc);

            return Either.Left<IErrorResponse, T>(func);
        }
    }

    public interface IOnTrue<T>
    {
        IOnFalse<T> Then(Func<T> func);
    }

    public interface IOnFalse<T>
    {
        Either<IErrorResponse, T> Else(Func<IErrorResponse> func);
    }
}
