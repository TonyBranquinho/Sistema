using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema.Migrations
{
    /// <inheritdoc />
    public partial class IncluiCidadesTabelaTerrenos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Terrenos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Cidade",
                value: "Joinville");

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Cidade",
                value: "Campo alegre");

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Cidade",
                value: "Sao Francisco do Sul");

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Cidade",
                value: "Joinville");

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Cidade",
                value: "Sao Francisco do Sul");

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Cidade",
                value: "Campo alegre");

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Cidade",
                value: "Joinville");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Terrenos");
        }
    }
}
