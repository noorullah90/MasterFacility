using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MasterFacility.Migrations
{
    public partial class provinceModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hmisid = table.Column<string>(type: "text", nullable: true),
                    namedari = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    namepashto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    provinceid = table.Column<int>(type: "integer", nullable: false),
                    hmisid = table.Column<string>(type: "text", nullable: true),
                    namedari = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    namepashto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.id);
                    table.ForeignKey(
                        name: "FK_districts_provinces_provinceid",
                        column: x => x.provinceid,
                        principalTable: "provinces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_districts_provinceid",
                table: "districts",
                column: "provinceid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "provinces");
        }
    }
}
