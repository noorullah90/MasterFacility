using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class Usermodelsmodifaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserGrantedProvinces_ProvinceId",
                table: "UserGrantedProvinces",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrantedProvinces_provinces_ProvinceId",
                table: "UserGrantedProvinces",
                column: "ProvinceId",
                principalTable: "provinces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGrantedProvinces_provinces_ProvinceId",
                table: "UserGrantedProvinces");

            migrationBuilder.DropIndex(
                name: "IX_UserGrantedProvinces_ProvinceId",
                table: "UserGrantedProvinces");
        }
    }
}
