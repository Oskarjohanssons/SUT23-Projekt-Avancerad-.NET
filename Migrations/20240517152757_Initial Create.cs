using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SUT23_Projekt___Avancerad_.NET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangeHistorys",
                columns: table => new
                {
                    ChangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldAppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewAppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeHistorys", x => x.ChangeID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentLength = table.Column<double>(type: "float", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChangeHistorys",
                columns: new[] { "ChangeID", "AppointmentID", "ChangeType", "NewAppointmentTime", "OldAppointmentTime", "WhenChanged" },
                values: new object[] { 1, 0, "Ombokning", new DateTime(2024, 12, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 10, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyID", "CompanyName" },
                values: new object[] { 1, "SportRehab" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "CustomerAddress", "CustomerEmail", "CustomerName", "CustomerPhone" },
                values: new object[,]
                {
                    { 1, "AborreGatan 5", "Göran@qlok.se", "Göran Nilsson", "0701233214" },
                    { 2, "Bruksvägen 45", "Astrid@qlok.se", "Astrid Johansson", "0723516101" },
                    { 3, "Hjälmvägen 1", "Anna@qlok.se", "Anna Jacobsson", "0723112233" },
                    { 4, "Hjälmvägen 1", "Peo@qlok.se", "Peo Jacobsson", "0723459469" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentID", "AppointmentEnd", "AppointmentLength", "AppointmentName", "AppointmentStart", "CompanyID", "CustomerID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), 0.5, "Snabb besök", new DateTime(2024, 12, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 12, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), 1.0, "Massage", new DateTime(2024, 12, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2024, 12, 14, 5, 0, 0, 0, DateTimeKind.Unspecified), 2.0, "Rehab besök", new DateTime(2024, 12, 14, 4, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CompanyID",
                table: "Appointments",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerID",
                table: "Appointments",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ChangeHistorys");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
