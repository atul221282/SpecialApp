using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Companies
{
    public class CompanyFollowedByUsersConfiguration
    {
        public CompanyFollowedByUsersConfiguration(EntityTypeBuilder<CompanyFollowedBy> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.SpecialAppUsersId, x.CompanyId });
        }
    }
}
