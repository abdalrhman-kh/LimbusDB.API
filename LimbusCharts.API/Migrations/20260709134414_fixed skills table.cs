using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class fixedskillstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Identity_identityId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SinAffinity_sinAffinityId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "sinAffinityId",
                table: "Skills",
                newName: "SinAffinityId");

            migrationBuilder.RenameColumn(
                name: "identityId",
                table: "Skills",
                newName: "IdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_sinAffinityId",
                table: "Skills",
                newName: "IX_Skills_SinAffinityId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_identityId",
                table: "Skills",
                newName: "IX_Skills_IdentityId");

            migrationBuilder.CreateTable(
                name: "SkillsStatusEffect",
                columns: table => new
                {
                    SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    statusEffectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsStatusEffect", x => new { x.SkillsId, x.statusEffectsId });
                    table.ForeignKey(
                        name: "FK_SkillsStatusEffect_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillsStatusEffect_StatusEffect_statusEffectsId",
                        column: x => x.statusEffectsId,
                        principalTable: "StatusEffect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillsStatusEffect_statusEffectsId",
                table: "SkillsStatusEffect",
                column: "statusEffectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Identity_IdentityId",
                table: "Skills",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SinAffinity_SinAffinityId",
                table: "Skills",
                column: "SinAffinityId",
                principalTable: "SinAffinity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Identity_IdentityId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SinAffinity_SinAffinityId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "SkillsStatusEffect");

            migrationBuilder.RenameColumn(
                name: "SinAffinityId",
                table: "Skills",
                newName: "sinAffinityId");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "Skills",
                newName: "identityId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_SinAffinityId",
                table: "Skills",
                newName: "IX_Skills_sinAffinityId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_IdentityId",
                table: "Skills",
                newName: "IX_Skills_identityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Identity_identityId",
                table: "Skills",
                column: "identityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SinAffinity_sinAffinityId",
                table: "Skills",
                column: "sinAffinityId",
                principalTable: "SinAffinity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
