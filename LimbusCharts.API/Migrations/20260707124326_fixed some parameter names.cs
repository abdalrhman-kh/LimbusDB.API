using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class fixedsomeparameternames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityStaggerThreshold_StaggerThreshold_staggerThresholdsId",
                table: "IdentityStaggerThreshold");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityStaggerThreshold",
                table: "IdentityStaggerThreshold");

            migrationBuilder.DropIndex(
                name: "IX_IdentityStaggerThreshold_staggerThresholdsId",
                table: "IdentityStaggerThreshold");

            migrationBuilder.RenameColumn(
                name: "staggerThresholdsId",
                table: "IdentityStaggerThreshold",
                newName: "StaggerThresholdsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityStaggerThreshold",
                table: "IdentityStaggerThreshold",
                columns: new[] { "StaggerThresholdsId", "identitiesId" });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityStaggerThreshold_identitiesId",
                table: "IdentityStaggerThreshold",
                column: "identitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityStaggerThreshold_StaggerThreshold_StaggerThresholdsId",
                table: "IdentityStaggerThreshold",
                column: "StaggerThresholdsId",
                principalTable: "StaggerThreshold",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityStaggerThreshold_StaggerThreshold_StaggerThresholdsId",
                table: "IdentityStaggerThreshold");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityStaggerThreshold",
                table: "IdentityStaggerThreshold");

            migrationBuilder.DropIndex(
                name: "IX_IdentityStaggerThreshold_identitiesId",
                table: "IdentityStaggerThreshold");

            migrationBuilder.RenameColumn(
                name: "StaggerThresholdsId",
                table: "IdentityStaggerThreshold",
                newName: "staggerThresholdsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityStaggerThreshold",
                table: "IdentityStaggerThreshold",
                columns: new[] { "identitiesId", "staggerThresholdsId" });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityStaggerThreshold_staggerThresholdsId",
                table: "IdentityStaggerThreshold",
                column: "staggerThresholdsId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityStaggerThreshold_StaggerThreshold_staggerThresholdsId",
                table: "IdentityStaggerThreshold",
                column: "staggerThresholdsId",
                principalTable: "StaggerThreshold",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
