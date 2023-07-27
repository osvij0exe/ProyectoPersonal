using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospAPI.Migrations
{
    /// <inheritdoc />
    public partial class RolesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5890c3b5-382f-4ff3-abec-5aaabbc0e056", "8462250e-1a48-405d-889f-b9089b5bf570", "Usruaio", "Usuario" },
                    { "6e764357-10d2-4c58-9657-1a834586ef6c", "348c334d-27d6-49a1-a650-0f0903ad1655", "Admin", "Admin" },
                    { "f4dff315-308f-4591-a06b-a148e37e23f8", "2e43b388-4895-4905-ba44-50aef106ea95", "Medico", "Medico" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5890c3b5-382f-4ff3-abec-5aaabbc0e056");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e764357-10d2-4c58-9657-1a834586ef6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4dff315-308f-4591-a06b-a148e37e23f8");
        }
    }
}
