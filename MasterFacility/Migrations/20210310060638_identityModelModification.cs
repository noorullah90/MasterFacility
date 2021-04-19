using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class identityModelModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "AspNetRoles",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "AspNetRoles");
        }
    }
}
