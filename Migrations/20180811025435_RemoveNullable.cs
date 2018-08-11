using Microsoft.EntityFrameworkCore.Migrations;

namespace CapitolFarmsProject.Migrations
{
    public partial class RemoveNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorseGrain_Grain_GrainId",
                table: "HorseGrain");

            migrationBuilder.DropForeignKey(
                name: "FK_HorseGrain_Horse_HorseId",
                table: "HorseGrain");

            migrationBuilder.AlterColumn<int>(
                name: "HorseId",
                table: "HorseGrain",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GrainId",
                table: "HorseGrain",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HorseGrain_Grain_GrainId",
                table: "HorseGrain",
                column: "GrainId",
                principalTable: "Grain",
                principalColumn: "GrainId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorseGrain_Horse_HorseId",
                table: "HorseGrain",
                column: "HorseId",
                principalTable: "Horse",
                principalColumn: "HorseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorseGrain_Grain_GrainId",
                table: "HorseGrain");

            migrationBuilder.DropForeignKey(
                name: "FK_HorseGrain_Horse_HorseId",
                table: "HorseGrain");

            migrationBuilder.AlterColumn<int>(
                name: "HorseId",
                table: "HorseGrain",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GrainId",
                table: "HorseGrain",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_HorseGrain_Grain_GrainId",
                table: "HorseGrain",
                column: "GrainId",
                principalTable: "Grain",
                principalColumn: "GrainId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HorseGrain_Horse_HorseId",
                table: "HorseGrain",
                column: "HorseId",
                principalTable: "Horse",
                principalColumn: "HorseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
