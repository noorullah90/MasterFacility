using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class grantModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grant_implementers_implementerid",
                table: "grant");

            migrationBuilder.DropForeignKey(
                name: "FK_grant_programs_programcode",
                table: "grant");

            migrationBuilder.DropForeignKey(
                name: "FK_grantfacility_grant_grantcode",
                table: "grantfacility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_grant",
                table: "grant");

            migrationBuilder.RenameTable(
                name: "grant",
                newName: "grants");

            migrationBuilder.RenameIndex(
                name: "IX_grant_programcode",
                table: "grants",
                newName: "IX_grants_programcode");

            migrationBuilder.RenameIndex(
                name: "IX_grant_implementerid",
                table: "grants",
                newName: "IX_grants_implementerid");

            migrationBuilder.AlterColumn<string>(
                name: "grantcode",
                table: "grantfacility",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_grants",
                table: "grants",
                column: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_grantfacility_grants_grantcode",
                table: "grantfacility",
                column: "grantcode",
                principalTable: "grants",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_grants_implementers_implementerid",
                table: "grants",
                column: "implementerid",
                principalTable: "implementers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grants_programs_programcode",
                table: "grants",
                column: "programcode",
                principalTable: "programs",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grantfacility_grants_grantcode",
                table: "grantfacility");

            migrationBuilder.DropForeignKey(
                name: "FK_grants_implementers_implementerid",
                table: "grants");

            migrationBuilder.DropForeignKey(
                name: "FK_grants_programs_programcode",
                table: "grants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_grants",
                table: "grants");

            migrationBuilder.RenameTable(
                name: "grants",
                newName: "grant");

            migrationBuilder.RenameIndex(
                name: "IX_grants_programcode",
                table: "grant",
                newName: "IX_grant_programcode");

            migrationBuilder.RenameIndex(
                name: "IX_grants_implementerid",
                table: "grant",
                newName: "IX_grant_implementerid");

            migrationBuilder.AlterColumn<string>(
                name: "grantcode",
                table: "grantfacility",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_grant",
                table: "grant",
                column: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_grant_implementers_implementerid",
                table: "grant",
                column: "implementerid",
                principalTable: "implementers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grant_programs_programcode",
                table: "grant",
                column: "programcode",
                principalTable: "programs",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_grantfacility_grant_grantcode",
                table: "grantfacility",
                column: "grantcode",
                principalTable: "grant",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
