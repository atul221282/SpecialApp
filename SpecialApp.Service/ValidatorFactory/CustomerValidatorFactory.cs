using System;
using System.Collections.Generic;
using System.Text;
using SpecialApp.Entity.Model.Account;
using SpecialApp.BusinessException;
using SpecialApp.Base;

namespace SpecialApp.Service.ValidatorFactory
{
    public class CustomerValidatorFactory : ICustomerValidatorFactory
    {
        private readonly Func<IBusinessRulesException> busRulesFunc;

        public CustomerValidatorFactory(Func<IBusinessRulesException> busRulesFunc)
        {
            this.busRulesFunc = busRulesFunc;
        }

        public void ValidateCreateCustomer(RegisterCustomer model)
        {
            var busRules = busRulesFunc();

            busRules.RulesFor(() => model)
                .WhenEmpty(x => x.PhoneNumber)
                .AddError("PhoneNumber", "Phone Number is manadatory")
                .When(x => x.EmailAddress.IsNullOrWhiteSpace())
                .AddError("EmailAddress", "Email Address is manadatory")
                .ValidateAndThrow();
        }
    }
}
