using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Special;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration
{
    public class CompanyFranchiseCategoryConfiguration
    {
        private EntityTypeBuilder<CompanyFranchiseCategory> entityTypeBuilder;

        public CompanyFranchiseCategoryConfiguration(EntityTypeBuilder<CompanyFranchiseCategory> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
            this.entityTypeBuilder.HasKey(x => x.Id);
            this.entityTypeBuilder.Property(x => x.Code).HasMaxLength(75);
            this.entityTypeBuilder.Property(x => x.Description).HasMaxLength(250);
            this.entityTypeBuilder.Ignore(x => x.State);
            this.entityTypeBuilder.Property(x => x.RowVersion).IsConcurrencyToken().IsRowVersion();
        }
    }
}
