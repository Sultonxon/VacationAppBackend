using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacationApp.Migrations
{
    /// <inheritdoc />
    public partial class Vacation_tabelnullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Vacations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Vacations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05767916-0d2e-4213-ab41-a8319ad1f770", null, "Manager", "MANAGER" },
                    { "4063c0a2-5958-4d67-8859-9998092dad1f", null, "SuperAdmin", "SUPERADMIN" },
                    { "7da78cb3-38b7-4ee3-8fe6-05b5e8a552d5", null, "Admin", "ADMIN" },
                    { "b7e2d488-8de4-4a31-84c5-82312d83fb6c", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "VacationStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "67e156df-5ea2-4fd9-ac44-e2648090c535", "Pending" },
                    { "a724032a-15bb-4398-b274-1b483af18a37", "Rejected" },
                    { "ea1e2a29-7114-479c-a3d5-6e7935618e5a", "Approved" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05767916-0d2e-4213-ab41-a8319ad1f770");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4063c0a2-5958-4d67-8859-9998092dad1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7da78cb3-38b7-4ee3-8fe6-05b5e8a552d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7e2d488-8de4-4a31-84c5-82312d83fb6c");

            migrationBuilder.DeleteData(
                table: "VacationStatus",
                keyColumn: "Id",
                keyValue: "67e156df-5ea2-4fd9-ac44-e2648090c535");

            migrationBuilder.DeleteData(
                table: "VacationStatus",
                keyColumn: "Id",
                keyValue: "a724032a-15bb-4398-b274-1b483af18a37");

            migrationBuilder.DeleteData(
                table: "VacationStatus",
                keyColumn: "Id",
                keyValue: "ea1e2a29-7114-479c-a3d5-6e7935618e5a");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Vacations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Vacations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
