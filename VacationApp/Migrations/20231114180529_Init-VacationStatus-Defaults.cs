using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacationApp.Migrations
{
    /// <inheritdoc />
    public partial class InitVacationStatusDefaults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "576b72b6-198c-427a-a02e-976775291d49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c5cb4bb-974b-4e8e-af4a-158328bc6581");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70316a7e-ee3e-4b66-8559-aa34c1e14bfd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9fd945-ad58-457b-b5bb-9801b9b355fd");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "576b72b6-198c-427a-a02e-976775291d49", null, "Manager", "MANAGER" },
                    { "5c5cb4bb-974b-4e8e-af4a-158328bc6581", null, "SuperAdmin", "SUPERADMIN" },
                    { "70316a7e-ee3e-4b66-8559-aa34c1e14bfd", null, "Employee", "EMPLOYEE" },
                    { "ba9fd945-ad58-457b-b5bb-9801b9b355fd", null, "Admin", "ADMIN" }
                });
        }
    }
}
