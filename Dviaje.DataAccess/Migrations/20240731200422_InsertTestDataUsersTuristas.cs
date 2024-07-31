using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dviaje.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InsertTestDataUsersTuristas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "11bc73ce-dbe2-4370-bc92-0d57e5b366d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bc73ce-dbe2-4370-bc92-0d57e5b366d7",
                columns: new[] { "Avatar", "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8YXZhdGFyfGVufDB8fDB8fHww", "ceb1cae2-31de-4856-bad8-c4cdf4eb3dde", "f6caecc2-9b3a-4787-af10-69b13bbef353" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "13825fa6-5c27-4303-ab17-6e13aac24c12", 0, "https://images.unsplash.com/photo-1543610892-0b1f7e6d8ac1?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww", "cb6d1d54-293a-4df9-be22-6cdf3d6d6b49", "Usuario", "fernando@yahoo.com", true, false, null, "FERNANDO@YAHOO.COM", "FERNANDO", null, "3198765432", true, "3d4cf244-4eac-435b-8e1b-89b6836b1b1e", false, "Fernando" },
                    { "1c8e89f7-7db6-4cd5-907d-f01b058cd784", 0, "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8YXZhdGFyfGVufDB8fDB8fHww", "c4e7a59f-4141-4500-93b5-9a550b341de9", "Usuario", "isabella@gmail.com", true, false, null, "ISABELLA@GMAIL.COM", "ISABELLA", null, "3179876543", true, "cd1a47b7-3cff-4b08-98c2-a34603dd01e5", false, "Isabella" },
                    { "230d9aeb-6bca-4faa-b867-2d49e1a8c12e", 0, "https://plus.unsplash.com/premium_photo-1670884441012-c5cf195c062a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8YXZhdGFyfGVufDB8fDB8fHww", "0ec4ef68-ee24-4a8c-beb6-5ee83cef7236", "Usuario", "ana@hotmail.com", true, false, null, "ANA@HOTMAIL.COM", "ANA", null, "3149876543", true, "13f60b3e-9675-47eb-bd49-c02d65eec0bb", false, "Ana" },
                    { "26cfe5c9-00f8-411e-b589-df3405a8b798", 0, "https://plus.unsplash.com/premium_photo-1658527049634-15142565537a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8YXZhdGFyfGVufDB8fDB8fHww", "fc221577-342b-4c71-9e76-d59f4a2837c2", "Usuario", "maria@gmail.com", true, false, null, "MARIA@GMAIL.COM", "MARIA", null, "3101234567", true, "0cbb88d9-3ccb-4792-b737-749e199b2c3b", false, "Maria" },
                    { "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", 0, "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8YXZhdGFyfGVufDB8fDB8fHww", "21e68587-3782-48e4-b767-7c697ebde426", "Usuario", "carlos@yahoo.com", true, false, null, "CARLOS@YAHOO.COM", "CARLOS", null, "3189876543", true, "cbf8a3ce-2c74-4c43-9326-c03e6c93f2ed", false, "Carlos" },
                    { "2e59aa62-61bd-4c8d-9a3d-13f461696eab", 0, "https://images.unsplash.com/photo-1623582854588-d60de57fa33f?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D", "7b9c8b72-abb3-4bc2-a365-a40659859418", "Usuario", "jorge@outlook.com", true, false, null, "JORGE@OUTLOOK.COM", "JORGE", null, "3151234567", true, "6542ee83-d289-4404-a023-4a69defab324", false, "Jorge" },
                    { "3a895383-b546-4693-8246-924a9fc5289f", 0, "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YXZhdGFyfGVufDB8fDB8fHww", "127dc7a5-7f65-42ed-8df2-6ca452ce5438", "Usuario", "luis@outlook.com", true, false, null, "LUIS@OUTLOOK.COM", "LUIS", null, "3112345678", true, "2a215468-0de1-4e88-b85a-385a6ceac830", false, "Luis" },
                    { "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb", 0, "https://images.unsplash.com/photo-1706885093487-7eda37b48a60?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTl8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D", "37904069-60cd-4c94-bac0-a6c9d37fff3d", "Usuario", "gabriela@gmail.com", true, false, null, "GABRIELA@GMAIL.COM", "GABRIELA", null, "3169876543", true, "1edcb2fd-79b7-4dda-acbc-9c32accd1cb6", false, "Gabriela" },
                    { "e4309639-4588-4553-8c14-5ce4426e0dd7", 0, "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8YXZhdGFyfGVufDB8fDB8fHww", "8bb68220-57ec-455d-a264-44388ef85524", "Usuario", "sofia@hotmail.com", true, false, null, "SOFIA@HOTMAIL.COM", "SOFIA", null, "3123456789", true, "8f25e936-03f4-46b2-b6e5-ea6ded0d12bf", false, "Sofia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "13825fa6-5c27-4303-ab17-6e13aac24c12" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "1c8e89f7-7db6-4cd5-907d-f01b058cd784" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "230d9aeb-6bca-4faa-b867-2d49e1a8c12e" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "26cfe5c9-00f8-411e-b589-df3405a8b798" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "2e59aa62-61bd-4c8d-9a3d-13f461696eab" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "3a895383-b546-4693-8246-924a9fc5289f" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "e4309639-4588-4553-8c14-5ce4426e0dd7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "11bc73ce-dbe2-4370-bc92-0d57e5b366d7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "13825fa6-5c27-4303-ab17-6e13aac24c12" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "1c8e89f7-7db6-4cd5-907d-f01b058cd784" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "230d9aeb-6bca-4faa-b867-2d49e1a8c12e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "26cfe5c9-00f8-411e-b589-df3405a8b798" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "2e59aa62-61bd-4c8d-9a3d-13f461696eab" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "3a895383-b546-4693-8246-924a9fc5289f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "e4309639-4588-4553-8c14-5ce4426e0dd7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13825fa6-5c27-4303-ab17-6e13aac24c12");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c8e89f7-7db6-4cd5-907d-f01b058cd784");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "230d9aeb-6bca-4faa-b867-2d49e1a8c12e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26cfe5c9-00f8-411e-b589-df3405a8b798");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e59aa62-61bd-4c8d-9a3d-13f461696eab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a895383-b546-4693-8246-924a9fc5289f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4309639-4588-4553-8c14-5ce4426e0dd7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bc73ce-dbe2-4370-bc92-0d57e5b366d7",
                columns: new[] { "Avatar", "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "https://unsplash.com/es/fotos/hombre-vestido-con-polo-verde-6anudmpILw4", "b8d8f2c7-536c-46e2-8762-e24a6fa6b7d4", "9b831195-c6f3-405e-86b0-7d30f6a6c122" });
        }
    }
}
