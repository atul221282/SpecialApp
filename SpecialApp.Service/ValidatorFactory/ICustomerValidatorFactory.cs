using SpecialApp.Entity.Model.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Service.ValidatorFactory
{
    public interface ICustomerValidatorFactory
    {
        void ValidateCreateCustomer(RegisterCustomer model);
    }
}
