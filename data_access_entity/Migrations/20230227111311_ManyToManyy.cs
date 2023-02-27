using Microsoft.EntityFrameworkCore.Migrations;

namespace data_access_entity.Migrations
{
    public partial class ManyToManyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClientFlight",
                columns: new[] { "ClientId", "FlightId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ClientFlight",
                columns: new[] { "ClientId", "FlightId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientFlight",
                keyColumns: new[] { "ClientId", "FlightId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ClientFlight",
                keyColumns: new[] { "ClientId", "FlightId" },
                keyValues: new object[] { 2, 2 });
        }
    }
}
