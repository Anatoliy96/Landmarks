using Microsoft.EntityFrameworkCore.Migrations;

namespace LandmarkDAL.Migrations
{
    public partial class addprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "LandMark",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LandMark",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "LandMark");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LandMark");
        }
    }
}
