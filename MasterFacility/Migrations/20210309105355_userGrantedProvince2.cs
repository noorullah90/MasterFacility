using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class userGrantedProvince2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userGrantedProvinces",
                table: "userGrantedProvinces");

            migrationBuilder.RenameTable(
                name: "userGrantedProvinces",
                newName: "UserGrantedProvinces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGrantedProvinces",
                table: "UserGrantedProvinces",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGrantedProvinces",
                table: "UserGrantedProvinces");

            migrationBuilder.RenameTable(
                name: "UserGrantedProvinces",
                newName: "userGrantedProvinces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userGrantedProvinces",
                table: "userGrantedProvinces",
                column: "Id");
        }
    }
}
