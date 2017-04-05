using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Account
{
    public class UsersConfiguration : BaseEntityConfiguration<Users>
    {
        public UsersConfiguration(EntityTypeBuilder<Users> entityTypeBuilder) : base(entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.SpecialAppUsersId).IsRequired();
        }
    }
}
