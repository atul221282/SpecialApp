using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SpecialApp.Context2;

namespace SpecialApp.Context.Migrations
{
    [DbContext(typeof(SpecialContext))]
    [Migration("20170322125930_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SpecialApp.Entity.Companies.Company", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuditCreatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditCreatedDate")
                        .IsRequired();

                    b.Property<string>("AuditLastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditLastUpdatedDate")
                        .IsRequired();

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Details");

                    b.Property<bool?>("IsDeleted")
                        .IsRequired();

                    b.Property<int?>("NumberOfEmployees");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyAddress", b =>
                {
                    b.Property<int>("AddressId");

                    b.Property<int>("CompanyId");

                    b.HasKey("AddressId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyAddress");
                });

            modelBuilder.Entity("SpecialApp.Entity.Special.CompanyFranchise", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("AuditCreatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditCreatedDate")
                        .IsRequired();

                    b.Property<string>("AuditLastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditLastUpdatedDate")
                        .IsRequired();

                    b.Property<bool>("CanContactCustomers");

                    b.Property<bool>("CanGetCustomerDetails");

                    b.Property<bool>("CanSellOnline");

                    b.Property<int>("CompanyFranchiseCategoryId");

                    b.Property<int>("CompanyId");

                    b.Property<string>("ConfirmationToken")
                        .HasMaxLength(250);

                    b.Property<string>("CreatedById")
                        .IsRequired();

                    b.Property<bool>("IsConfirmed");

                    b.Property<bool?>("IsDeleted")
                        .IsRequired();

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyFranchiseCategoryId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CreatedById");

                    b.ToTable("CompanyFranchise");
                });

            modelBuilder.Entity("SpecialApp.Entity.Special.CompanyFranchiseCategory", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuditCreatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditCreatedDate")
                        .IsRequired();

                    b.Property<string>("AuditLastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditLastUpdatedDate")
                        .IsRequired();

                    b.Property<string>("Code")
                        .HasMaxLength(75);

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<bool?>("IsDeleted")
                        .IsRequired();

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("CompanyFranchiseCategory");
                });

            modelBuilder.Entity("SpecialApp.Entity2.Address", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .HasMaxLength(150);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(250);

                    b.Property<string>("AddressState")
                        .HasMaxLength(150);

                    b.Property<int>("AddressTypeId");

                    b.Property<string>("AuditCreatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditCreatedDate")
                        .IsRequired();

                    b.Property<string>("AuditLastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditLastUpdatedDate")
                        .IsRequired();

                    b.Property<string>("City")
                        .HasMaxLength(150);

                    b.Property<int?>("CompanyId");

                    b.Property<int>("CounrtyId");

                    b.Property<int?>("CountryId");

                    b.Property<bool?>("IsDeleted")
                        .IsRequired();

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Province")
                        .HasMaxLength(150);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Suburb")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CountryId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SpecialApp.Entity2.AddressType", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuditCreatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditCreatedDate")
                        .IsRequired();

                    b.Property<string>("AuditLastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditLastUpdatedDate")
                        .IsRequired();

                    b.Property<string>("Code")
                        .HasMaxLength(75);

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<bool?>("IsDeleted")
                        .IsRequired();

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

                    b.Property<string>("AuditCreatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditCreatedDate")
                        .IsRequired();

                    b.Property<string>("AuditLastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTimeOffset?>("AuditLastUpdatedDate")
                        .IsRequired();

                    b.Property<string>("Code")
                        .HasMaxLength(75);

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<bool?>("IsDeleted")
                        .IsRequired();

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("SpecialApp.Entity2.SpecialAppUsers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SpecialApp.Entity2.SpecialAppUsers")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SpecialApp.Entity2.SpecialAppUsers")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpecialApp.Entity2.SpecialAppUsers")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyAddress", b =>
                {
                    b.HasOne("SpecialApp.Entity2.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpecialApp.Entity.Companies.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpecialApp.Entity.Special.CompanyFranchise", b =>
                {
                    b.HasOne("SpecialApp.Entity2.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpecialApp.Entity.Special.CompanyFranchiseCategory", "CompanyFranchiseCategory")
                        .WithMany()
                        .HasForeignKey("CompanyFranchiseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpecialApp.Entity.Companies.Company", "Company")
                        .WithMany("CompanyFranchises")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpecialApp.Entity2.SpecialAppUsers", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpecialApp.Entity2.Address", b =>
                {
                    b.HasOne("SpecialApp.Entity2.AddressType", "AddressType")
                        .WithMany()
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SpecialApp.Entity.Companies.Company")
                        .WithMany("CompanyAddressses")
                        .HasForeignKey("CompanyId");

                    b.HasOne("SpecialApp.Entity2.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });
        }
    }
}
