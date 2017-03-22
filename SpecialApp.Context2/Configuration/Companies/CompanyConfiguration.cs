using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Companies
{
    public class CompanyConfiguration : BaseEntityConfiguration<Company>
    {
        public CompanyConfiguration(EntityTypeBuilder<Company> entityTypeBuilder)
            : base(entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.CompanyName).IsRequired().HasMaxLength(150);
        }
    }
}
