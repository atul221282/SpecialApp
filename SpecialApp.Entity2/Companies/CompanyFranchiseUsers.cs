using SpecialApp.Entity.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Entity.Companies
{
    public class CompanyFranchiseUsers : BaseEntity
    {
        public int UsersId { get; set; }
        public Users Users { get; set; }
        public int CompanyFranchiseId { get; set; }
        public CompanyFranchise CompanyFranchise { get; set; }
    }
}
