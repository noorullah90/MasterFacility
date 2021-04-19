using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class grantModelmodeification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "provinceid",
                table: "grants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_grants_provinceid",
                table: "grants",
                column: "provinceid");

            migrationBuilder.AddForeignKey(
                name: "FK_grants_provinces_provinceid",
                table: "grants",
                column: "provinceid",
                principalTable: "provinces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grants_provinces_provinceid",
                table: "grants");

            migrationBuilder.DropIndex(
                name: "IX_grants_provinceid",
                table: "grants");

            migrationBuilder.DropColumn(
                name: "provinceid",
                table: "grants");
        }
    }
}
