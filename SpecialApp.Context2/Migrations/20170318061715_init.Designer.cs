using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SpecialApp.Context2;

namespace SpecialApp.Context.Migrations
{
    [DbContext(typeof(SpecialContext))]
    [Migration("20170318061715_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpecialApp.Entity2.Address", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressState");

                    b.Property<int?>("AddressTypeId");

                    b.Property<string>("AuditCreatedBy");

                    b.Property<DateTime?>("AuditCreatedDate");

                    b.Property<string>("AuditLastUpdatedBy");

                    b.Property<DateTime?>("AuditLastUpdatedDate");

                    b.Property<string>("City");

                    b.Property<int?>("CountryId");

                    b.Property<bool?>("IsDeleted");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Province");

                    b.Property<byte[]>("RowVersion")
                        .IsRequired();

                    b.Property<string>("Suburb");

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.HasIndex("CountryId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SpecialApp.Entity2.AddressType", b =>
                {
                    b.Property<int?>("Id")
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

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("AddressType");
                });

            modelBuilder.Entity("SpecialApp.Entity2.Country", b =>
                {
                    b.Property<int?>("Id")
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

                    b.Property<byte[]>("RowVersion")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("SpecialApp.Entity2.Address", b =>
                {
                    b.HasOne("SpecialApp.Entity2.AddressType", "AddressType")
                        .WithMany()
                        .HasForeignKey("AddressTypeId");

                    b.HasOne("SpecialApp.Entity2.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });
        }
    }
}
