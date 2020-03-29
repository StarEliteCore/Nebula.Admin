using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class CreateDataDictionaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataDictionary",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false),
                    Sort = table.Column<int>(nullable: false, defaultValue: 0),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDictionary", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "56bc756f-1c22-43e4-958d-0929fcd998fd", new DateTime(2020, 3, 29, 15, 5, 51, 132, DateTimeKind.Local).AddTicks(2643) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
                columns: new[] { "CreatedTime", "LockoutEnabled" },
                values: new object[] { new DateTime(2020, 3, 29, 15, 5, 51, 155, DateTimeKind.Local).AddTicks(1718), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataDictionary");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "dfcef156-19d3-435c-aa8b-8351f87b2e11", new DateTime(2020, 3, 29, 14, 14, 52, 377, DateTimeKind.Local).AddTicks(3376) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
                columns: new[] { "CreatedTime", "LockoutEnabled" },
                values: new object[] { new DateTime(2020, 3, 29, 14, 14, 52, 401, DateTimeKind.Local).AddTicks(4118), true });
        }
    }
}
