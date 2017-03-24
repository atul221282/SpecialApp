using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Specials;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Companies
{
    public class CompanyFranchise : BaseEntity
    {
        public bool IsConfirmed { get; set; }

        public bool CanGetCustomerDetails { get; set; }

        public bool CanContactCustomers { get; set; }

        public bool CanSellOnline { get; set; }

        public string ConfirmationToken { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public int CompanyFranchiseCategoryId { get; set; }
        public virtual CompanyFranchiseCategory CompanyFranchiseCategory { get; set; }

        public string CreatedById { get; set; }
        public virtual SpecialAppUsers CreatedBy { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public List<CompanyFranchiseFollowedBy> CompanyFranchiseFollowedByUsers { get; set; }
        public List<CompanyFranchiseViewed> CompanyFranchiseViewed { get; set; }

        public List<Special> Specials { get; set; }
    }
}