using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intuitive.Migrations
{
    /// <inheritdoc />
    public partial class CreateAirportGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirportGroups",
                columns: table => new
                {
                    AirportGroupID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportGroups", x => x.AirportGroupID);
                });

            migrationBuilder.CreateTable(
                name: "GeographyLevel1",
                columns: table => new
                {
                    GeographyLevel1Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographyLevel1", x => x.GeographyLevel1Id);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartureAirportId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArrivalAirportId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IataCode = table.Column<string>(type: "TEXT", nullable: true),
                    GeographyLevel1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                    table.ForeignKey(
                        name: "FK_Aiport_GeographyLevel",
                        column: x => x.GeographyLevel1Id,
                        principalTable: "GeographyLevel1",
                        principalColumn: "GeographyLevel1Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirportGroupAssignment",
                columns: table => new
                {
                    AirportGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    AirportId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportGroupAssignment", x => new { x.AirportGroupId, x.AirportId });
                    table.ForeignKey(
                        name: "FK_AirportGroupAssignment_AirportGroups_AirportGroupId",
                        column: x => x.AirportGroupId,
                        principalTable: "AirportGroups",
                        principalColumn: "AirportGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirportGroupAssignment_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirportGroupAssignment_AirportId",
                table: "AirportGroupAssignment",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_GeographyLevel1Id",
                table: "Airports",
                column: "GeographyLevel1Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportGroupAssignment");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "AirportGroups");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "GeographyLevel1");
        }
    }
}
