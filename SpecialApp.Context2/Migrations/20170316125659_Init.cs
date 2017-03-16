using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecialApp.Context2.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    AuditCreatedBy = table.Column<string>(nullable: true),
                    AuditCreatedDate = table.Column<DateTime>(nullable: true),
                    AuditLastUpdatedBy = table.Column<string>(nullable: true),
                    AuditLastUpdatedDate = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 75, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressType");
        }
    }
}
