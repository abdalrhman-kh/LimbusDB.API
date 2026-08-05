using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimbusCharts.API.Migrations
{
    /// <inheritdoc />
    public partial class addedimagetypetoimagetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageType",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "Image");
        }
    }
}
