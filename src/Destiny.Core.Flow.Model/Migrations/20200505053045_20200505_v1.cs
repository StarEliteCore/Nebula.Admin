using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class _20200505_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Depth",
                table: "Menu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "0405f349-855f-462a-ac72-d870bc3c5987", new DateTime(2020, 5, 5, 13, 30, 44, 153, DateTimeKind.Local).AddTicks(7683) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
                columns: new[] { "CreatedTime", "LockoutEnabled" },
                values: new object[] { new DateTime(2020, 5, 5, 13, 30, 44, 184, DateTimeKind.Local).AddTicks(291), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Depth",
                table: "Menu");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "db41a365-7d9f-4c84-a4ad-44723228f392", new DateTime(2020, 4, 21, 22, 34, 39, 954, DateTimeKind.Local).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
                columns: new[] { "CreatedTime", "LockoutEnabled" },
                values: new object[] { new DateTime(2020, 4, 21, 22, 34, 39, 978, DateTimeKind.Local).AddTicks(4634), true });
        }
    }
}
