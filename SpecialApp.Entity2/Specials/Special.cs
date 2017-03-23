using SpecialApp.Entity.Companies;
using SpecialApp.Entity2;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Specials
{
    public class Special : BaseEntity
    {
        public int CompanyFranchiseId { get; set; }
        public virtual CompanyFranchise CompanyFranchise { get; set; }

        public int SpecialCategoryId { get; set; }
        public virtual SpecialCategory SpecialCategory { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Details { get; set; }

        public string ProductType { get; set; }

        public bool IsAvailableOnline { get; set; }

        public string PromoCode { get; set; }

        public string CreatedById { get; set; }
        public virtual SpecialAppUsers CreatedBy { get; set; }

        public List<SpecialAddress> SpecialAddresses { get; set; }

        //public List<CompanyFranchiseSpecialRatingsAndComments> CompanyFranchiseSpecialRatingsAndComments { get; set; }

        //public List<CompanyFranchiseSpecialViewed> CompanyFranchiseSpecialVieweds { get; set; }

        //public List<CompanyFranchiseSpecialLocation> CompanyFranchiseSpecialLocations { get; set; }

        //public List<CompanyFranchiseSpecialFile> CompanyFranchiseSpecialFiles { get; set; }

    }
}
