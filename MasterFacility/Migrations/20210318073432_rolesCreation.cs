using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class rolesCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Descriptions", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "79403f5f-c565-4ea9-86b3-6ee698e5f8d7", null, "Admin", "ADMIN" },
                    { 2, "a9119f6b-263a-4f51-9a8a-6f02b701101a", null, "Staff", "STAFF" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
