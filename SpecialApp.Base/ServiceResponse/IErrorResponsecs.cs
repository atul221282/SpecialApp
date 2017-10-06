using static System.String;
using System.Collections.Generic;
using System.Linq;
using Monad;
using SpecialApp.Entity.Specials;
using System;
using System.Threading.Tasks;

namespace SpecialApp.Base.ServiceResponse
{
    public interface IErrorResponse
    {
        string Error { get; }
        int Code { get; }
    }

    public class NotFoundError : IErrorResponse
    {
        private readonly string _error;

        public NotFoundError(string error)
        {
            _error = error;
        }

        public int Code => 404;

        public string Error => _error;

        private bool HasError => !IsNullOrWhiteSpace(Error);
    }

    public class UnprocessableEntity : IErrorResponse
    {
        private readonly string _error;

        public UnprocessableEntity(string error)
        {
            _error = error;
        }

        public int Code => 422;

        public string Error => _error;

        private bool HasError => !IsNullOrWhiteSpace(Error);

        public async Task<Either<IErrorResponse, T>> ProcessAsync<T>(Func<Task<Either<IErrorResponse, T>>> successCase)
        {
            if (HasError)
            {
                return Either.Left<IErrorResponse, T>(() => this);
            }
            return await successCase?.Invoke();
        }
    }
}
