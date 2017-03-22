using SpecialApp.Entity2;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Companies
{
    public class CompanyAddress
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
