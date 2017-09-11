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
        private readonly int _code;

        public NotFoundError(string error)
        {
            _error = error;
            _code = 404;
        }

        public int Code => _code;

        public string Error => _error;
    }
}
