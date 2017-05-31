using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;

namespace SpecialApp.Entity.Specials
{
    public class Special : BaseEntity, ISpecial
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

    public interface ISpecial : IBaseEntity
    {
        int CompanyFranchiseId { get; set; }
        CompanyFranchise CompanyFranchise { get; set; }

        int SpecialCategoryId { get; set; }
        SpecialCategory SpecialCategory { get; set; }

        DateTime? CreateDate { get; set; }

        DateTime? EndDate { get; set; }

        string Details { get; set; }

        string ProductType { get; set; }

        bool IsAvailableOnline { get; set; }

        string PromoCode { get; set; }

        string CreatedById { get; set; }
        SpecialAppUsers CreatedBy { get; set; }

        List<SpecialAddress> Addresses { get; set; }

        List<SpecialFile> Files { get; set; }

        List<SpecialComment> Comments { get; set; }

        List<SpecialViewed> ViewedBy { get; set; }

        List<SpecialLocation> Locations { get; set; }
    }
}