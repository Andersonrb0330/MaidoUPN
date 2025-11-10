using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Reserva_camposEliminados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_IdCliente",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdCliente",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Reserva");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteId",
                table: "Reserva",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_ClienteId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Reserva");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Reserva",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdCliente",
                table: "Reserva",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_IdCliente",
                table: "Reserva",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
