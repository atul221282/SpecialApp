using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Context.Configuration;
using SpecialApp.Entity2;

namespace SpecialApp.Context2.Configuration
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