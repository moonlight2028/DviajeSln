using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dviaje.DataAccess.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionesRestricciones_Restriccions_IdRestriccion",
                table: "PublicacionesRestricciones");

            migrationBuilder.DropForeignKey(
                name: "FK_serviciosAdicionales_Servicios_IdServicio",
                table: "serviciosAdicionales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_serviciosAdicionales",
                table: "serviciosAdicionales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restriccions",
                table: "Restriccions");

            migrationBuilder.RenameTable(
                name: "serviciosAdicionales",
                newName: "ServiciosAdicionales");

            migrationBuilder.RenameTable(
                name: "Restriccions",
                newName: "Restricciones");

            migrationBuilder.RenameIndex(
                name: "IX_serviciosAdicionales_IdServicio",
                table: "ServiciosAdicionales",
                newName: "IX_ServiciosAdicionales_IdServicio");

            migrationBuilder.AddColumn<int>(
                name: "IdPublicacion",
                table: "ServiciosAdicionales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiciosAdicionales",
                table: "ServiciosAdicionales",
                column: "IdServicioAdicional");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restricciones",
                table: "Restricciones",
                column: "IdRestriccion");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosAdicionales_IdPublicacion",
                table: "ServiciosAdicionales",
                column: "IdPublicacion");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionesRestricciones_Restricciones_IdRestriccion",
                table: "PublicacionesRestricciones",
                column: "IdRestriccion",
                principalTable: "Restricciones",
                principalColumn: "IdRestriccion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiciosAdicionales_Publicaciones_IdPublicacion",
                table: "ServiciosAdicionales",
                column: "IdPublicacion",
                principalTable: "Publicaciones",
                principalColumn: "IdPublicacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiciosAdicionales_Servicios_IdServicio",
                table: "ServiciosAdicionales",
                column: "IdServicio",
                principalTable: "Servicios",
                principalColumn: "IdServicio",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionesRestricciones_Restricciones_IdRestriccion",
                table: "PublicacionesRestricciones");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosAdicionales_Publicaciones_IdPublicacion",
                table: "ServiciosAdicionales");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosAdicionales_Servicios_IdServicio",
                table: "ServiciosAdicionales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiciosAdicionales",
                table: "ServiciosAdicionales");

            migrationBuilder.DropIndex(
                name: "IX_ServiciosAdicionales_IdPublicacion",
                table: "ServiciosAdicionales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restricciones",
                table: "Restricciones");

            migrationBuilder.DropColumn(
                name: "IdPublicacion",
                table: "ServiciosAdicionales");

            migrationBuilder.RenameTable(
                name: "ServiciosAdicionales",
                newName: "serviciosAdicionales");

            migrationBuilder.RenameTable(
                name: "Restricciones",
                newName: "Restriccions");

            migrationBuilder.RenameIndex(
                name: "IX_ServiciosAdicionales_IdServicio",
                table: "serviciosAdicionales",
                newName: "IX_serviciosAdicionales_IdServicio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_serviciosAdicionales",
                table: "serviciosAdicionales",
                column: "IdServicioAdicional");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restriccions",
                table: "Restriccions",
                column: "IdRestriccion");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionesRestricciones_Restriccions_IdRestriccion",
                table: "PublicacionesRestricciones",
                column: "IdRestriccion",
                principalTable: "Restriccions",
                principalColumn: "IdRestriccion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_serviciosAdicionales_Servicios_IdServicio",
                table: "serviciosAdicionales",
                column: "IdServicio",
                principalTable: "Servicios",
                principalColumn: "IdServicio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
