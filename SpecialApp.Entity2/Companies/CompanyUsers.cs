using SpecialApp.Entity.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Companies
{
    public class CompanyUsers : Users
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
