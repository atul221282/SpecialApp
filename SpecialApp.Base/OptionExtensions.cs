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

        public Either<TError, T> Else<TError>(Func<TError> func)
        {
            return Process(func);
        }

        public Either<TError, T> SafeElse<TError>(Func<TError> func)
        {
            try
            {
                return Process(func);
            }
            catch (Exception)
            {
                // log error
                return Process(func);
            }
        }

        public Either<TError, T> SafeElse<TError>(Func<TError> func, Action action)
        {
            try
            {
                return Process(func);
            }
            catch (Exception)
            {
                action();
                return Process(func);
            }
        }

        private Either<TError, T> Process<TError>(Func<TError> func)
        {
            if (_conditionFunc())
                return Either.Right<TError, T>(_whenTrueFunc);

            return Either.Left<TError, T>(func);
        }
    }

    public interface IOnTrue<T>
    {
        /// <summary>
        /// Func when condition is true
        /// </summary>
        /// <param name="func">The right func</param>
        /// <returns></returns>
        IOnFalse<T> Then(Func<T> func);
    }

    public interface IOnFalse<T>
    {
        /// <summary>
        /// Execute call
        /// </summary>
        /// <typeparam name="TError">The error type</typeparam>
        /// <param name="func">The error func</param>
        /// <returns>Return either left or right response</returns>
        Either<TError, T> Else<TError>(Func<TError> func);

        /// <summary>
        /// Execute call with try and catch
        /// </summary>
        /// <typeparam name="TError">The error type</typeparam>
        /// <param name="func">The error func</param>
        /// <returns>Return either left or right response</returns>
        Either<TError, T> SafeElse<TError>(Func<TError> func);

        /// <summary>
        /// Execute call with try and catch
        /// </summary>
        /// <typeparam name="TError">The error type</typeparam>
        /// <param name="func">The error func</param>
        /// <param name="action">The action to perform when there is an error</param>
        /// <returns>Return either left or right response</returns>
        Either<TError, T> SafeElse<TError>(Func<TError> func, Action action);
    }
}
