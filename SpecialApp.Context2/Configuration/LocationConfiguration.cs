using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration
{
    public class LocationConfiguration: BaseEntityConfiguration<Location>
    {
        public LocationConfiguration(EntityTypeBuilder<Location> entityTypeBuilder) : base(entityTypeBuilder)
        {

        }
    }
}
