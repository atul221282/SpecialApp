using System;
using SpecialApp.Entity.Model.Account;
using SpecialApp.Base;
using System.Threading.Tasks;

namespace SpecialApp.BusinessException.ValidatorFactory
{
    public class CustomerValidatorFactory : ICustomerValidatorFactory
    {
        private readonly Func<IBusinessRulesException> busRulesFunc;

        public CustomerValidatorFactory(Func<IBusinessRulesException> busRulesFunc)
        {
            this.busRulesFunc = busRulesFunc;
        }

        public async Task ValidateCreateCustomer(RegisterCustomer model)
        {
            var busRules = busRulesFunc();

            await busRules.RulesFor(() => model).WhenEmpty(x => x.PhoneNumber)
                 .AddError("PhoneNumber", "Phone Number is manadatory")
                 .When(x => x.EmailAddress.IsNullOrWhiteSpace())
                 .AddError("EmailAddress", "Email Address is manadatory")
                 .WhenNull(x => x).AddError(nameof(RegisterCustomer), "Inavlid Data")
                 .WhenNull(x => x.PhoneNumber).AddError("PhoneNumber", "Phone Number is manadatory")
                 .ValidateAndThrowAsync();
        }
    }
}
