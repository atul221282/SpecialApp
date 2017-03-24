using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Specials;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration.Specials
{
    public class SpecialCommentConfiguration : BaseEntityConfiguration<SpecialComment>
    {
        public SpecialCommentConfiguration(EntityTypeBuilder<SpecialComment> entityTypeBuilder) : base(entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Comment).HasMaxLength(1000);
        }
    }
}
