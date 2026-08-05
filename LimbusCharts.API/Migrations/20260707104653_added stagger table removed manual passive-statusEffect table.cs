using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class addedstaggertableremovedmanualpassivestatusEffecttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "StaggerThreshold",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaggerThreshold", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityStaggerThreshold",
                columns: table => new
                {
                    identitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    staggerThresholdsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityStaggerThreshold", x => new { x.identitiesId, x.staggerThresholdsId });
                    table.ForeignKey(
                        name: "FK_IdentityStaggerThreshold_Identity_identitiesId",
                        column: x => x.identitiesId,
                        principalTable: "Identity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityStaggerThreshold_StaggerThreshold_staggerThresholdsId",
                        column: x => x.staggerThresholdsId,
                        principalTable: "StaggerThreshold",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityStaggerThreshold_staggerThresholdsId",
                table: "IdentityStaggerThreshold",
                column: "staggerThresholdsId");

            migrationBuilder.CreateIndex(
                name: "IX_PassivesStatusEffect_statusEffectsId",
                table: "PassivesStatusEffect",
                column: "statusEffectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityStaggerThreshold");

            migrationBuilder.DropTable(
                name: "PassivesStatusEffect");

            migrationBuilder.DropTable(
                name: "StaggerThreshold");

            migrationBuilder.CreateTable(
                name: "PassivesStatusEffects",
                columns: table => new
                {
                    StatusEffectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassivesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
    }
}
