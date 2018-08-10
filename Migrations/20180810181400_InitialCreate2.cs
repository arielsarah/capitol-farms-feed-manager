using Microsoft.EntityFrameworkCore.Migrations;

namespace CapitolFarmsProject.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportTime",
                table: "HorseGrain");

            migrationBuilder.AddColumn<bool>(
                name: "AMReport",
                table: "HorseGrain",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PMReport",
                table: "HorseGrain",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AMReport",
                table: "HorseGrain");

            migrationBuilder.DropColumn(
                name: "PMReport",
                table: "HorseGrain");

            migrationBuilder.AddColumn<int>(
                name: "ReportTime",
                table: "HorseGrain",
                nullable: false,
                defaultValue: 0);
        }
    }
}
