using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpecialApp.Context.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Code = table.Column<string>(maxLength: 75, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 150, nullable: false),
                    Details = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NumberOfEmployees = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFranchiseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Code = table.Column<string>(maxLength: 75, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFranchiseCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Code = table.Column<string>(maxLength: 75, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    ContentType = table.Column<string>(maxLength: 10, nullable: false),
                    Data = table.Column<byte[]>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsMarkedForDeletion = table.Column<bool>(nullable: false),
                    IsUploaded = table.Column<bool>(nullable: false),
                    IsValidFileType = table.Column<bool>(nullable: false),
                    Length = table.Column<int>(nullable: true),
                    OriginalFileName = table.Column<string>(maxLength: 100, nullable: false),
                    Path = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    UniqueFileName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Code = table.Column<string>(maxLength: 75, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(maxLength: 150, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 250, nullable: true),
                    AddressState = table.Column<string>(maxLength: 150, nullable: true),
                    AddressTypeId = table.Column<int>(nullable: false),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    City = table.Column<string>(maxLength: 150, nullable: true),
                    CounrtyId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: false),
                    Province = table.Column<string>(maxLength: 150, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Suburb = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    DOB = table.Column<DateTimeOffset>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SpecialAppUsersId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AspNetUsers_SpecialAppUsersId",
                        column: x => x.SpecialAppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFollowedByUsers",
                columns: table => new
                {
                    SpecialAppUsersId = table.Column<string>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFollowedByUsers", x => new { x.SpecialAppUsersId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_CompanyFollowedByUsers_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyFollowedByUsers_AspNetUsers_SpecialAppUsersId",
                        column: x => x.SpecialAppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddress", x => new { x.AddressId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_CompanyAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyAddress_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFranchise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CanContactCustomers = table.Column<bool>(nullable: false),
                    CanGetCustomerDetails = table.Column<bool>(nullable: false),
                    CanSellOnline = table.Column<bool>(nullable: false),
                    CompanyFranchiseCategoryId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    ConfirmationToken = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedById = table.Column<string>(nullable: true),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFranchise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyFranchise_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyFranchise_CompanyFranchiseCategory_CompanyFranchiseCategoryId",
                        column: x => x.CompanyFranchiseCategoryId,
                        principalTable: "CompanyFranchiseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyFranchise_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyFranchise_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAddress", x => new { x.AddressId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UsersAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersAddress_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UsersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFranchiseFollowedBy",
                columns: table => new
                {
                    SpecialAppUsersId = table.Column<string>(nullable: false),
                    CompanyFranchiseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFranchiseFollowedBy", x => new { x.SpecialAppUsersId, x.CompanyFranchiseId });
                    table.ForeignKey(
                        name: "FK_CompanyFranchiseFollowedBy_CompanyFranchise_CompanyFranchiseId",
                        column: x => x.CompanyFranchiseId,
                        principalTable: "CompanyFranchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyFranchiseFollowedBy_AspNetUsers_SpecialAppUsersId",
                        column: x => x.SpecialAppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFranchiseUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CompanyFranchiseId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UsersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFranchiseUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyFranchiseUsers_CompanyFranchise_CompanyFranchiseId",
                        column: x => x.CompanyFranchiseId,
                        principalTable: "CompanyFranchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyFranchiseUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFranchiseViewed",
                columns: table => new
                {
                    SpecialAppUsersId = table.Column<string>(nullable: false),
                    CompanyFranchiseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFranchiseViewed", x => new { x.SpecialAppUsersId, x.CompanyFranchiseId });
                    table.ForeignKey(
                        name: "FK_CompanyFranchiseViewed_CompanyFranchise_CompanyFranchiseId",
                        column: x => x.CompanyFranchiseId,
                        principalTable: "CompanyFranchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyFranchiseViewed_AspNetUsers_SpecialAppUsersId",
                        column: x => x.SpecialAppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Special",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CompanyFranchiseId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Details = table.Column<string>(maxLength: 1000, nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsAvailableOnline = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProductType = table.Column<string>(nullable: true),
                    PromoCode = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SpecialCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Special", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Special_CompanyFranchise_CompanyFranchiseId",
                        column: x => x.CompanyFranchiseId,
                        principalTable: "CompanyFranchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Special_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Special_SpecialCategory_SpecialCategoryId",
                        column: x => x.SpecialCategoryId,
                        principalTable: "SpecialCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialAddress",
                columns: table => new
                {
                    SpecialId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 100, nullable: true),
                    ContactNumber = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialAddress", x => new { x.SpecialId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_SpecialAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialAddress_Special_SpecialId",
                        column: x => x.SpecialId,
                        principalTable: "Special",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuditCreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditCreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AuditLastUpdatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    AuditLastUpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Comment = table.Column<string>(maxLength: 1000, nullable: true),
                    CommentById = table.Column<string>(nullable: false),
                    CommentDate = table.Column<DateTimeOffset>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ParentCommentId = table.Column<int>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SpecialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialComment_AspNetUsers_CommentById",
                        column: x => x.CommentById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialComment_SpecialComment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "SpecialComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialComment_Special_SpecialId",
                        column: x => x.SpecialId,
                        principalTable: "Special",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialFile",
                columns: table => new
                {
                    SpecialId = table.Column<int>(nullable: false),
                    FileDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialFile", x => new { x.SpecialId, x.FileDataId });
                    table.ForeignKey(
                        name: "FK_SpecialFile_FileData_FileDataId",
                        column: x => x.FileDataId,
                        principalTable: "FileData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialFile_Special_SpecialId",
                        column: x => x.SpecialId,
                        principalTable: "Special",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialLocation",
                columns: table => new
                {
                    SpecialId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialLocation", x => new { x.SpecialId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_SpecialLocation_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialLocation_Special_SpecialId",
                        column: x => x.SpecialId,
                        principalTable: "Special",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialViewed",
                columns: table => new
                {
                    SpecialId = table.Column<int>(nullable: false),
                    ViewedById = table.Column<string>(nullable: false),
                    ViewedDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialViewed", x => new { x.SpecialId, x.ViewedById });
                    table.ForeignKey(
                        name: "FK_SpecialViewed_Special_SpecialId",
                        column: x => x.SpecialId,
                        principalTable: "Special",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialViewed_AspNetUsers_ViewedById",
                        column: x => x.ViewedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpecialAppUsersId",
                table: "Users",
                column: "SpecialAppUsersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersAddress_UsersId",
                table: "UsersAddress",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressTypeId",
                table: "Address",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddress_CompanyId",
                table: "CompanyAddress",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFollowedByUsers_CompanyId",
                table: "CompanyFollowedByUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFranchise_AddressId",
                table: "CompanyFranchise",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFranchise_CompanyFranchiseCategoryId",
                table: "CompanyFranchise",
                column: "CompanyFranchiseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFranchise_CompanyId",
                table: "CompanyFranchise",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFranchise_CreatedById",
                table: "CompanyFranchise",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFranchiseFollowedBy_CompanyFranchiseId",
                table: "CompanyFranchiseFollowedBy",
                column: "CompanyFranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFranchiseUsers_CompanyFranchiseId",
                table: "CompanyFranchiseUsers",
                column: "CompanyFranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFranchiseUsers_UsersId",
                table: "CompanyFranchiseUsers",
                column: "UsersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyFranchiseViewed_CompanyFranchiseId",
                table: "CompanyFranchiseViewed",
                column: "CompanyFranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_CompanyId",
                table: "CompanyUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_UsersId",
                table: "CompanyUsers",
                column: "UsersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Special_CompanyFranchiseId",
                table: "Special",
                column: "CompanyFranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Special_CreatedById",
                table: "Special",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Special_SpecialCategoryId",
                table: "Special",
                column: "SpecialCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialAddress_AddressId",
                table: "SpecialAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialComment_CommentById",
                table: "SpecialComment",
                column: "CommentById");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialComment_ParentCommentId",
                table: "SpecialComment",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialComment_SpecialId",
                table: "SpecialComment",
                column: "SpecialId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialFile_FileDataId",
                table: "SpecialFile",
                column: "FileDataId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialLocation_AddressId",
                table: "SpecialLocation",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialLocation_LocationId",
                table: "SpecialLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialViewed_ViewedById",
                table: "SpecialViewed",
                column: "ViewedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "UsersAddress");

            migrationBuilder.DropTable(
                name: "CompanyAddress");

            migrationBuilder.DropTable(
                name: "CompanyFollowedByUsers");

            migrationBuilder.DropTable(
                name: "CompanyFranchiseFollowedBy");

            migrationBuilder.DropTable(
                name: "CompanyFranchiseUsers");

            migrationBuilder.DropTable(
                name: "CompanyFranchiseViewed");

            migrationBuilder.DropTable(
                name: "CompanyUsers");

            migrationBuilder.DropTable(
                name: "SpecialAddress");

            migrationBuilder.DropTable(
                name: "SpecialComment");

            migrationBuilder.DropTable(
                name: "SpecialFile");

            migrationBuilder.DropTable(
                name: "SpecialLocation");

            migrationBuilder.DropTable(
                name: "SpecialViewed");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FileData");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Special");

            migrationBuilder.DropTable(
                name: "CompanyFranchise");

            migrationBuilder.DropTable(
                name: "SpecialCategory");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "CompanyFranchiseCategory");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
