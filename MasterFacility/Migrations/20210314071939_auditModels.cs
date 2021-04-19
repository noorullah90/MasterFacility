using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MasterFacility.Migrations
{
    public partial class auditModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auditlogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true),
                    tablename = table.Column<string>(type: "text", nullable: true),
                    datetime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    oldvalues = table.Column<string>(type: "text", nullable: true),
                    newvalues = table.Column<string>(type: "text", nullable: true),
                    affectedcolumns = table.Column<string>(type: "text", nullable: true),
                    primarykey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auditlogs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auditlogs");
        }
    }
}
