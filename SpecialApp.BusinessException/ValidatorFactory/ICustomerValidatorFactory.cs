using SpecialApp.Entity.Model.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.BusinessException.ValidatorFactory
{
    public interface ICustomerValidatorFactory
    {
        void ValidateCreateCustomer(RegisterCustomer model);
    }
}
