using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class userModelsModifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserGrantedProvinces_UserId",
                table: "UserGrantedProvinces",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrantedProvinces_AspNetUsers_UserId",
                table: "UserGrantedProvinces",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGrantedProvinces_AspNetUsers_UserId",
                table: "UserGrantedProvinces");

            migrationBuilder.DropIndex(
                name: "IX_UserGrantedProvinces_UserId",
                table: "UserGrantedProvinces");
        }
    }
}
