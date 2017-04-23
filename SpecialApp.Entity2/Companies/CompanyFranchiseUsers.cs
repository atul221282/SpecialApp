using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Entity.Companies
{
    public class CompanyFranchiseUsers : CompanyUsers
    {
        public int CompanyFranchiseId { get; set; }
        public CompanyFranchise CompanyFranchise { get; set; }
    }
}
