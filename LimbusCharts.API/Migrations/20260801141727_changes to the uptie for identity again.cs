using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class changestotheuptieforidentityagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityIdentityUpTie");

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityId",
                table: "IdentityUpTie",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUpTie_IdentityId",
                table: "IdentityUpTie",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUpTie_Identity_IdentityId",
                table: "IdentityUpTie",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUpTie_Identity_IdentityId",
                table: "IdentityUpTie");

            migrationBuilder.DropIndex(
                name: "IX_IdentityUpTie_IdentityId",
                table: "IdentityUpTie");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "IdentityUpTie");

            migrationBuilder.CreateTable(
                name: "IdentityIdentityUpTie",
                columns: table => new
                {
                    IdentitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityUpTiesIdentityUpTieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityIdentityUpTie", x => new { x.IdentitiesId, x.IdentityUpTiesIdentityUpTieId });
                    table.ForeignKey(
                        name: "FK_IdentityIdentityUpTie_IdentityUpTie_IdentityUpTiesIdentityUpTieId",
                        column: x => x.IdentityUpTiesIdentityUpTieId,
                        principalTable: "IdentityUpTie",
                        principalColumn: "IdentityUpTieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityIdentityUpTie_Identity_IdentitiesId",
                        column: x => x.IdentitiesId,
                        principalTable: "Identity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityIdentityUpTie_IdentityUpTiesIdentityUpTieId",
                table: "IdentityIdentityUpTie",
                column: "IdentityUpTiesIdentityUpTieId");
        }
    }
}
