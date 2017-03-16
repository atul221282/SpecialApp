using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity;

namespace SpecialApp.Context.Configuration
{
    public class AddressTypeConfiguration
    {
        private EntityTypeBuilder<AddressType> entityTypeBuilder;
        public AddressTypeConfiguration(EntityTypeBuilder<AddressType> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
            this.entityTypeBuilder.HasKey(x => x.Id);
            this.entityTypeBuilder.Property(x => x.Code).HasMaxLength(75);
            this.entityTypeBuilder.Property(x => x.Description).HasMaxLength(250);
        }
    }
}
