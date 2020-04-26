using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class wzw20200421 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RouterPath",
                table: "Menu",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Iocn",
                table: "Menu",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(50)",
                oldMaxLength: 50);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RouterPath",
                table: "Menu",
                type: "int",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Iocn",
                table: "Menu",
                type: "char(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

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
    }
}
