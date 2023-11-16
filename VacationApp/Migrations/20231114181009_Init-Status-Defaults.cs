using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacationApp.Migrations
{
    /// <inheritdoc />
    public partial class InitStatusDefaults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f03213c-8935-4db4-86eb-beb169ac285d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "889c74f4-caa7-4b83-a741-76ec6fd9671d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afb4b889-333e-4aa0-903d-e7c5b78913a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caee7f37-b21c-4638-9bad-c63bbd15f0ea");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "2f03213c-8935-4db4-86eb-beb169ac285d", null, "Manager", "MANAGER" },
                    { "889c74f4-caa7-4b83-a741-76ec6fd9671d", null, "Employee", "EMPLOYEE" },
                    { "afb4b889-333e-4aa0-903d-e7c5b78913a6", null, "Admin", "ADMIN" },
                    { "caee7f37-b21c-4638-9bad-c63bbd15f0ea", null, "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
