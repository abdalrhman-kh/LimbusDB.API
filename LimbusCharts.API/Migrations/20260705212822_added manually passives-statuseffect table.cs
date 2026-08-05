using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class addedmanuallypassivesstatuseffecttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassivesStatusEffect");

            migrationBuilder.CreateTable(
                name: "PassivesStatusEffects",
                columns: table => new
                {
                    PassivesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusEffectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassivesStatusEffects", x => new { x.StatusEffectId, x.PassivesId });
                    table.ForeignKey(
                        name: "FK_PassivesStatusEffects_Passives_PassivesId",
                        column: x => x.PassivesId,
                        principalTable: "Passives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassivesStatusEffects_StatusEffect_StatusEffectId",
                        column: x => x.StatusEffectId,
                        principalTable: "StatusEffect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassivesStatusEffects_PassivesId",
                table: "PassivesStatusEffects",
                column: "PassivesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassivesStatusEffects");

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
    }
}
