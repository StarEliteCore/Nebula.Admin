using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class wzw20200624_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuFunction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false),
                    FunctionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuFunction", x => x.Id);
                });

            //migrationBuilder.UpdateData(
            //    table: "Role",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"),
            //    columns: new[] { "ConcurrencyStamp", "CreatedTime" },
            //    values: new object[] { "794cd964-72cd-4d0a-8117-e0a420f55092", new DateTime(2020, 6, 24, 21, 43, 2, 140, DateTimeKind.Local).AddTicks(201) });

            //migrationBuilder.UpdateData(
            //    table: "User",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
            //    columns: new[] { "CreatedTime", "LockoutEnabled" },
            //    values: new object[] { new DateTime(2020, 6, 24, 21, 43, 2, 164, DateTimeKind.Local).AddTicks(4271), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuFunction");

            //migrationBuilder.UpdateData(
            //    table: "Role",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"),
            //    columns: new[] { "ConcurrencyStamp", "CreatedTime" },
            //    values: new object[] { "ab08155c-8dda-40a0-9497-00a7af98a49a", new DateTime(2020, 6, 22, 22, 19, 35, 518, DateTimeKind.Local).AddTicks(6067) });

            //migrationBuilder.UpdateData(
            //    table: "User",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
            //    columns: new[] { "CreatedTime", "LockoutEnabled" },
            //    values: new object[] { new DateTime(2020, 6, 22, 22, 19, 35, 563, DateTimeKind.Local).AddTicks(4407), true });
        }
    }
}