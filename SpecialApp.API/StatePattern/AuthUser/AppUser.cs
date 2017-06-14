using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.StatePattern.AuthUser
{
    public class AppUser
    {
        private readonly SpecialAppUsers user;
        private IAppUserState UnauthorisedUser;
        private IAppUserState AuthorisedUser;

        private IAppUserState currentState;

        public AppUser(SpecialAppUsers user)
        {
            this.user = user;
            UnauthorisedUser = new UnautorisedUser(user);
            AuthorisedUser = new AuthorisedUser(user);
            this.currentState = new UnautorisedUser(user);
        }

        public IAppUserState ResolveAppuser()
        {
            return currentState;
        }
    }
}
