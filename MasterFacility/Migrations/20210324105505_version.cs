using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MasterFacility.Migrations
{
    public partial class version : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "namedari",
                table: "districts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "districts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "donor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    donortypeid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    namedari = table.Column<string>(type: "text", nullable: true),
                    namepashto = table.Column<string>(type: "text", nullable: true),
                    abbreviation = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "facility",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    districtid = table.Column<int>(type: "integer", nullable: false),
                    facilityypeid = table.Column<int>(type: "integer", nullable: false),
                    facilitytypestartdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    facilitystatusid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    namepashto = table.Column<string>(type: "text", nullable: true),
                    namedari = table.Column<string>(type: "text", nullable: true),
                    shortname = table.Column<string>(type: "text", nullable: true),
                    shortnamedari = table.Column<string>(type: "text", nullable: true),
                    shortnamepashto = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<string>(type: "text", nullable: true),
                    locationdari = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    dateestablished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    closeddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    registrationdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastupdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facility", x => x.id);
                    table.ForeignKey(
                        name: "FK_facility_districts_districtid",
                        column: x => x.districtid,
                        principalTable: "districts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "implementers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    abbreviation = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    namedari = table.Column<string>(type: "text", nullable: true),
                    namepashto = table.Column<string>(type: "text", nullable: true),
                    registerationdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    afghanistanaddress = table.Column<string>(type: "text", nullable: true),
                    otheraddress = table.Column<string>(type: "text", nullable: true),
                    website = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_implementers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programs",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    donorid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    namedari = table.Column<string>(type: "text", nullable: true),
                    namepashto = table.Column<string>(type: "text", nullable: true),
                    startdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    abbreviation = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programs", x => x.code);
                    table.ForeignKey(
                        name: "FK_programs_donor_donorid",
                        column: x => x.donorid,
                        principalTable: "donor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "facilitycontact",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    facilityid = table.Column<int>(type: "integer", nullable: false),
                    positionid = table.Column<int>(type: "integer", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    iscurrent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facilitycontact", x => x.id);
                    table.ForeignKey(
                        name: "FK_facilitycontact_facility_facilityid",
                        column: x => x.facilityid,
                        principalTable: "facility",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "facilitydataset",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    facilityid = table.Column<int>(type: "integer", nullable: false),
                    datasetid = table.Column<int>(type: "integer", nullable: false),
                    startdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facilitydataset", x => x.id);
                    table.ForeignKey(
                        name: "FK_facilitydataset_facility_facilityid",
                        column: x => x.facilityid,
                        principalTable: "facility",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "facilityhumanresources",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    facilityid = table.Column<int>(type: "integer", nullable: false),
                    positionid = table.Column<int>(type: "integer", nullable: false),
                    numberofworkers = table.Column<int>(type: "integer", nullable: false),
                    sequencenumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facilityhumanresources", x => x.id);
                    table.ForeignKey(
                        name: "FK_facilityhumanresources_facility_facilityid",
                        column: x => x.facilityid,
                        principalTable: "facility",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "privatefacilitylicense",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    facilityid = table.Column<int>(type: "integer", nullable: false),
                    ownername = table.Column<string>(type: "text", nullable: true),
                    ownerfathername = table.Column<string>(type: "text", nullable: true),
                    numberofbeds = table.Column<int>(type: "integer", nullable: false),
                    startdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_privatefacilitylicense", x => x.id);
                    table.ForeignKey(
                        name: "FK_privatefacilitylicense_facility_facilityid",
                        column: x => x.facilityid,
                        principalTable: "facility",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grant",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    implementerid = table.Column<int>(type: "integer", nullable: false),
                    programcode = table.Column<string>(type: "text", nullable: true),
                    startdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grant", x => x.code);
                    table.ForeignKey(
                        name: "FK_grant_implementers_implementerid",
                        column: x => x.implementerid,
                        principalTable: "implementers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grant_programs_programcode",
                        column: x => x.programcode,
                        principalTable: "programs",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grantfacility",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    grantid = table.Column<int>(type: "integer", nullable: false),
                    facilityid = table.Column<int>(type: "integer", nullable: false),
                    startdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    iscurrent = table.Column<bool>(type: "boolean", nullable: false),
                    grantcode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grantfacility", x => x.id);
                    table.ForeignKey(
                        name: "FK_grantfacility_facility_facilityid",
                        column: x => x.facilityid,
                        principalTable: "facility",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grantfacility_grant_grantcode",
                        column: x => x.grantcode,
                        principalTable: "grant",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_facility_districtid",
                table: "facility",
                column: "districtid");

            migrationBuilder.CreateIndex(
                name: "IX_facilitycontact_facilityid",
                table: "facilitycontact",
                column: "facilityid");

            migrationBuilder.CreateIndex(
                name: "IX_facilitydataset_facilityid",
                table: "facilitydataset",
                column: "facilityid");

            migrationBuilder.CreateIndex(
                name: "IX_facilityhumanresources_facilityid",
                table: "facilityhumanresources",
                column: "facilityid");

            migrationBuilder.CreateIndex(
                name: "IX_grant_implementerid",
                table: "grant",
                column: "implementerid");

            migrationBuilder.CreateIndex(
                name: "IX_grant_programcode",
                table: "grant",
                column: "programcode");

            migrationBuilder.CreateIndex(
                name: "IX_grantfacility_facilityid",
                table: "grantfacility",
                column: "facilityid");

            migrationBuilder.CreateIndex(
                name: "IX_grantfacility_grantcode",
                table: "grantfacility",
                column: "grantcode");

            migrationBuilder.CreateIndex(
                name: "IX_privatefacilitylicense_facilityid",
                table: "privatefacilitylicense",
                column: "facilityid");

            migrationBuilder.CreateIndex(
                name: "IX_programs_donorid",
                table: "programs",
                column: "donorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "facilitycontact");

            migrationBuilder.DropTable(
                name: "facilitydataset");

            migrationBuilder.DropTable(
                name: "facilityhumanresources");

            migrationBuilder.DropTable(
                name: "grantfacility");

            migrationBuilder.DropTable(
                name: "privatefacilitylicense");

            migrationBuilder.DropTable(
                name: "grant");

            migrationBuilder.DropTable(
                name: "facility");

            migrationBuilder.DropTable(
                name: "implementers");

            migrationBuilder.DropTable(
                name: "programs");

            migrationBuilder.DropTable(
                name: "donor");

            migrationBuilder.AlterColumn<string>(
                name: "namedari",
                table: "districts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "districts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
