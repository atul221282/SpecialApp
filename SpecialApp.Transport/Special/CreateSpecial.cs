using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;

namespace SpecialApp.Transport.Special
{
    public class CreateSpecial
    {
        public int SpecialCategoryId { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Details { get; set; }

        public string ProductType { get; set; }

        public bool IsAvailableOnline { get; set; }

        public string PromoCode { get; set; }

        public string CreatedById { get; set; }

        public List<SpecialAddress> Addresses { get; set; }

        public List<SpecialFile> Files { get; set; }
    }
}