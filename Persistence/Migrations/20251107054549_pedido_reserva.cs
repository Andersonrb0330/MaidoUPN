using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class pedido_reserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Reserva");

            migrationBuilder.AddColumn<string>(
                name: "CorreoElectronico",
                table: "Reserva",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreCompleto",
                table: "Reserva",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Pedido",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorreoElectronico",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "NombreCompleto",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Pedido");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Reserva",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reserva",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
