using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity;

namespace SpecialApp.Context.Configuration
{
    public abstract class BaseUsersConfiguration<T> : BaseEntityConfiguration<T> where T : BaseUsers
    {
        public BaseUsersConfiguration(EntityTypeBuilder<T> entityTypeBuilder) : base(entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.SpecialAppUsersId).IsRequired();
            entityTypeBuilder.HasIndex(x => x.SpecialAppUsersId).IsUnique();
        }
    }
}
