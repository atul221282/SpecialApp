using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Entity.Model.Account
{
    public class LoginModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
