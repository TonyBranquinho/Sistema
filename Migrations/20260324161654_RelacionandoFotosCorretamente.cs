using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema.Migrations
{
    /// <inheritdoc />
    public partial class RelacionandoFotosCorretamente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Relatorios_RelatoriosId",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Foto_RelatoriosId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "RelatoriosId",
                table: "Foto");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_RelatorioId",
                table: "Foto",
                column: "RelatorioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Relatorios_RelatorioId",
                table: "Foto",
                column: "RelatorioId",
                principalTable: "Relatorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Relatorios_RelatorioId",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Foto_RelatorioId",
                table: "Foto");

            migrationBuilder.AddColumn<int>(
                name: "RelatoriosId",
                table: "Foto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foto_RelatoriosId",
                table: "Foto",
                column: "RelatoriosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Relatorios_RelatoriosId",
                table: "Foto",
                column: "RelatoriosId",
                principalTable: "Relatorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
