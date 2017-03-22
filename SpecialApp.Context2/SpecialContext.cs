using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpecialApp.Context.Configuration;
using SpecialApp.Context.Configuration.Companies;
using SpecialApp.Context.Configuration.Special;
using SpecialApp.Context2.Configuration;
using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Special;
using SpecialApp.Entity2;

namespace SpecialApp.Context2
{
    public class SpecialContext : IdentityDbContext<SpecialAppUsers>
    {
        public SpecialContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO : Read it from options
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = SpecialApp;Timeout=240; 
                                            Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AddressConfiguration(modelBuilder.Entity<Address>());
            new AddressTypeConfiguration(modelBuilder.Entity<AddressType>());
            new CountryConfiguration(modelBuilder.Entity<Country>());
            new CompanyFranchiseCategoryConfiguration(modelBuilder.Entity<CompanyFranchiseCategory>());
            new CompanyFranchiseConfiguration(modelBuilder.Entity<CompanyFranchise>());
            new CompanyConfiguration(modelBuilder.Entity<Company>());
            new CompanyAddressConfiguration(modelBuilder.Entity<CompanyAddress>());
            new CompanyFollowedByUsersConfiguration(modelBuilder.Entity<CompanyFollowedByUsers>());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<CompanyFranchise> CompanyFranchise { get; set; }
        public virtual DbSet<CompanyFranchiseCategory> CompanyFranchiseCategory { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyAddress> CompanyAddress { get; set; }
        public virtual DbSet<CompanyFollowedByUsers> CompanyFollowedByUsers { get; set; }
    }
}
