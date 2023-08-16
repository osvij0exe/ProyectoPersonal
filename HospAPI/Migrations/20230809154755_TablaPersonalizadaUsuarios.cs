using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospAPI.Migrations
{
    /// <inheritdoc />
    public partial class TablaPersonalizadaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5890c3b5-382f-4ff3-abec-5aaabbc0e056",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e764357-10d2-4c58-9657-1a834586ef6c",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4dff315-308f-4591-a06b-a148e37e23f8",
                column: "ConcurrencyStamp",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5890c3b5-382f-4ff3-abec-5aaabbc0e056",
                column: "ConcurrencyStamp",
                value: "8462250e-1a48-405d-889f-b9089b5bf570");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e764357-10d2-4c58-9657-1a834586ef6c",
                column: "ConcurrencyStamp",
                value: "348c334d-27d6-49a1-a650-0f0903ad1655");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4dff315-308f-4591-a06b-a148e37e23f8",
                column: "ConcurrencyStamp",
                value: "2e43b388-4895-4905-ba44-50aef106ea95");
        }
    }
}
