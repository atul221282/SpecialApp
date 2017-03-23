using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Specials
{
   public class SpecialCategoryConfiguration:BaseCodeConfiguration<SpecialCategory>
    {
        public SpecialCategoryConfiguration(EntityTypeBuilder<SpecialCategory> entityTypeBuilder) :base(entityTypeBuilder)
        {

        }
    }
}
