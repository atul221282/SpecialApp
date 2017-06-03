using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialApp.BusinessException
{
    public class BusinessErrorRules<T> : IBusinessErrorRules<T>
    {
        private T model;

        private List<Tuple<IAddBusinessError, IPropertyValidator>> errorList =
            new List<Tuple<IAddBusinessError, IPropertyValidator>>();

        private IDictionary<string, string> Errors;

        private readonly IBusinessRulesError businessRulesError;

        public BusinessErrorRules(T model,
            IBusinessRulesError businessRulesError)
        {
            this.model = model;
            Errors = new Dictionary<string, string>();
            this.businessRulesError = businessRulesError;
        }

        public IAddBusinessError<T> WhenEmpty(Func<T, bool> func)
        {
            var busError = new AddBusinessError<T>(this);

            var validator = new FuncPropertyValidator<T>(func, model);

            errorList.Add(Tuple.Create<IAddBusinessError, IPropertyValidator>(busError, validator));

            return busError;
        }

        public IAddBusinessError<T> WhenNull(Func<T, bool> func)
        {
            var busError = new AddBusinessError<T>(this);

            var validator = new FuncPropertyValidator<T>(func, model);

            errorList.Add(Tuple.Create<IAddBusinessError, IPropertyValidator>(busError, validator));

            return busError;
        }

        public IAddBusinessError<T> WhenNullOrDefault(Func<T, bool> func)
        {
            var busError = new AddBusinessError<T>(this);

            var validator = new FuncPropertyValidator<T>(func, model);

            errorList.Add(Tuple.Create<IAddBusinessError, IPropertyValidator>(busError, validator));

            return busError;
        }

        public void ThrowError()
        {
            Errors = errorList.Where(x => x.Item2.Execute())
                .ToDictionary(dic => dic.Item1.errorMessage.Key, dic => dic.Item1.errorMessage.Value);

            businessRulesError.ThrowError(Errors);
        }
    }
}
