using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dviaje.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TestInsertTurista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", null, "Turista", "TURISTA" },
                    { "4751f532-04d5-497f-b48d-b9e26bcffe6f", null, "Moderador", "MODERADOR" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", null, "Aliado", "ALIADO" },
                    { "e5cd3d4a-2687-49cd-b57c-c8eddfbf2e19", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", 0, "https://unsplash.com/es/fotos/hombre-vestido-con-polo-verde-6anudmpILw4", "b8d8f2c7-536c-46e2-8762-e24a6fa6b7d4", "Usuario", "andres@gmail.com", true, false, null, "ANDRES@GMAIL.COM", "ANDRES", null, "3159725595", true, "9b831195-c6f3-405e-86b0-7d30f6a6c122", false, "Andres" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1717add7-89b4-4bf7-990f-a9f10f18aa39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4751f532-04d5-497f-b48d-b9e26bcffe6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5cd3d4a-2687-49cd-b57c-c8eddfbf2e19");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bc73ce-dbe2-4370-bc92-0d57e5b366d7");
        }
    }
}
