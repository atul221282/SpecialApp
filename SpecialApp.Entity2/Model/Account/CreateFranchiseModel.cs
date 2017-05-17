using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Model.Account
{
    public class CreateFranchiseModel
    {
        public List<Address> Addresses { get; set; }
        public bool CanContactCustomers { get; set; }
        public bool CanGetCustomerDetails { get; set; }
        public bool CanSellOnline { get; set; }
        public int CompanyFranchiseCategoryId { get; set; }
        public int CompanyId { get; set; }
        public bool IsConfirmed { get; set; }
        public State State { get; set; }
    }
}
