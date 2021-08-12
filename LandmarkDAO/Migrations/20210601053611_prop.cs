using Microsoft.EntityFrameworkCore.Migrations;

namespace LandmarkDAL.Migrations
{
    public partial class prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "LandMark",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TerrainID",
                table: "LandMark",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "LandMark");

            migrationBuilder.DropColumn(
                name: "TerrainID",
                table: "LandMark");
        }
    }
}
