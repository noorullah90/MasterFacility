using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class lookupmodification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_lookupitems_parentid",
                table: "lookupitems",
                column: "parentid");

            migrationBuilder.AddForeignKey(
                name: "FK_lookupitems_lookupitems_parentid",
                table: "lookupitems",
                column: "parentid",
                principalTable: "lookupitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lookupitems_lookupitems_parentid",
                table: "lookupitems");

            migrationBuilder.DropIndex(
                name: "IX_lookupitems_parentid",
                table: "lookupitems");
        }
    }
}
