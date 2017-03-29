using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;

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

        public List<SpecialAddress> Addresses { get; set; }

        public List<SpecialFile> Files { get; set; }

        public List<SpecialComment> Comments { get; set; }

        public List<SpecialViewed> ViewedBy { get; set; }

        public List<SpecialLocation> Locations { get; set; }

    }
}