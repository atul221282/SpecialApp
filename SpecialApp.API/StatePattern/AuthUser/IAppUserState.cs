using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecialApp.API.StatePattern.AuthUser
{
    public interface IAppUserState
    {
        IVerifiedUser GetUserState();
    }
}
