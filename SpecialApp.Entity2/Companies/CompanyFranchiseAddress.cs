using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Entity.Companies
{
    public class CompanyFranchiseAddress
    {
        public int CompanyFranchiseId { get; set; }
        public CompanyFranchise CompanyFranchise { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
