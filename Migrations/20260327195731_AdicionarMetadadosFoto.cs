using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarMetadadosFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "Localizacao",
                table: "Foto");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFoto",
                table: "Foto",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Foto",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Foto",
                type: "decimal(65,30)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFoto",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Foto");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Foto",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Localizacao",
                table: "Foto",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
