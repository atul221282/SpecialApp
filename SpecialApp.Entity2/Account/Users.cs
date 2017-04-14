using System;
using System.Collections.Generic;

namespace SpecialApp.Entity.Account
{
    public class Users : BaseEntity
    {
        public DateTimeOffset? DOB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SpecialAppUsers SpecialAppUsers { get; set; }
        public string SpecialAppUsersId { get; set; }
        public List<UsersAddress> UsersAddress { get; set; }
    }

    public class UsersAddress
    {
        public int UsersId { get; set; }
        public Users Users { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}