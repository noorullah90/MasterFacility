using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MasterFacility.Migrations
{
    public partial class donorandprogrammodelsmodification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programs_donor_donorid",
                table: "programs");

            migrationBuilder.DropIndex(
                name: "IX_programs_donorid",
                table: "programs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_donor",
                table: "donor");

            migrationBuilder.DropColumn(
                name: "id",
                table: "donor");

            migrationBuilder.RenameColumn(
                name: "donorid",
                table: "programs",
                newName: "donorcode");

            migrationBuilder.AddColumn<string>(
                name: "donorcode1",
                table: "programs",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "donor",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_donor",
                table: "donor",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_programs_donorcode1",
                table: "programs",
                column: "donorcode1");

            migrationBuilder.AddForeignKey(
                name: "FK_programs_donor_donorcode1",
                table: "programs",
                column: "donorcode1",
                principalTable: "donor",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programs_donor_donorcode1",
                table: "programs");

            migrationBuilder.DropIndex(
                name: "IX_programs_donorcode1",
                table: "programs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_donor",
                table: "donor");

            migrationBuilder.DropColumn(
                name: "donorcode1",
                table: "programs");

            migrationBuilder.RenameColumn(
                name: "donorcode",
                table: "programs",
                newName: "donorid");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "donor",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "donor",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_donor",
                table: "donor",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_programs_donorid",
                table: "programs",
                column: "donorid");

            migrationBuilder.AddForeignKey(
                name: "FK_programs_donor_donorid",
                table: "programs",
                column: "donorid",
                principalTable: "donor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
