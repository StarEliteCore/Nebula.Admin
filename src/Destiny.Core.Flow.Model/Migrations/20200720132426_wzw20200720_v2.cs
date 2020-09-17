using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Destiny.Core.Flow.Model.Migrations
{
    public partial class wzw20200720_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FirstLeader",
                table: "Organizated",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SecondLeader",
                table: "Organizated",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstLeader",
                table: "Organizated");

            migrationBuilder.DropColumn(
                name: "SecondLeader",
                table: "Organizated");
        }
    }
}