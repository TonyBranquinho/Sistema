using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema.Migrations
{
    /// <inheritdoc />
    public partial class CriaBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Matricula",
                value: 767375L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Matricula",
                value: 6537523L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Matricula",
                value: 59375237L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Matricula",
                value: 837539L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Matricula",
                value: 31398375L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Matricula",
                value: 2697867L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Matricula",
                value: 1785L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Matricula",
                value: 7L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Matricula",
                value: 6L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Matricula",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Matricula",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Matricula",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Matricula",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Terrenos",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Matricula",
                value: 1L);
        }
    }
}
