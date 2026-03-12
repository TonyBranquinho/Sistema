using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaTerrenoIdRelatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TerrenoId",
                table: "Relatorios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TerrenoId",
                table: "Relatorios");
        }
    }
}
