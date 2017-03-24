﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SpecialApp.Context;

namespace SpecialApp.Context.Migrations
{
    [DbContext(typeof(SpecialContext))]
    partial class SpecialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("SpecialApp.Entity.Address", b =>
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

                    b.HasIndex("CountryId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SpecialApp.Entity.AddressType", b =>
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

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyFollowedBy", b =>
                {
                    b.Property<string>("SpecialAppUsersId");

                    b.Property<int>("CompanyId");

                    b.HasKey("SpecialAppUsersId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyFollowedByUsers");
                });

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyFranchise", b =>
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

                    b.Property<string>("CreatedById");

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

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyFranchiseCategory", b =>
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

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyFranchiseFollowedBy", b =>
                {
                    b.Property<string>("SpecialAppUsersId");

                    b.Property<int>("CompanyFranchiseId");

                    b.HasKey("SpecialAppUsersId", "CompanyFranchiseId");

                    b.HasIndex("CompanyFranchiseId");

                    b.ToTable("CompanyFranchiseFollowedBy");
                });

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyFranchiseViewed", b =>
                {
                    b.Property<string>("SpecialAppUsersId");

                    b.Property<int>("CompanyFranchiseId");

                    b.HasKey("SpecialAppUsersId", "CompanyFranchiseId");

                    b.HasIndex("CompanyFranchiseId");

                    b.ToTable("CompanyFranchiseViewed");
                });

            modelBuilder.Entity("SpecialApp.Entity.Country", b =>
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

            modelBuilder.Entity("SpecialApp.Entity.FileData", b =>
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

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<byte[]>("Data");

                    b.Property<bool?>("IsDeleted")
                        .IsRequired();

                    b.Property<bool>("IsMarkedForDeletion");

                    b.Property<bool>("IsUploaded");

                    b.Property<bool>("IsValidFileType");

                    b.Property<int?>("Length");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Path");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<string>("UniqueFileName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("FileData");
                });

            modelBuilder.Entity("SpecialApp.Entity.SpecialAppUsers", b =>
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

            modelBuilder.Entity("SpecialApp.Entity.Specials.Special", b =>
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

                    b.Property<int>("CompanyFranchiseId");

                    b.Property<DateTime?>("CreateDate")
                        .IsRequired();

                    b.Property<string>("CreatedById");

                    b.Property<string>("Details")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("EndDate")
                        .IsRequired();

                    b.Property<bool>("IsAvailableOnline");

                    b.Property<bool?>("IsDeleted")
                        .IsRequired();

                    b.Property<string>("ProductType");

                    b.Property<string>("PromoCode");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("SpecialCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyFranchiseId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("SpecialCategoryId");

                    b.ToTable("Special");
                });

            modelBuilder.Entity("SpecialApp.Entity.Specials.SpecialAddress", b =>
                {
                    b.Property<int>("SpecialId");

                    b.Property<int>("AddressId");

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(100);

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(20);

                    b.HasKey("SpecialId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("SpecialAddress");
                });

            modelBuilder.Entity("SpecialApp.Entity.Specials.SpecialCategory", b =>
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

                    b.ToTable("SpecialCategory");
                });

            modelBuilder.Entity("SpecialApp.Entity.Specials.SpecialFile", b =>
                {
                    b.Property<int>("SpecialId");

                    b.Property<int>("FileDataId");

                    b.HasKey("SpecialId", "FileDataId");

                    b.HasIndex("FileDataId");

                    b.ToTable("SpecialFile");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SpecialApp.Entity.SpecialAppUsers")
                        .WithMany("Claims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SpecialApp.Entity.SpecialAppUsers")
                        .WithMany("Logins")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("SpecialApp.Entity.SpecialAppUsers")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SpecialApp.Entity.Address", b =>
                {
                    b.HasOne("SpecialApp.Entity.AddressType", "AddressType")
                        .WithMany()
                        .HasForeignKey("AddressTypeId");

                    b.HasOne("SpecialApp.Entity.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyAddress", b =>
                {
                    b.HasOne("SpecialApp.Entity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("SpecialApp.Entity.Companies.Company", "Company")
                        .WithMany("CompanyAddresses")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyFollowedBy", b =>
                {
                    b.HasOne("SpecialApp.Entity.Companies.Company", "Company")
                        .WithMany("CompanyFollowedBy")
                        .HasForeignKey("CompanyId");

                    b.HasOne("SpecialApp.Entity.SpecialAppUsers", "SpecialAppUsers")
                        .WithMany()
                        .HasForeignKey("SpecialAppUsersId");
                });

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyFranchise", b =>
                {
                    b.HasOne("SpecialApp.Entity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("SpecialApp.Entity.Companies.CompanyFranchiseCategory", "CompanyFranchiseCategory")
                        .WithMany()
                        .HasForeignKey("CompanyFranchiseCategoryId");

                    b.HasOne("SpecialApp.Entity.Companies.Company", "Company")
                        .WithMany("CompanyFranchises")
                        .HasForeignKey("CompanyId");

                    b.HasOne("SpecialApp.Entity.SpecialAppUsers", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyFranchiseFollowedBy", b =>
                {
                    b.HasOne("SpecialApp.Entity.Companies.CompanyFranchise", "CompanyFranchise")
                        .WithMany("CompanyFranchiseFollowedByUsers")
                        .HasForeignKey("CompanyFranchiseId");

                    b.HasOne("SpecialApp.Entity.SpecialAppUsers", "SpecialAppUsers")
                        .WithMany()
                        .HasForeignKey("SpecialAppUsersId");
                });

            modelBuilder.Entity("SpecialApp.Entity.Companies.CompanyFranchiseViewed", b =>
                {
                    b.HasOne("SpecialApp.Entity.Companies.CompanyFranchise", "CompanyFranchise")
                        .WithMany("CompanyFranchiseViewed")
                        .HasForeignKey("CompanyFranchiseId");

                    b.HasOne("SpecialApp.Entity.SpecialAppUsers", "SpecialAppUsers")
                        .WithMany()
                        .HasForeignKey("SpecialAppUsersId");
                });

            modelBuilder.Entity("SpecialApp.Entity.Specials.Special", b =>
                {
                    b.HasOne("SpecialApp.Entity.Companies.CompanyFranchise", "CompanyFranchise")
                        .WithMany("Specials")
                        .HasForeignKey("CompanyFranchiseId");

                    b.HasOne("SpecialApp.Entity.SpecialAppUsers", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("SpecialApp.Entity.Specials.SpecialCategory", "SpecialCategory")
                        .WithMany()
                        .HasForeignKey("SpecialCategoryId");
                });

            modelBuilder.Entity("SpecialApp.Entity.Specials.SpecialAddress", b =>
                {
                    b.HasOne("SpecialApp.Entity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("SpecialApp.Entity.Specials.Special", "Special")
                        .WithMany("SpecialAddresses")
                        .HasForeignKey("SpecialId");
                });

            modelBuilder.Entity("SpecialApp.Entity.Specials.SpecialFile", b =>
                {
                    b.HasOne("SpecialApp.Entity.FileData", "FileData")
                        .WithMany()
                        .HasForeignKey("FileDataId");

                    b.HasOne("SpecialApp.Entity.Specials.Special", "Special")
                        .WithMany("SpecialFiles")
                        .HasForeignKey("SpecialId");
                });
        }
    }
}
