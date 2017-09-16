using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
