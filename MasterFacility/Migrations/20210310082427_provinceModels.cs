using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class provinceModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "languages");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "languages",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "languages",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "languages",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_languages",
                table: "languages",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_languages",
                table: "languages");

            migrationBuilder.RenameTable(
                name: "languages",
                newName: "Languages");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Languages",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Languages",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Languages",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");
        }
    }
}
