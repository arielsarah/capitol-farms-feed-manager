using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapitolFarmsProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grain",
                columns: table => new
                {
                    GrainId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GrainName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grain", x => x.GrainId);
                });

            migrationBuilder.CreateTable(
                name: "Horse",
                columns: table => new
                {
                    HorseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HorseName = table.Column<string>(nullable: true),
                    Location = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horse", x => x.HorseId);
                });

            migrationBuilder.CreateTable(
                name: "HorseGrain",
                columns: table => new
                {
                    HorseGrainId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(nullable: false),
                    AMReport = table.Column<bool>(nullable: false),
                    PMReport = table.Column<bool>(nullable: false),
                    HorseId = table.Column<int>(nullable: true),
                    GrainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseGrain", x => x.HorseGrainId);
                    table.ForeignKey(
                        name: "FK_HorseGrain_Grain_GrainId",
                        column: x => x.GrainId,
                        principalTable: "Grain",
                        principalColumn: "GrainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorseGrain_Horse_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horse",
                        principalColumn: "HorseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorseGrain_GrainId",
                table: "HorseGrain",
                column: "GrainId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseGrain_HorseId",
                table: "HorseGrain",
                column: "HorseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorseGrain");

            migrationBuilder.DropTable(
                name: "Grain");

            migrationBuilder.DropTable(
                name: "Horse");
        }
    }
}
