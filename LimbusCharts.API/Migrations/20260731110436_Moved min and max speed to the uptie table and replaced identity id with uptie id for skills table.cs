using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class Movedminandmaxspeedtotheuptietableandreplacedidentityidwithuptieidforskillstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identity_UpTie_UpTieId",
                table: "Identity");

            migrationBuilder.DropForeignKey(
                name: "FK_Passives_Identity_identityId",
                table: "Passives");

            migrationBuilder.DropForeignKey(
                name: "FK_SinAffinityCount_SinAffinity_sinAffinityId",
                table: "SinAffinityCount");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Identity_IdentityId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_IdentityId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Identity_UpTieId",
                table: "Identity");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Identity_Id",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SinAffinity_Id",
                table: "SinAffinityCount");

            migrationBuilder.DropColumn(
                name: "Identity_Id",
                table: "Passives");

            migrationBuilder.DropColumn(
                name: "MaxSpeed",
                table: "Identity");

            migrationBuilder.DropColumn(
                name: "MinSpeed",
                table: "Identity");

            migrationBuilder.DropColumn(
                name: "UpTieId",
                table: "Identity");

            migrationBuilder.RenameColumn(
                name: "SinAffinity_Id",
                table: "Skills",
                newName: "UpTieId");

            migrationBuilder.RenameColumn(
                name: "sinAffinityId",
                table: "SinAffinityCount",
                newName: "SinAffinityId");

            migrationBuilder.RenameIndex(
                name: "IX_SinAffinityCount_sinAffinityId",
                table: "SinAffinityCount",
                newName: "IX_SinAffinityCount_SinAffinityId");

            migrationBuilder.RenameColumn(
                name: "identityId",
                table: "Passives",
                newName: "IdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_Passives_identityId",
                table: "Passives",
                newName: "IX_Passives_IdentityId");

            migrationBuilder.RenameColumn(
                name: "UpTieImage",
                table: "Identity",
                newName: "UpTieImage_2");

            migrationBuilder.AlterColumn<string>(
                name: "UpTieImageURL",
                table: "UpTie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AddColumn<string>(
                name: "UpTieImage_1",
                table: "Identity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UpTie_IdentityId",
                table: "UpTie",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UpTieId",
                table: "Skills",
                column: "UpTieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passives_Identity_IdentityId",
                table: "Passives",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SinAffinityCount_SinAffinity_SinAffinityId",
                table: "SinAffinityCount",
                column: "SinAffinityId",
                principalTable: "SinAffinity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_UpTie_UpTieId",
                table: "Skills",
                column: "UpTieId",
                principalTable: "UpTie",
                principalColumn: "UpTieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpTie_Identity_IdentityId",
                table: "UpTie",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passives_Identity_IdentityId",
                table: "Passives");

            migrationBuilder.DropForeignKey(
                name: "FK_SinAffinityCount_SinAffinity_SinAffinityId",
                table: "SinAffinityCount");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_UpTie_UpTieId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_UpTie_Identity_IdentityId",
                table: "UpTie");

            migrationBuilder.DropIndex(
                name: "IX_UpTie_IdentityId",
                table: "UpTie");

            migrationBuilder.DropIndex(
                name: "IX_Skills_UpTieId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "UpTie");

            migrationBuilder.DropColumn(
                name: "MaxSpeed",
                table: "UpTie");

            migrationBuilder.DropColumn(
                name: "MinSpeed",
                table: "UpTie");

            migrationBuilder.DropColumn(
                name: "UpTieImage_1",
                table: "Identity");

            migrationBuilder.RenameColumn(
                name: "UpTieId",
                table: "Skills",
                newName: "SinAffinity_Id");

            migrationBuilder.RenameColumn(
                name: "SinAffinityId",
                table: "SinAffinityCount",
                newName: "sinAffinityId");

            migrationBuilder.RenameIndex(
                name: "IX_SinAffinityCount_SinAffinityId",
                table: "SinAffinityCount",
                newName: "IX_SinAffinityCount_sinAffinityId");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "Passives",
                newName: "identityId");

            migrationBuilder.RenameIndex(
                name: "IX_Passives_IdentityId",
                table: "Passives",
                newName: "IX_Passives_identityId");

            migrationBuilder.RenameColumn(
                name: "UpTieImage_2",
                table: "Identity",
                newName: "UpTieImage");

            migrationBuilder.AlterColumn<string>(
                name: "UpTieImageURL",
                table: "UpTie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Identity_Id",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SinAffinity_Id",
                table: "SinAffinityCount",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Identity_Id",
                table: "Passives",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "MaxSpeed",
                table: "Identity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinSpeed",
                table: "Identity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UpTieId",
                table: "Identity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IdentityId",
                table: "Skills",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_UpTieId",
                table: "Identity",
                column: "UpTieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_UpTie_UpTieId",
                table: "Identity",
                column: "UpTieId",
                principalTable: "UpTie",
                principalColumn: "UpTieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passives_Identity_identityId",
                table: "Passives",
                column: "identityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SinAffinityCount_SinAffinity_sinAffinityId",
                table: "SinAffinityCount",
                column: "sinAffinityId",
                principalTable: "SinAffinity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Identity_IdentityId",
                table: "Skills",
                column: "IdentityId",
                principalTable: "Identity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
