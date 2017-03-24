using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Entity.Companies
{
    public class CompanyFranchiseViewed
    {
        public int CompanyFranchiseId { get; set; }
        public CompanyFranchise CompanyFranchise { get; set; }
        public string SpecialAppUsersId { get; set; }
        public SpecialAppUsers SpecialAppUsers { get; set; }
    }
}
