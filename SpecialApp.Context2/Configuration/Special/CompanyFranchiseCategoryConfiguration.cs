using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Special;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Special
{
    public class CompanyFranchiseCategoryConfiguration : BaseCodeConfiguration<CompanyFranchiseCategory>
    {
        private EntityTypeBuilder<CompanyFranchiseCategory> entityTypeBuilder;

        public CompanyFranchiseCategoryConfiguration(EntityTypeBuilder<CompanyFranchiseCategory> entityTypeBuilder)
            : base(entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}
