using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Entity.Companies
{
    public class CompanyFranchiseFollowedBy
    {
        public int CompanyFranchiseId { get; set; }
        public virtual CompanyFranchise CompanyFranchise { get; set; }
        public string SpecialAppUsersId { get; set; }
        public virtual SpecialAppUsers SpecialAppUsers { get; set; }
    }
}
