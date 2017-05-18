using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Base
{
    public class UserIdentity : IUserIdentity
    {
        private readonly IIdentity identity;
        private readonly ClaimsPrincipal principal;

        public UserIdentity()
        {
        }

        //public UserIdentity(Func<ClaimsPrincipal> principal, Func<IIdentity> identity)
        public UserIdentity(ClaimsPrincipal principal, IIdentity identity)
        {
            this.principal = principal;
            this.identity = identity;
        }

        public bool IsAuthenticated
        {
            get
            {
                return identity != null ? identity.IsAuthenticated : false;
            }
        }

        public string GetEmail() => principal?.Claims?.FirstOrDefault()?.Value;

    }
}

