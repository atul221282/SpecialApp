using SpecialApp.Entity.Model.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.BusinessException.ValidatorFactory
{
    public interface ICustomerValidatorFactory
    {
        Task ValidateCreateCustomer(RegisterCustomer model);
    }
}
