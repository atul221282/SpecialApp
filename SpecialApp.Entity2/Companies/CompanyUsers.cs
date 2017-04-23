using SpecialApp.Entity.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Companies
{
    public class CompanyUsers : BaseEntity
    {
        public int UsersId { get; set; }
        public int CompanyId { get; set; }
        public Users Users { get; set; }
        public Company Company { get; set; }
        //public DateTimeOffset? DOB { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public SpecialAppUsers SpecialAppUsers { get; set; }
        //public string SpecialAppUsersId { get; set; }
        //public List<UsersAddress> UsersAddress { get; set; }
    }
}
