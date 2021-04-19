using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MasterFacility.Migrations
{
    public partial class lookupModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lookups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    namedari = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    namepashto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lookups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lookupitems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lookupid = table.Column<int>(type: "integer", nullable: false),
                    hmisid = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    namedari = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    namepashto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    parentid = table.Column<int>(type: "integer", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lookupitems", x => x.id);
                    table.ForeignKey(
                        name: "FK_lookupitems_lookups_lookupid",
                        column: x => x.lookupid,
                        principalTable: "lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lookupitems_lookupid",
                table: "lookupitems",
                column: "lookupid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lookupitems");

            migrationBuilder.DropTable(
                name: "lookups");
        }
    }
}
