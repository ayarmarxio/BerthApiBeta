using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace BerthApiBeta.Migrations
{
    public partial class EditRecordEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Record");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecordTime",
                table: "Record",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Record",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Long",
                table: "Record",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Record");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecordTime",
                table: "Record",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddColumn<Point>(
                name: "Location",
                table: "Record",
                nullable: true);
        }
    }
}
