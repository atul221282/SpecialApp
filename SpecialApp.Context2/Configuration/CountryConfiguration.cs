using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Context.Configuration;
using SpecialApp.Entity2;

namespace SpecialApp.Context2.Configuration
{
    public class CountryConfiguration: BaseCodeConfiguration<Country>
    {
        private EntityTypeBuilder<Country> entityTypeBuilder;

        public CountryConfiguration(EntityTypeBuilder<Country> entityTypeBuilder):base(entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}