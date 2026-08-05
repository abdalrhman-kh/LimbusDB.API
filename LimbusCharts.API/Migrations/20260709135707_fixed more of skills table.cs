using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class fixedmoreofskillstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillsStatusEffect_StatusEffect_statusEffectsId",
                table: "SkillsStatusEffect");

            migrationBuilder.RenameColumn(
                name: "statusEffectsId",
                table: "SkillsStatusEffect",
                newName: "StatusEffectsId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillsStatusEffect_statusEffectsId",
                table: "SkillsStatusEffect",
                newName: "IX_SkillsStatusEffect_StatusEffectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsStatusEffect_StatusEffect_StatusEffectsId",
                table: "SkillsStatusEffect",
                column: "StatusEffectsId",
                principalTable: "StatusEffect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillsStatusEffect_StatusEffect_StatusEffectsId",
                table: "SkillsStatusEffect");

            migrationBuilder.RenameColumn(
                name: "StatusEffectsId",
                table: "SkillsStatusEffect",
                newName: "statusEffectsId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillsStatusEffect_StatusEffectsId",
                table: "SkillsStatusEffect",
                newName: "IX_SkillsStatusEffect_statusEffectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillsStatusEffect_StatusEffect_statusEffectsId",
                table: "SkillsStatusEffect",
                column: "statusEffectsId",
                principalTable: "StatusEffect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
