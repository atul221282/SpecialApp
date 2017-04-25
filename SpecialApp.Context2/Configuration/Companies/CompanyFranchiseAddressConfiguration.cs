using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Context.Configuration.Companies
{
    public class CompanyFranchiseAddressConfiguration
    {
        public CompanyFranchiseAddressConfiguration(EntityTypeBuilder<CompanyFranchiseAddress> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.AddressId, x.CompanyFranchiseId });
        }
    }
}
