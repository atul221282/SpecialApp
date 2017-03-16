using Microsoft.EntityFrameworkCore;
using SpecialApp.Context2.Configuration;
using SpecialApp.Entity2;

namespace SpecialApp.Context2
{
    public class SpecialContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = SpecialApp; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AddressConfiguration(modelBuilder.Entity<Address>());
            new AddressTypeConfiguration(modelBuilder.Entity<AddressType>());
            new CountryConfiguration(modelBuilder.Entity<Country>());
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
    }
}
