using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Companies
{
    public class CompanyFranchiseConfiguration : BaseEntityConfiguration<CompanyFranchise>
    {
        public CompanyFranchiseConfiguration(EntityTypeBuilder<CompanyFranchise> entityTypeBuilder)
            : base(entityTypeBuilder)
        {
            //entityTypeBuilder.Property(x => x.AddressId).IsRequired();
            entityTypeBuilder.Property(x => x.CompanyFranchiseCategoryId).IsRequired();
            entityTypeBuilder.Property(x => x.ConfirmationToken).HasMaxLength(250);
            //entityTypeBuilder.Property(x => x.CreatedById).IsRequired();
        }
    }
}
