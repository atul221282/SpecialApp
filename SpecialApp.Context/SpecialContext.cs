using Microsoft.EntityFrameworkCore;
using SpecialApp.Context.Configuration;
using SpecialApp.Entity;
using System;

namespace SpecialApp.Context
{
    public class SpecialContext : DbContext
    {
        public SpecialContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AddressTypeConfiguration(modelBuilder.Entity<AddressType>());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<AddressType> AddressType { get; set; }
    }
}
