using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dviaje.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAliado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_AspNetUsers_IdAliado",
                table: "Publicaciones");

            migrationBuilder.AlterColumn<string>(
                name: "IdAliado",
                table: "Publicaciones",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Publicaciones",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPublicaciones",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01bfd429-16ea-44b3-902c-794e2c78dfa7",
                columns: new[] { "ConcurrencyStamp", "NumeroPublicaciones", "SecurityStamp" },
                values: new object[] { "48ac916b-d2e1-4517-bbfa-32b3919626bb", 4, "a68887e4-ebff-4163-9278-18f42256f855" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bc73ce-dbe2-4370-bc92-0d57e5b366d7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ea8eb0fe-2ff8-4abb-922d-6fb051848157", "b2d19e2a-3e56-4653-9bbb-4d592452a19a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13825fa6-5c27-4303-ab17-6e13aac24c12",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa1ac6e0-3337-4626-8f35-3057d9052d47", "c8df8103-5038-4f9c-a8e0-c23d17783d13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c8e89f7-7db6-4cd5-907d-f01b058cd784",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b902fc9a-fe73-4240-ab94-1ad5e07f29ba", "bc7baa59-3ba3-46be-8685-d9ef7941903c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "230d9aeb-6bca-4faa-b867-2d49e1a8c12e",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "226ea62d-cdf9-4e8a-a4b6-9db7d202cead", "07c905f5-dca0-49d5-b203-16c00d774fdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26cfe5c9-00f8-411e-b589-df3405a8b798",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "947a1baf-275c-4cc7-a53a-8cac5ded078e", "8a25e872-cdd4-489a-9a75-6563b23e0e35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "429bbe4e-c101-4a78-bed1-5d8485973883", "f8f0768f-85cb-46c6-a2ed-ccf3bcdbadc5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e59aa62-61bd-4c8d-9a3d-13f461696eab",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5493fd29-f935-402b-a3fe-0f9e5ad0d0d0", "33ecc733-6649-4e4d-a647-b1ea0a70108a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39e10980-4df3-494a-bbe7-410e105f6551",
                columns: new[] { "ConcurrencyStamp", "NumeroPublicaciones", "SecurityStamp" },
                values: new object[] { "80b31482-373d-4689-a1a5-dd90c623ec0b", 48, "bcf333d2-570a-4e4a-9cc9-6baa86b8bfbf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a895383-b546-4693-8246-924a9fc5289f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62e5577d-7ffc-4c53-a717-495d5e1d324b", "c7cde0f3-3431-4fc2-88fb-50276bf57921" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4c03648f-7727-4e5c-b096-fcbe3b9e3059",
                columns: new[] { "ConcurrencyStamp", "NumeroPublicaciones", "SecurityStamp" },
                values: new object[] { "a5a6b475-fb49-49ed-ac5d-f0cec47308f8", 7, "b4c230ae-b1dc-4000-bbe9-dcb1f7aef8c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f",
                columns: new[] { "ConcurrencyStamp", "NumeroPublicaciones", "SecurityStamp" },
                values: new object[] { "a19b4b2c-5581-426e-9694-5f6595b51f8d", 7, "5b0acfb2-ff9e-438a-8a11-43288041c669" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b",
                columns: new[] { "ConcurrencyStamp", "NumeroPublicaciones", "SecurityStamp" },
                values: new object[] { "fa02460c-24e7-4c16-aa1b-0eaedf93ba7d", 76, "9608f0c7-99d4-4858-9e4f-dd8517fb96ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8142c33b-ee02-4a13-b0c1-1e941387433d",
                columns: new[] { "ConcurrencyStamp", "NumeroPublicaciones", "SecurityStamp" },
                values: new object[] { "0e7943d4-9a0f-4fee-8dc0-0fe26fccfc1e", 478, "803d29e7-bcda-498b-a9fe-01daadf3eea3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96067e6f-c29b-46ab-9ba1-18ec7b6534f4",
                columns: new[] { "ConcurrencyStamp", "NumeroPublicaciones", "SecurityStamp" },
                values: new object[] { "a816566c-2101-47a6-b253-918226f21b8c", 3, "83474e46-c875-4efd-b8f8-469cd8aae408" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cd842af-b711-44cc-aa5e-3863e3c30b76",
                columns: new[] { "ConcurrencyStamp", "NumeroPublicaciones", "SecurityStamp" },
                values: new object[] { "4a5c447d-3116-493a-a1b5-22aa944ca18b", 445, "21c049b2-dba9-4669-ba30-55a086bf93b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3733288-b354-445d-95da-4c655c3220b3",
                columns: new[] { "ConcurrencyStamp", "NumeroPublicaciones", "SecurityStamp" },
                values: new object[] { "24f6a572-fd27-4210-ba18-7d34725aa089", 8, "8178c4f8-f9de-4243-b3f7-3bf3a6b17993" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c654adef-5f0c-48e6-946a-52706f8ac520",
                columns: new[] { "ConcurrencyStamp", "NumeroPublicaciones", "SecurityStamp" },
                values: new object[] { "84d5045f-95fe-4db3-9b2e-68b08e1a0c79", 89, "be1d021f-40aa-4f03-8cc2-3d4905f44e91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "05944516-3f64-4f56-8065-51cbd5fdd7af", "5df5ee92-adba-44ca-8bf9-488906f5952a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4309639-4588-4553-8c14-5ce4426e0dd7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "61dde8a0-0051-4a7a-a450-34fe6fa93d84", "61d97eff-dc11-4df7-b09c-f57bfbb88acd" });

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_AspNetUsers_IdAliado",
                table: "Publicaciones",
                column: "IdAliado",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_AspNetUsers_IdAliado",
                table: "Publicaciones");

            migrationBuilder.DropColumn(
                name: "NumeroPublicaciones",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "IdAliado",
                table: "Publicaciones",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Publicaciones",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01bfd429-16ea-44b3-902c-794e2c78dfa7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "46eb8e3e-bf8f-4835-a34a-443927604d23", "a1d5ecda-400c-4041-8aad-2f973d6e7e08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11bc73ce-dbe2-4370-bc92-0d57e5b366d7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1fa5f103-4c09-4dd7-a20d-0a7e4efb8d17", "3eb7239f-884c-42f0-94bb-722491dbc8dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13825fa6-5c27-4303-ab17-6e13aac24c12",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "163665e0-223f-4da6-9f7c-6c811b683234", "3655ea6c-b557-470f-a736-9bb212668b03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c8e89f7-7db6-4cd5-907d-f01b058cd784",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "661393e6-f04a-41d2-9e06-b87aaf600fec", "861eaa37-caa8-4d48-b662-07a89ee98089" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "230d9aeb-6bca-4faa-b867-2d49e1a8c12e",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "be455d8b-6d0b-4c9e-8d1e-91dde83b0bfc", "13b6a84f-634b-4307-a971-50d228a1eeda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26cfe5c9-00f8-411e-b589-df3405a8b798",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a42dd6bf-6706-4472-b01c-6265efac4cbe", "7ec0f17b-0cc8-4210-a07d-df8e6a52be01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62ef96c4-415d-4a14-a1a3-e3b996f39e22", "7cf4e31c-f047-48f2-8e45-8aeec4bdc2c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e59aa62-61bd-4c8d-9a3d-13f461696eab",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5986de17-84a6-40f7-a29b-20a5e4017043", "be2b617b-d2f7-4dcc-be9f-b5bd29661f80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39e10980-4df3-494a-bbe7-410e105f6551",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "821d7a3b-feaa-46df-bcbe-e9b838aece9d", "a7280f7b-821e-4ed4-ae84-2ded30bade43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a895383-b546-4693-8246-924a9fc5289f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "171d1f88-99d3-4c42-94c8-3f10a38d4914", "732b4c4b-68ed-4bae-9979-0e4ff9fff0e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4c03648f-7727-4e5c-b096-fcbe3b9e3059",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5bc0b8c4-0b27-4a73-a294-255c93cfdcdb", "bc0bd704-b183-4477-a368-79b56445b183" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "86188469-bb42-4828-9e5c-ff72976cd31c", "4799dd6c-e218-4657-b83d-9bd82176a753" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "56ae6149-cd78-4c58-b272-03d097fc42dd", "a84f0232-e336-49a9-9064-5d42a6bfb838" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8142c33b-ee02-4a13-b0c1-1e941387433d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "69ad1652-1b12-4676-8c3d-60e4dcfbfe25", "d430d8ff-d7ca-44b5-b2e7-a862beddba29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96067e6f-c29b-46ab-9ba1-18ec7b6534f4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1905572-5c4e-43c5-a2a4-19ea04c08722", "1021075e-e9e0-447b-ba28-864a4f407328" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cd842af-b711-44cc-aa5e-3863e3c30b76",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f245e6b0-430d-4a67-9972-7da188fcc940", "55eded71-bff5-4337-8b4d-b13f51486089" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3733288-b354-445d-95da-4c655c3220b3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6de5ea2c-22cc-4e21-a356-d367d4e4b724", "51a92477-97b1-4ec7-bc39-02e6a12d362d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c654adef-5f0c-48e6-946a-52706f8ac520",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c4e8a238-de65-49bb-a221-97c37622c9e0", "427d2445-69a1-4b48-9028-553a511534b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "76dcd80a-96e0-448a-8d3e-8a3f328651e2", "5d182410-2dde-47c3-85e9-5f76ce4ab838" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4309639-4588-4553-8c14-5ce4426e0dd7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c16b5e4b-c5c8-40d7-b751-87f511952a4d", "5c14647d-f7ec-4dca-9b59-1bdc903875eb" });

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_AspNetUsers_IdAliado",
                table: "Publicaciones",
                column: "IdAliado",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
