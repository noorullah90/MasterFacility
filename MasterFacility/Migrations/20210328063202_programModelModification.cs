using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterFacility.Migrations
{
    public partial class programModelModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programs_donor_donorcode1",
                table: "programs");

            migrationBuilder.DropIndex(
                name: "IX_programs_donorcode1",
                table: "programs");

            migrationBuilder.DropColumn(
                name: "donorcode1",
                table: "programs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "startdate",
                table: "programs",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "enddate",
                table: "programs",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "donorcode",
                table: "programs",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_programs_donorcode",
                table: "programs",
                column: "donorcode");

            migrationBuilder.AddForeignKey(
                name: "FK_programs_donor_donorcode",
                table: "programs",
                column: "donorcode",
                principalTable: "donor",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programs_donor_donorcode",
                table: "programs");

            migrationBuilder.DropIndex(
                name: "IX_programs_donorcode",
                table: "programs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "startdate",
                table: "programs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "enddate",
                table: "programs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "donorcode",
                table: "programs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "donorcode1",
                table: "programs",
                type: "text",
                nullable: true);

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
    }
}
