﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Context.Configuration;
using SpecialApp.Entity;

namespace SpecialApp.Context.Configuration
{
    public class AddressTypeConfiguration : BaseCodeConfiguration<AddressType>
    {
        private EntityTypeBuilder<AddressType> entityTypeBuilder;

        public AddressTypeConfiguration(EntityTypeBuilder<AddressType> entityTypeBuilder)
            : base(entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}