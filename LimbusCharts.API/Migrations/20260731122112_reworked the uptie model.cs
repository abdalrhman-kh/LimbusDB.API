using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class reworkedtheuptiemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpTie_Identity_IdentityId",
                table: "UpTie");

            migrationBuilder.DropIndex(
                name: "IX_UpTie_IdentityId",
                table: "UpTie");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "UpTie");

            migrationBuilder.DropColumn(
                name: "MaxSpeed",
                table: "UpTie");

            migrationBuilder.DropColumn(
                name: "MinSpeed",
                table: "UpTie");

            migrationBuilder.AlterColumn<int>(
                name: "StatusType",
                table: "StatusEffect",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "IdentityUpTie",
                columns: table => new
                {
                    IdentityUpTieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinSpeed = table.Column<int>(type: "int", nullable: false),
                    MaxSpeed = table.Column<int>(type: "int", nullable: false),
                    IdentityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpTieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUpTie", x => x.IdentityUpTieId);
                    table.ForeignKey(
                        name: "FK_IdentityUpTie_Identity_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "Identity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUpTie_UpTie_UpTieId",
                        column: x => x.UpTieId,
                        principalTable: "UpTie",
                        principalColumn: "UpTieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUpTie_IdentityId",
                table: "IdentityUpTie",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUpTie_UpTieId",
                table: "IdentityUpTie",
                column: "UpTieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUpTie");

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityId",
                table: "UpTie",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MaxSpeed",
                table: "UpTie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinSpeed",
                table: "UpTie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "StatusType",
                table: "StatusEffect",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UpTie_IdentityId",
                table: "UpTie",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpTie_Identity_IdentityId",
                table: "UpTie",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
