using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class wzwOrganizatedmigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizated",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LadingCadre = table.Column<Guid>(nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    ParentNumber = table.Column<string>(nullable: true),
                    Depth = table.Column<int>(nullable: false, defaultValue: 0),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizated", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "45c4ad2e-67d5-4897-ae42-67ca655f1e62", new DateTime(2020, 4, 12, 13, 7, 19, 583, DateTimeKind.Local).AddTicks(9024) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
                columns: new[] { "CreatedTime", "LockoutEnabled" },
                values: new object[] { new DateTime(2020, 4, 12, 13, 7, 19, 608, DateTimeKind.Local).AddTicks(8124), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organizated");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "e55a9f19-5a35-427c-8820-e2ff70c037fe", new DateTime(2020, 4, 2, 21, 38, 54, 312, DateTimeKind.Local).AddTicks(1377) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
                columns: new[] { "CreatedTime", "LockoutEnabled" },
                values: new object[] { new DateTime(2020, 4, 2, 21, 38, 54, 335, DateTimeKind.Local).AddTicks(9511), true });
        }
    }
}
