using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data_access_entity.Migrations
{
    public partial class OneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFlight_Passengers_ClientsId",
                table: "ClientFlight");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Passengers",
                newName: "CredentialsId");

            migrationBuilder.RenameColumn(
                name: "ClientsId",
                table: "ClientFlight",
                newName: "ClientsCredentialsId");

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credentials_Passengers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Passengers",
                        principalColumn: "CredentialsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "ClientId", "Login", "Password" },
                values: new object[,]
                {
                    { 1, null, "user1", "1111" },
                    { 2, null, "user2", "2222" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "CredentialsId", "Birthdate", "Email", "FirstName" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "victor@gmail.com", "Victor" },
                    { 2, new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "olga@gmail.com", "Olga" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_ClientId",
                table: "Credentials",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFlight_Passengers_ClientsCredentialsId",
                table: "ClientFlight",
                column: "ClientsCredentialsId",
                principalTable: "Passengers",
                principalColumn: "CredentialsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFlight_Passengers_ClientsCredentialsId",
                table: "ClientFlight");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "CredentialsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "CredentialsId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "CredentialsId",
                table: "Passengers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClientsCredentialsId",
                table: "ClientFlight",
                newName: "ClientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFlight_Passengers_ClientsId",
                table: "ClientFlight",
                column: "ClientsId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
