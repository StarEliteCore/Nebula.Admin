using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class dhg20200616_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "08f674c0-2296-42ff-8df1-b9a0d33a8583", new DateTime(2020, 6, 16, 22, 38, 12, 57, DateTimeKind.Local).AddTicks(3923) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
                columns: new[] { "CreatedTime", "LockoutEnabled" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 38, 12, 95, DateTimeKind.Local).AddTicks(396), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "0335d7b4-90b9-457f-8f8d-13f2e042a228", new DateTime(2020, 6, 16, 22, 21, 5, 611, DateTimeKind.Local).AddTicks(2687) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
                columns: new[] { "CreatedTime", "LockoutEnabled" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 21, 5, 635, DateTimeKind.Local).AddTicks(1257), true });
        }
    }
}