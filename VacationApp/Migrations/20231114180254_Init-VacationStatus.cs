using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacationApp.Migrations
{
    /// <inheritdoc />
    public partial class InitVacationStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06d53b71-c070-4e1f-9e15-4e667303a03c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09203bfe-66cb-4b0d-9596-1a774181ec5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ae8c68b-c333-47d9-a59e-6cae0c10444c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b1feff9-4439-41ff-849c-e6965ff8c1a4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Vacations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VacationStatusId",
                table: "Vacations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VacationStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationStatus", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_UserId",
                table: "Vacations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_VacationStatusId",
                table: "Vacations",
                column: "VacationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_AspNetUsers_UserId",
                table: "Vacations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_VacationStatus_VacationStatusId",
                table: "Vacations",
                column: "VacationStatusId",
                principalTable: "VacationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_AspNetUsers_UserId",
                table: "Vacations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_VacationStatus_VacationStatusId",
                table: "Vacations");

            migrationBuilder.DropTable(
                name: "VacationStatus");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_UserId",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_VacationStatusId",
                table: "Vacations");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "VacationStatusId",
                table: "Vacations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06d53b71-c070-4e1f-9e15-4e667303a03c", null, "SuperAdmin", "SUPERADMIN" },
                    { "09203bfe-66cb-4b0d-9596-1a774181ec5e", null, "Employee", "EMPLOYEE" },
                    { "4ae8c68b-c333-47d9-a59e-6cae0c10444c", null, "Manager", "MANAGER" },
                    { "9b1feff9-4439-41ff-849c-e6965ff8c1a4", null, "Admin", "ADMIN" }
                });
        }
    }
}
