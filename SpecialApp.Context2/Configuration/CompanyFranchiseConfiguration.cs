using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Special;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration
{
    public class CompanyFranchiseConfiguration
    {
        private EntityTypeBuilder<CompanyFranchise> entityTypeBuilder;

        public CompanyFranchiseConfiguration(EntityTypeBuilder<CompanyFranchise> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
            this.entityTypeBuilder.HasKey(x => x.Id);
            this.entityTypeBuilder.Property(x => x.AddressId).IsRequired();
            this.entityTypeBuilder.Property(x => x.CompanyFranchiseCategoryId).IsRequired();
            this.entityTypeBuilder.Property(x => x.CreatedById).IsRequired();
            this.entityTypeBuilder.Property(x => x.IsConfirmed).IsRequired();
            this.entityTypeBuilder.Ignore(x => x.State);
            this.entityTypeBuilder.Property(x => x.RowVersion).IsConcurrencyToken().IsRowVersion();
        }
    }
}
