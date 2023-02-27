using Microsoft.EntityFrameworkCore.Migrations;

namespace data_access_entity.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFlight_Flights_FlightsNumber",
                table: "ClientFlight");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientFlight_Passengers_ClientsCredentialsId",
                table: "ClientFlight");

            migrationBuilder.RenameColumn(
                name: "FlightsNumber",
                table: "ClientFlight",
                newName: "FlightId");

            migrationBuilder.RenameColumn(
                name: "ClientsCredentialsId",
                table: "ClientFlight",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientFlight_FlightsNumber",
                table: "ClientFlight",
                newName: "IX_ClientFlight_FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFlight_Flights_FlightId",
                table: "ClientFlight",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFlight_Passengers_ClientId",
                table: "ClientFlight",
                column: "ClientId",
                principalTable: "Passengers",
                principalColumn: "CredentialsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFlight_Flights_FlightId",
                table: "ClientFlight");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientFlight_Passengers_ClientId",
                table: "ClientFlight");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "ClientFlight",
                newName: "FlightsNumber");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ClientFlight",
                newName: "ClientsCredentialsId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientFlight_FlightId",
                table: "ClientFlight",
                newName: "IX_ClientFlight_FlightsNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFlight_Flights_FlightsNumber",
                table: "ClientFlight",
                column: "FlightsNumber",
                principalTable: "Flights",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFlight_Passengers_ClientsCredentialsId",
                table: "ClientFlight",
                column: "ClientsCredentialsId",
                principalTable: "Passengers",
                principalColumn: "CredentialsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
