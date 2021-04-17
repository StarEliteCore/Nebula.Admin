using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class _20210417 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false, comment: "名称"),
                    Sort = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "排序"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父级"),
                    Description = table.Column<string>(type: "varchar(1000) CHARACTER SET utf8mb4", maxLength: 1000, nullable: true, comment: "描述"),
                    LastModifierUserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    LastModifionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否删除"),
                    CreatorUserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentType");
        }
    }
}
