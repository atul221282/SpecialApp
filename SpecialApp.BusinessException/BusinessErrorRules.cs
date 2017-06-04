using SpecialApp.BusinessException.PropertyValidator;
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

        public IAddBusinessError<T> When(Func<T, bool> func)
        {
            var busError = new AddBusinessError<T>(this);

            var validator = new FuncPropertyValidator<T>(func, model);

            errorList.Add(Tuple.Create<IAddBusinessError, IPropertyValidator>(busError, validator));

            return busError;
        }

        public IAddBusinessError<T> WhenEmpty(Func<T, string> action)
        {
            var busError = new AddBusinessError<T>(this);

            var validator = new StringPropertyValidator<T>(action, model);

            errorList.Add(Tuple.Create<IAddBusinessError, IPropertyValidator>(busError, validator));

            return busError;
        }

        public void ValidateAndThrow()
        {
            SetErrors();

            businessRulesError.ThrowError(Errors);
        }

        public IDictionary<string,string> GetErrors()
        {
            SetErrors();

            return Errors;
        }

        private void SetErrors()
        {
            Errors = errorList.Where(x => x.Item2.Execute())
                .ToDictionary(dic => dic.Item1.errorMessage.Key, dic => dic.Item1.errorMessage.Value);
        }
    }
}
