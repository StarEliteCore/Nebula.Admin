using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class _20210505 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Content = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false, comment: "内容"),
                    DocumentTypeId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "文档类型ID"),
                    Title = table.Column<string>(type: "varchar(500) CHARACTER SET utf8mb4", maxLength: 500, nullable: false, comment: "标题"),
                    LastModifierUserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    LastModifionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.DropTable(
                name: "Document");
        }
    }
}
