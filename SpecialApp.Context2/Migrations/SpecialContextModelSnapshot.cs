using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SpecialApp.Context2;
using SpecialApp.Entity2;

namespace SpecialApp.Context2.Migrations
{
    [DbContext(typeof(SpecialContext))]
    partial class SpecialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpecialApp.Entity2.AddressType", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuditCreatedBy");

                    b.Property<DateTime?>("AuditCreatedDate");

                    b.Property<string>("AuditLastUpdatedBy");

                    b.Property<DateTime?>("AuditLastUpdatedDate");

                    b.Property<string>("Code")
                        .HasMaxLength(75);

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<bool?>("IsDeleted");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("AddressType");
                });
        }
    }
}
