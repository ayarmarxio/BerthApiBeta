using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace BerthApiBeta.Migrations
{
    public partial class BerthApiBetaModelsBerthApiBetaContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<Point>(nullable: true),
                    RecordTime = table.Column<DateTime>(nullable: false),
                    BPSystolic = table.Column<double>(nullable: true),
                    BPDiastolic = table.Column<double>(nullable: true),
                    BodyTemperature = table.Column<double>(nullable: true),
                    HeartBeatPerSecond = table.Column<int>(nullable: true),
                    Dust = table.Column<double>(nullable: true),
                    Sulphur = table.Column<double>(nullable: true),
                    Nitrogen = table.Column<double>(nullable: true),
                    Fluor = table.Column<double>(nullable: true),
                    CarbonMonoxide = table.Column<double>(nullable: true),
                    Ozone = table.Column<double>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Record_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Record_UserID",
                table: "Record",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
