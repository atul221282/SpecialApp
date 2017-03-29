using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SpecialApp.Context.Configuration.Companies;
using SpecialApp.Context.Configuration.Specials;
using SpecialApp.Context.Configuration;
using SpecialApp.Entity.Companies;
using SpecialApp.Entity.Specials;
using SpecialApp.Entity;
using System.Linq;

namespace SpecialApp.Context
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
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            new LocationConfiguration(modelBuilder.Entity<Location>());
            new FileDataConfiguration(modelBuilder.Entity<FileData>());
            new AddressConfiguration(modelBuilder.Entity<Address>());
            new AddressTypeConfiguration(modelBuilder.Entity<AddressType>());
            new CountryConfiguration(modelBuilder.Entity<Country>());
            new CompanyConfiguration(modelBuilder.Entity<Company>());
            new CompanyAddressConfiguration(modelBuilder.Entity<CompanyAddress>());
            new CompanyFollowedByUsersConfiguration(modelBuilder.Entity<CompanyFollowedBy>());

            new CompanyFranchiseCategoryConfiguration(modelBuilder.Entity<CompanyFranchiseCategory>());
            new CompanyFranchiseConfiguration(modelBuilder.Entity<CompanyFranchise>());
            new CompanyFranchiseFollowedByUsersConfiguration(modelBuilder.Entity<CompanyFranchiseFollowedBy>());
            new CompanyFranchiseViewedConfiguration(modelBuilder.Entity<CompanyFranchiseViewed>());

            new SpecialCategoryConfiguration(modelBuilder.Entity<SpecialCategory>());
            new SpecialConfiguration(modelBuilder.Entity<Special>());
            new SpecialAddressConfiguration(modelBuilder.Entity<SpecialAddress>());
            new SpecialFileConfiguration(modelBuilder.Entity<SpecialFile>());
            new SpecialCommentConfiguration(modelBuilder.Entity<SpecialComment>());
            new SpecialViewConfiguration(modelBuilder.Entity<SpecialViewed>());
            new SpecialLocationConfiguration(modelBuilder.Entity<SpecialLocation>());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<FileData> FileData { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyAddress> CompanyAddress { get; set; }
        public virtual DbSet<CompanyFollowedBy> CompanyFollowedByUsers { get; set; }

        public virtual DbSet<CompanyFranchise> CompanyFranchise { get; set; }
        public virtual DbSet<CompanyFranchiseCategory> CompanyFranchiseCategory { get; set; }
        public virtual DbSet<CompanyFranchiseFollowedBy> CompanyFranchiseFollowedBy { get; set; }
        public virtual DbSet<CompanyFranchiseViewed> CompanyFranchiseViewed { get; set; }

        public virtual DbSet<SpecialCategory> SpecialCategory { get; set; }
        public virtual DbSet<Special> Special { get; set; }
        public virtual DbSet<SpecialAddress> SpecialAddress { get; set; }
        public virtual DbSet<SpecialFile> SpecialFile { get; set; }
        public virtual DbSet<SpecialComment> SpecialComment { get; set; }
        public virtual DbSet<SpecialViewed> SpecialView { get; set; }
    }
}
