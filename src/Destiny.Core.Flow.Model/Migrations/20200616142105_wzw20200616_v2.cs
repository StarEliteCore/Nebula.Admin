using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class wzw20200616_v2 : Migration
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

            migrationBuilder.CreateTable(

                name: "Function",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Area = table.Column<string>(maxLength: 25, nullable: true),
                    Controller = table.Column<string>(maxLength: 30, nullable: true),
                    Action = table.Column<string>(maxLength: 30, nullable: true),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsEnabled = table.Column<bool>(nullable: false, defaultValue: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.Id);
                });

            migrationBuilder.CreateTable(

                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Sort = table.Column<int>(nullable: false, defaultValue: 0),
                    Path = table.Column<string>(maxLength: 200, nullable: false),
                    ParentId = table.Column<Guid>(nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentNumber = table.Column<string>(nullable: true),
                    Component = table.Column<string>(maxLength: 400, nullable: false),
                    Depth = table.Column<int>(nullable: false),

                    RouterPath = table.Column<string>(maxLength: 200, nullable: false),

                    Iocn = table.Column<string>(maxLength: 50, nullable: true),

                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),

                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 50, nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 256, nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 500, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 500, nullable: true),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 50, nullable: true),
                    NickName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    NormalizeEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    HeadImg = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false, defaultValue: false),
                    AccessFailedCount = table.Column<int>(nullable: false, defaultValue: 0),
                    IsSystem = table.Column<bool>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: false),
                    ClaimValue = table.Column<string>(nullable: true),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 450, nullable: true),
                    Name = table.Column<string>(maxLength: 450, nullable: true),
                    Value = table.Column<string>(nullable: true),
                    LastModifierUserId = table.Column<Guid>(nullable: true),
                    LastModifierTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatorUserId = table.Column<Guid>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Code", "ConcurrencyStamp", "CreatedTime", "CreatorUserId", "Description", "IsAdmin", "LastModifierTime", "LastModifierUserId", "Name", "NormalizedName" },

                values: new object[] { new Guid("b8551e97-0723-47fc-bd7e-aff35bb1b1e7"), null, "da799575-f785-4e10-86ef-46eb530774a9", new DateTime(2020, 6, 16, 22, 18, 17, 537, DateTimeKind.Local).AddTicks(1488), new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"), "拥有系统上所有有权限请不要删除!", true, null, null, "系统管理员", "系统管理员" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedTime", "CreatorUserId", "Description", "Email", "EmailConfirmed", "HeadImg", "IsSystem", "LastModifierTime", "LastModifierUserId", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizeEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },

                values: new object[] { new Guid("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"), "0286cab6-8a4a-44ed-9a97-86b0506c65c3", new DateTime(2020, 6, 16, 22, 18, 17, 579, DateTimeKind.Local).AddTicks(3868), null, "系统管理员拥有所有权限", null, false, null, true, null, null, true, null, "管理员", null, "ADMIN", "AQAAAAEAACcQAAAAEEPWhHPCHU1i6Z0ayoApKGbPlZUb38RUdJg4QjUcccVhUSto0sRZtLOXfwWUJ+P2Xw==", null, false, "3OWMGQAK5ZTXMSV6OFSGIWWWNIWJ2SX6", 0, false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataDictionary");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Organizated");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "RoleMenu");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");
        }
    }
}