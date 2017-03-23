using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Specials
{
    public class SpecialAddressConfiguration
    {
        public SpecialAddressConfiguration(EntityTypeBuilder<SpecialAddress> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.SpecialId, x.AddressId });
            entityTypeBuilder.Property(x => x.ContactEmail).HasMaxLength(100);
            entityTypeBuilder.Property(x => x.ContactNumber).HasMaxLength(20);
        }
    }
}
