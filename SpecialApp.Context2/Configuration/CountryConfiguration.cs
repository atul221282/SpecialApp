

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity2;

namespace SpecialApp.Context2.Configuration
{
    public class CountryConfiguration
    {
        private EntityTypeBuilder<Country> entityTypeBuilder;
        public CountryConfiguration(EntityTypeBuilder<Country> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
            this.entityTypeBuilder.HasKey(x => x.Id);
            this.entityTypeBuilder.Property(x => x.Code).HasMaxLength(75);
            this.entityTypeBuilder.Property(x => x.Description).HasMaxLength(250);
            this.entityTypeBuilder.Ignore(x => x.State);
            this.entityTypeBuilder.Property(x => x.RowVersion).IsRequired();
        }
    }
}
