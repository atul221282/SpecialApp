using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Context.Configuration.Companies
{
    public class CompanyFranchiseFollowedByUsersConfiguration
    {
        public CompanyFranchiseFollowedByUsersConfiguration(EntityTypeBuilder<CompanyFranchiseFollowedBy> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.SpecialAppUsersId, x.CompanyFranchiseId });
        }
    }

    public class CompanyFranchiseViewedConfiguration
    {
        public CompanyFranchiseViewedConfiguration(EntityTypeBuilder<CompanyFranchiseViewed> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.SpecialAppUsersId, x.CompanyFranchiseId });
        }
    }
}
