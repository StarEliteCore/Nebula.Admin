using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class _20200627 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Function");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Function");

            migrationBuilder.DropColumn(
                name: "Controller",
                table: "Function");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Function");

            migrationBuilder.AddColumn<string>(
                name: "LinkUrl",
                table: "Function",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkUrl",
                table: "Function");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Function",
                type: "varchar(500) CHARACTER SET utf8mb4",
                maxLength: 500,
                nullable: true);
        }
    }
}