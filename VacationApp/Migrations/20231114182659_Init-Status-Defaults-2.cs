using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacationApp.Migrations
{
    /// <inheritdoc />
    public partial class InitStatusDefaults2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cb14689-25ed-4f25-8ba1-b794208e88e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4158d065-756c-40cb-b089-5c0e863a83d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aac94ea6-aef8-4cdf-a914-82f61f2493a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e24d0136-ea59-49c5-9947-089317c13b11");

            migrationBuilder.DeleteData(
                table: "VacationStatus",
                keyColumn: "Id",
                keyValue: "bad5b68d-446f-4cd1-81fc-c9bb7fdf1fb6");

            migrationBuilder.DeleteData(
                table: "VacationStatus",
                keyColumn: "Id",
                keyValue: "e659c5df-01ab-419e-a66f-f990303ead16");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "563ad4ca-980b-4a14-a58c-fa6578934525", null, "Manager", "MANAGER" },
                    { "70c59111-f820-4462-95e5-1795628016c8", null, "SuperAdmin", "SUPERADMIN" },
                    { "9398eb71-2fc1-4e64-93bd-b2f7d875a516", null, "Admin", "ADMIN" },
                    { "e49d3285-40b7-4daa-b08d-b3bc55189045", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "VacationStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0d19c1c8-e8c3-4828-a73a-f746a78fbef2", "Rejected" },
                    { "9bd1926e-03a6-4073-8af9-d0f9de01b911", "Approved" },
                    { "dd73eed3-523f-4104-aa85-0e9adf92dcf9", "Pending" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "563ad4ca-980b-4a14-a58c-fa6578934525");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70c59111-f820-4462-95e5-1795628016c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9398eb71-2fc1-4e64-93bd-b2f7d875a516");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e49d3285-40b7-4daa-b08d-b3bc55189045");

            migrationBuilder.DeleteData(
                table: "VacationStatus",
                keyColumn: "Id",
                keyValue: "0d19c1c8-e8c3-4828-a73a-f746a78fbef2");

            migrationBuilder.DeleteData(
                table: "VacationStatus",
                keyColumn: "Id",
                keyValue: "9bd1926e-03a6-4073-8af9-d0f9de01b911");

            migrationBuilder.DeleteData(
                table: "VacationStatus",
                keyColumn: "Id",
                keyValue: "dd73eed3-523f-4104-aa85-0e9adf92dcf9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cb14689-25ed-4f25-8ba1-b794208e88e0", null, "Manager", "MANAGER" },
                    { "4158d065-756c-40cb-b089-5c0e863a83d0", null, "SuperAdmin", "SUPERADMIN" },
                    { "aac94ea6-aef8-4cdf-a914-82f61f2493a3", null, "Employee", "EMPLOYEE" },
                    { "e24d0136-ea59-49c5-9947-089317c13b11", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "VacationStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "bad5b68d-446f-4cd1-81fc-c9bb7fdf1fb6", "Pending" },
                    { "e659c5df-01ab-419e-a66f-f990303ead16", "Approved" }
                });
        }
    }
}
