﻿using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SpecialApp.Entity.Account;
using System.Collections.Generic;

namespace SpecialApp.Entity
{
    public class SpecialAppUsers : IdentityUser, IAppUsers
    {
        public IAppUsers Resolve()
        {
            if (this == null)
                return UnauthorisedUser.Instance;
            if (!EmailConfirmed)
                return AnonymousUser.Instance;
            return this;
        }

        public object ErrorMessage<TIn, TOut>(Func<TIn, TOut> p, TIn value)
        {
            return p(value);
        }

        public int StatusCode => 200;
    }

    public class AnonymousUser : IdentityUser, IAppUsers
    {
        private static AnonymousUser _instance;
        private AnonymousUser()
        {
            this.PhoneNumber = "";
            this.Id = "";
            this.Email = "";
            this.UserName = "";
            this.PasswordHash = "";
        }
        public static AnonymousUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AnonymousUser();
                return _instance;
            }
        }
        public int StatusCode => 403;

        public object ErrorMessage<TIn, TOut>(Func<TIn, TOut> p, TIn value)
        {
            return new
            {
                Errors = new Dictionary<string, string>
                {
                    ["Error"] = "Failed to login"
                }
            };
        }

        public IAppUsers Resolve()
        {
            return Instance;
        }
    }

    public class UnauthorisedUser : IdentityUser, IAppUsers
    {
        private static UnauthorisedUser _instance;
        private UnauthorisedUser()
        {
            this.PhoneNumber = "";
            this.Id = "";
            this.Email = "";
            this.UserName = "";
            this.PasswordHash = "";
        }
        public static UnauthorisedUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UnauthorisedUser();
                return _instance;
            }
        }
        public int StatusCode => 401;

        public object ErrorMessage<TIn, TOut>(Func<TIn, TOut> p, TIn value)
        {
            return new
            {
                Errors = new Dictionary<string, string>
                {
                    ["Error"] = "Failed to login"
                }
            };
        }

        public IAppUsers Resolve()
        {
            return Instance;
        }
    }

    public interface IAppUsers
    {
        string Id { get; set; }
        string PhoneNumber { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
        int StatusCode { get; }
        IAppUsers Resolve();
        object ErrorMessage<TIn, TOut>(Func<TIn, TOut> p, TIn value);
    }
}