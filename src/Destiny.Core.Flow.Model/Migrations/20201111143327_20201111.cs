using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class _20201111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Menu",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHide",
                table: "Menu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Layout",
                table: "Menu",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsHide",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "Layout",
                table: "Menu");
        }
    }
}
