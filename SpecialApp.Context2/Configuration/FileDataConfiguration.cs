using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Context.Configuration
{
    public class FileDataConfiguration : BaseEntityConfiguration<FileData>
    {
        public FileDataConfiguration(EntityTypeBuilder<FileData> entityTypeBuilder) : base(entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Data)
                .IsRequired(required: false);
            entityTypeBuilder.Property(x => x.ContentType)
                .IsRequired(required: true)
                .HasMaxLength(10);
            entityTypeBuilder.Property(x => x.Title)
                .HasMaxLength(100);
            entityTypeBuilder.Property(x => x.UniqueFileName)
                .IsRequired(required: true)
                .HasMaxLength(100);
            entityTypeBuilder.Property(x => x.OriginalFileName)
                .IsRequired(required: true)
                .HasMaxLength(100);
            entityTypeBuilder.Property(x => x.ContentType)
                .IsRequired(required: true)
                .HasMaxLength(10);
        }
    }
}
