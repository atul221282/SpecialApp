using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecialApp.Entity.Account;

namespace SpecialApp.Context.Configuration.Account
{
    public class UsersAddressConfiguration
    {
        public UsersAddressConfiguration(EntityTypeBuilder<UsersAddress> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.AddressId, x.UsersId });
        }
    }
}
