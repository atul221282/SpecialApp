using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity2;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context2.Configuration
{
    public class AddressConfiguration
    {
        private EntityTypeBuilder<Address> entityTypeBuilder;
        public AddressConfiguration(EntityTypeBuilder<Address> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
            this.entityTypeBuilder.HasKey(x => x.Id);
            this.entityTypeBuilder.Ignore(x => x.State);
            this.entityTypeBuilder.Property(x => x.RowVersion).IsRequired();
        }
    }
}
