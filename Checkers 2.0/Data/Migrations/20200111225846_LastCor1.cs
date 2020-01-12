using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkers_2._0.Data.Migrations
{
    public partial class LastCor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastX",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastY",
                table: "Game",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastX",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "LastY",
                table: "Game");
        }
    }
}
