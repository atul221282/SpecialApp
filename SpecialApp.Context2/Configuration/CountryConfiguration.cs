using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Context.Configuration;
using SpecialApp.Entity;

namespace SpecialApp.Context.Configuration
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