using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MasterFacility.Migrations
{
    public partial class grantsRelatedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programs_donor_donorcode",
                table: "programs");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_donor",
                table: "donor");

            migrationBuilder.RenameTable(
                name: "donor",
                newName: "donors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_donors",
                table: "donors",
                column: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_programs_donors_donorcode",
                table: "programs",
                column: "donorcode",
                principalTable: "donors",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programs_donors_donorcode",
                table: "programs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_donors",
                table: "donors");

            migrationBuilder.RenameTable(
                name: "donors",
                newName: "donor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_donor",
                table: "donor",
                column: "code");

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descriptions = table.Column<string>(type: "text", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    messagedari = table.Column<string>(type: "text", nullable: true),
                    messagepashto = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    titledari = table.Column<string>(type: "text", nullable: true),
                    titlepashto = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_programs_donor_donorcode",
                table: "programs",
                column: "donorcode",
                principalTable: "donor",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
