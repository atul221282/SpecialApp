using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base.ServiceResponse
{
    public interface IErrorResponse
    {
        string GetError();
        int GetCode();
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

        public int GetCode() => _code;

        public string GetError() => _error;
    }
}
