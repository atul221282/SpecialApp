using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Context.Configuration;
using SpecialApp.Entity;

namespace SpecialApp.Context.Configuration
{
    public class AddressConfiguration: BaseEntityConfiguration<Address>
    {
        private EntityTypeBuilder<Address> entityTypeBuilder;

        public AddressConfiguration(EntityTypeBuilder<Address> entityTypeBuilder):base(entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
            this.entityTypeBuilder.Property(x => x.CounrtyId).IsRequired();
            this.entityTypeBuilder.Property(x => x.AddressLine1).HasMaxLength(150);
            this.entityTypeBuilder.Property(x => x.AddressLine2).HasMaxLength(250);
            this.entityTypeBuilder.Property(x => x.AddressState).HasMaxLength(150);
            this.entityTypeBuilder.Property(x => x.City).HasMaxLength(150);
            this.entityTypeBuilder.Property(x => x.Province).HasMaxLength(150);
            this.entityTypeBuilder.Property(x => x.Suburb).HasMaxLength(250);
            this.entityTypeBuilder.Property(x => x.PostalCode).IsRequired().HasMaxLength(10);
        }
    }
}