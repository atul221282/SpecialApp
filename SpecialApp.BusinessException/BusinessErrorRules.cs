using SpecialApp.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException
{
    public class BusinessErrorRules<T> : IBusinessErrorRules<T>
    {
        private T model;
        private List<Tuple<IAddBusinessError, IPropertyValidator>> errorList;
        private readonly IDictionary<string, string> Errors;

        public BusinessErrorRules(T model, List<Tuple<IAddBusinessError, IPropertyValidator>> errorList)
        {
            this.model = model;
            this.errorList = errorList;
            Errors = new Dictionary<string, string>();
        }

        public IAddBusinessError<T> WhenEmpty(Func<T, bool> func)
        {
            var busError = new AddBusinessError<T>(this);

            var validator = new FuncPropertyValidator<T>(func, model, busError.errorMessage);

            errorList.Add(Tuple.Create<IAddBusinessError, IPropertyValidator>(busError, validator));

            return busError;
        }

        public IAddBusinessError<T> WhenNull(Func<T, bool> func)
        {
            var busError = new AddBusinessError<T>(this);

            var validator = new FuncPropertyValidator<T>(func, model, busError.errorMessage);

            errorList.Add(Tuple.Create<IAddBusinessError, IPropertyValidator>(busError, validator));

            return busError;
        }

        public IAddBusinessError<T> WhenNullOrDefault(Func<T, bool> func)
        {
            var busError = new AddBusinessError<T>(this);

            var validator = new FuncPropertyValidator<T>(func, model, busError.errorMessage);

            errorList.Add(Tuple.Create<IAddBusinessError, IPropertyValidator>(busError, validator));

            return busError;
        }

        public void ThrowError()
        {
            errorList.ForEach(x =>
            {
                if (x.Item2.Execute())
                {
                    Errors.Add(x.Item2.errorMessage.Key, x.Item2.errorMessage.Value);
                }
            });
        }
    }
}
