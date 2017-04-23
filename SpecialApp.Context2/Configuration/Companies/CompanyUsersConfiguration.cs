using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Context.Configuration.Account;
using SpecialApp.Entity.Account;
using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Context.Configuration.Companies
{
    public class CompanyUsersConfiguration : BaseEntityConfiguration<CompanyUsers>
    {
        public CompanyUsersConfiguration(EntityTypeBuilder<CompanyUsers> builder) : base(builder)
        {
            builder.Property(x => x.UsersId).IsRequired();
            builder.HasIndex(x => x.UsersId).IsUnique();
        }
    }
}
