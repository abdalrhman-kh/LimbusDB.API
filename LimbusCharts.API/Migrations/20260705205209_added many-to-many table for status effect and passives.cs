using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class addedmanytomanytableforstatuseffectandpassives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PassivesStatusEffect",
                columns: table => new
                {
                    PassivesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    statusEffectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassivesStatusEffect", x => new { x.PassivesId, x.statusEffectsId });
                    table.ForeignKey(
                        name: "FK_PassivesStatusEffect_Passives_PassivesId",
                        column: x => x.PassivesId,
                        principalTable: "Passives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassivesStatusEffect_StatusEffect_statusEffectsId",
                        column: x => x.statusEffectsId,
                        principalTable: "StatusEffect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassivesStatusEffect_statusEffectsId",
                table: "PassivesStatusEffect",
                column: "statusEffectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassivesStatusEffect");
        }
    }
}
