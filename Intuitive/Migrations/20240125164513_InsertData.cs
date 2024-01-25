using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intuitive.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert data into AirportGroups
            migrationBuilder.Sql("INSERT INTO AirportGroups (Name) VALUES ('Domestic Airports')");
            migrationBuilder.Sql("INSERT INTO AirportGroups (Name) VALUES ('International Airports')");

            // Insert data into Airports
            migrationBuilder.Sql("INSERT INTO Airports (IATACode, GeographyLevel1ID, Type) VALUES ('LGW', '1', 'Departure and Arrival')");
            //migrationBuilder.Sql("INSERT INTO Airports (IATACode, GeographyLevel1ID, Type) VALUES ('PMI', '2', 'Arrival Only')");

        }

    }
}
