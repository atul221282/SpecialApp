using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SpecialApp.Entity;

namespace SpecialApp.Context.Configuration
{
    public abstract class BaseEntityConfiguration<T> where T : BaseEntity
    {
        protected BaseEntityConfiguration(EntityTypeBuilder<T> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);

            //entityTypeBuilder.Property(x => x.Id).ValueGeneratedOnAdd();

            entityTypeBuilder.Property(x => x.IsDeleted).IsRequired();

            entityTypeBuilder.Property(x => x.AuditLastUpdatedBy).HasMaxLength(100).IsRequired();
            entityTypeBuilder.Property(x => x.AuditLastUpdatedDate).IsRequired();

            entityTypeBuilder.Property(x => x.AuditCreatedBy).HasMaxLength(100).IsRequired();
            entityTypeBuilder.Property(x => x.AuditCreatedDate).IsRequired();

            entityTypeBuilder.Ignore(x => x.State);
            entityTypeBuilder.Property(x => x.RowVersion).IsConcurrencyToken().IsRowVersion();
        }
    }
}