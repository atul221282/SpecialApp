using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Entity.Model
{
    public class RegisterCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
