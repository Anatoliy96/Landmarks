using Microsoft.EntityFrameworkCore.Migrations;

namespace LandmarksPresentation.Migrations
{
    public partial class name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersID",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsersID",
                table: "Roles",
                column: "UsersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UsersID",
                table: "Roles",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UsersID",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UsersID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UsersID",
                table: "Roles");
        }
    }
}
