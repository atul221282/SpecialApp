using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Specials
{
    public class SpecialLocationConfiguration
    {
        public SpecialLocationConfiguration(EntityTypeBuilder<SpecialLocation> entityTypeBuilder) 
        {
            entityTypeBuilder.HasKey(x => new { x.SpecialId, x.LocationId });
        }
    }
}
