using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMatriculaRelatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Relatorios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Matricula",
                table: "Relatorios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
