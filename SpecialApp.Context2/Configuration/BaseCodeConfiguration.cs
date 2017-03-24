using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration
{
    public abstract class BaseCodeConfiguration<T> : BaseEntityConfiguration<T> where T : BaseCode
    {
        protected BaseCodeConfiguration(EntityTypeBuilder<T> entityTypeBuilder) : base(entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Code).HasMaxLength(75);
            entityTypeBuilder.Property(x => x.Description).HasMaxLength(250);
        }
    }
}
