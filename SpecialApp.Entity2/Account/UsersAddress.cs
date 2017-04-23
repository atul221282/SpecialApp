using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Account
{
    public class UsersAddress
    {
        public int UsersId { get; set; }
        public Users Users { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
