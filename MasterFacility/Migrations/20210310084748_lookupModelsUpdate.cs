using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class lookupModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "lookups",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "lookups",
                newName: "Id");
        }
    }
}
