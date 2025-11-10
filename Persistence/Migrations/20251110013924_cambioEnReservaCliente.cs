using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cambioEnReservaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialCliente_Cliente_IdCliente",
                table: "HistorialCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_IdCliente",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "HistorialCliente",
                newName: "IdReserva");

            migrationBuilder.RenameIndex(
                name: "IX_HistorialCliente_IdCliente",
                table: "HistorialCliente",
                newName: "IX_HistorialCliente_IdReserva");

            migrationBuilder.AddColumn<string>(
                name: "Dni",
                table: "Reserva",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Reserva",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialCliente_Reserva_IdReserva",
                table: "HistorialCliente",
                column: "IdReserva",
                principalTable: "Reserva",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialCliente_Reserva_IdReserva",
                table: "HistorialCliente");

            migrationBuilder.DropColumn(
                name: "Dni",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "IdReserva",
                table: "HistorialCliente",
                newName: "IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_HistorialCliente_IdReserva",
                table: "HistorialCliente",
                newName: "IX_HistorialCliente_IdCliente");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alergias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Preferencias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialCliente_Cliente_IdCliente",
                table: "HistorialCliente",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_IdCliente",
                table: "Pedido",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id");
        }
    }
}
