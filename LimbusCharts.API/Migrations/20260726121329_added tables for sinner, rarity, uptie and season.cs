using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class addedtablesforsinnerrarityuptieandseason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "Identity");

            migrationBuilder.DropColumn(
                name: "ReleaseSeason",
                table: "Identity");

            migrationBuilder.DropColumn(
                name: "Sinner",
                table: "Identity");

            migrationBuilder.DropColumn(
                name: "UpTie",
                table: "Identity");

            migrationBuilder.AddColumn<Guid>(
                name: "RarityId",
                table: "Identity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SeasonId",
                table: "Identity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SinnerId",
                table: "Identity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpTieId",
                table: "Identity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Rarity",
                columns: table => new
                {
                    RarityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RarityType = table.Column<int>(type: "int", nullable: false),
                    RarityImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarity", x => x.RarityId);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    SeasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeasonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    SeasonImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.SeasonId);
                });

            migrationBuilder.CreateTable(
                name: "Sinner",
                columns: table => new
                {
                    SinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SinnerNumber = table.Column<int>(type: "int", nullable: false),
                    SinnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SinnerSymbolImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinner", x => x.SinnerId);
                });

            migrationBuilder.CreateTable(
                name: "UpTie",
                columns: table => new
                {
                    UpTieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpTieType = table.Column<int>(type: "int", nullable: false),
                    UpTieImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpTie", x => x.UpTieId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identity_RarityId",
                table: "Identity",
                column: "RarityId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_SeasonId",
                table: "Identity",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_SinnerId",
                table: "Identity",
                column: "SinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UpTieId",
                table: "Identity",
                column: "UpTieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_Rarity_RarityId",
                table: "Identity",
                column: "RarityId",
                principalTable: "Rarity",
                principalColumn: "RarityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_Season_SeasonId",
                table: "Identity",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_Sinner_SinnerId",
                table: "Identity",
                column: "SinnerId",
                principalTable: "Sinner",
                principalColumn: "SinnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_UpTie_UpTieId",
                table: "Identity",
                column: "UpTieId",
                principalTable: "UpTie",
                principalColumn: "UpTieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identity_Rarity_RarityId",
                table: "Identity");

            migrationBuilder.DropForeignKey(
                name: "FK_Identity_Season_SeasonId",
                table: "Identity");

            migrationBuilder.DropForeignKey(
                name: "FK_Identity_Sinner_SinnerId",
                table: "Identity");

            migrationBuilder.DropForeignKey(
                name: "FK_Identity_UpTie_UpTieId",
                table: "Identity");

            migrationBuilder.DropTable(
                name: "Rarity");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Sinner");

            migrationBuilder.DropTable(
                name: "UpTie");

            migrationBuilder.DropIndex(
                name: "IX_Identity_RarityId",
                table: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Identity_SeasonId",
                table: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Identity_SinnerId",
                table: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Identity_UpTieId",
                table: "Identity");

            migrationBuilder.DropColumn(
                name: "RarityId",
                table: "Identity");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Identity");

            migrationBuilder.DropColumn(
                name: "SinnerId",
                table: "Identity");

            migrationBuilder.DropColumn(
                name: "UpTieId",
                table: "Identity");

            migrationBuilder.AddColumn<string>(
                name: "Rarity",
                table: "Identity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReleaseSeason",
                table: "Identity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sinner",
                table: "Identity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UpTie",
                table: "Identity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
