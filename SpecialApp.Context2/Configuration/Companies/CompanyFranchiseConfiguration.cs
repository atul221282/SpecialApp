using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Companies
{
    public class CompanyFranchiseConfiguration : BaseEntityConfiguration<CompanyFranchise>
    {
        private EntityTypeBuilder<CompanyFranchise> entityTypeBuilder;

        public CompanyFranchiseConfiguration(EntityTypeBuilder<CompanyFranchise> entityTypeBuilder)
            : base(entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
            this.entityTypeBuilder.Property(x => x.AddressId).IsRequired();
            this.entityTypeBuilder.Property(x => x.CompanyFranchiseCategoryId).IsRequired();
            this.entityTypeBuilder.Property(x => x.ConfirmationToken).HasMaxLength(250);
            this.entityTypeBuilder.Property(x => x.CreatedById).IsRequired();
        }
    }
}
