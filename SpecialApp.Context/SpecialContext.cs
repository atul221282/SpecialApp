﻿using Microsoft.EntityFrameworkCore;
using SpecialApp.Context.Configuration;
using SpecialApp.Entity;
using System;

namespace SpecialApp.Context
{
    public class SpecialContext : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server = (localdb)\MSSQLLocalDB; Database = SpecialApp; Trusted_Connection = True;
            ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AddressTypeConfiguration(modelBuilder.Entity<AddressType>());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<AddressType> AddressType { get; set; }
    }
}