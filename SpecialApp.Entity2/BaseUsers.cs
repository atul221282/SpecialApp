using SpecialApp.Entity.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity
{
    public abstract class BaseUsers : BaseEntity
    {
        public DateTimeOffset? DOB { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public SpecialAppUsers SpecialAppUsers { get; set; }
        public string SpecialAppUsersId { get; set; }

        public List<UsersAddress> UsersAddress { get; set; }
    }
}
