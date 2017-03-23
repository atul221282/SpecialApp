using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Specials
{
    public class SpecialConfiguration : BaseEntityConfiguration<Special>
    {
        public SpecialConfiguration(EntityTypeBuilder<Special> entityTypeBuilder) : base(entityTypeBuilder)
        {
            //entityTypeBuilder.HasOne(x => x.CompanyFranchise).WithMany(x => x.Specials)
            //    .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
            entityTypeBuilder.Property(x => x.Details).HasMaxLength(1000);
            entityTypeBuilder.Property(x => x.CreateDate).IsRequired();
            entityTypeBuilder.Property(x => x.EndDate).IsRequired();
        }
    }
}
