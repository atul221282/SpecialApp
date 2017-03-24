using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialApp.Context.Configuration.Specials
{
    public class SpecialViewConfiguration
    {
        public SpecialViewConfiguration(EntityTypeBuilder<SpecialView> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.SpecialId, x.ViewedById });
        }
    }
}
