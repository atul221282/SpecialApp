using SpecialApp.Entity2;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Companies
{
    public class CompanyFollowedByUsers
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string SpecialAppUsersId { get; set; }
        public SpecialAppUsers SpecialAppUsers { get; set; }
    }
}
