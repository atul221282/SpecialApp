using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Companies
{
    public class CompanyAddressConfiguration
    {
        public CompanyAddressConfiguration(EntityTypeBuilder<CompanyAddress> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.AddressId, x.CompanyId });
        }
    }
}
