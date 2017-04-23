using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Context.Configuration.Companies
{
    public class CompanyFranchiseUsersConfiguration : BaseEntityConfiguration<CompanyFranchiseUsers>
    {
        public CompanyFranchiseUsersConfiguration(EntityTypeBuilder<CompanyFranchiseUsers> builder) : base(builder)
        {
            builder.Property(x => x.UsersId).IsRequired();
            builder.HasIndex(x => x.UsersId).IsUnique();
        }
    }
}
