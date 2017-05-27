using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SpecialApp.Entity.Account;

namespace SpecialApp.Entity
{
    public class SpecialAppUsers : IdentityUser, IAppUsers
    {
        public IAppUsers Resolve()
        {
            if (this == null)
                return new UnauthorisedUser();
            if (!EmailConfirmed)
                return new AnonymousUser();
            return this;
        }
    }

    public class AnonymousUser : IdentityUser, IAppUsers
    {
        public AnonymousUser()
        {
            this.PhoneNumber = "";
            this.Id = "";
            this.Email = "";
            this.UserName = "";
            this.PasswordHash = "";
        }

        public IAppUsers Resolve()
        {
            return new AnonymousUser();
        }
    }

    public class UnauthorisedUser : IdentityUser, IAppUsers
    {
        public UnauthorisedUser()
        {
            this.PhoneNumber = "";
            this.Id = "";
            this.Email = "";
            this.UserName = "";
            this.PasswordHash = "";
        }

        public IAppUsers Resolve()
        {
            return new UnauthorisedUser();
        }
    }

    public interface IAppUsers
    {
        string Id { get; set; }
        string PhoneNumber { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
        IAppUsers Resolve();
    }
}