using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MasterFacility.Migrations
{
    public partial class provincemodelmodification1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_districts_provinces_provincehmisid",
                table: "districts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGrantedProvinces_provinces_Provincehmisid",
                table: "UserGrantedProvinces");

            migrationBuilder.DropIndex(
                name: "IX_UserGrantedProvinces_Provincehmisid",
                table: "UserGrantedProvinces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_provinces",
                table: "provinces");

            migrationBuilder.DropIndex(
                name: "IX_districts_provincehmisid",
                table: "districts");

            migrationBuilder.DropColumn(
                name: "Provincehmisid",
                table: "UserGrantedProvinces");

            migrationBuilder.DropColumn(
                name: "hmisid",
                table: "provinces");

            migrationBuilder.DropColumn(
                name: "hmisid",
                table: "districts");

            migrationBuilder.RenameColumn(
                name: "provincehmisid",
                table: "districts",
                newName: "hmis");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "provinces",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_provinces",
                table: "provinces",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrantedProvinces_ProvinceId",
                table: "UserGrantedProvinces",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_districts_provinceid",
                table: "districts",
                column: "provinceid");

            migrationBuilder.AddForeignKey(
                name: "FK_districts_provinces_provinceid",
                table: "districts",
                column: "provinceid",
                principalTable: "provinces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_districts_provinces_provinceid",
                table: "districts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGrantedProvinces_provinces_ProvinceId",
                table: "UserGrantedProvinces");

            migrationBuilder.DropIndex(
                name: "IX_UserGrantedProvinces_ProvinceId",
                table: "UserGrantedProvinces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_provinces",
                table: "provinces");

            migrationBuilder.DropIndex(
                name: "IX_districts_provinceid",
                table: "districts");

            migrationBuilder.RenameColumn(
                name: "hmis",
                table: "districts",
                newName: "provincehmisid");

            migrationBuilder.AddColumn<string>(
                name: "Provincehmisid",
                table: "UserGrantedProvinces",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "provinces",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "hmisid",
                table: "provinces",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "hmisid",
                table: "districts",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_provinces",
                table: "provinces",
                column: "hmisid");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrantedProvinces_Provincehmisid",
                table: "UserGrantedProvinces",
                column: "Provincehmisid");

            migrationBuilder.CreateIndex(
                name: "IX_districts_provincehmisid",
                table: "districts",
                column: "provincehmisid");

            migrationBuilder.AddForeignKey(
                name: "FK_districts_provinces_provincehmisid",
                table: "districts",
                column: "provincehmisid",
                principalTable: "provinces",
                principalColumn: "hmisid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrantedProvinces_provinces_Provincehmisid",
                table: "UserGrantedProvinces",
                column: "Provincehmisid",
                principalTable: "provinces",
                principalColumn: "hmisid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
