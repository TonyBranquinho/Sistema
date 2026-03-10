using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sistema.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTabelaTerrenos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Terrenos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Proprietaria = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrenos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Terrenos",
                columns: new[] { "Id", "Area", "Matricula", "Nome", "Proprietaria" },
                values: new object[,]
                {
                    { 1L, 5000m, 7L, "Casa do Baixo Quiriri", "Hacasa" },
                    { 2L, 10000m, 6L, "Casa do Alto Quiriri", "Ciser" },
                    { 3L, 1000m, 5L, "Terreno Loteamento Espinheiro", "Hacasa" },
                    { 4L, 5000m, 8L, "Terreno Loteamento Boa Vista", "Ciser" },
                    { 5L, 100m, 3L, "Terreno Loteamento America", "Ciser" },
                    { 6L, 50000m, 2L, "Chacara Campo Alegre", "Parana" },
                    { 7L, 8000m, 1L, "Sede Ciser", "Hacasa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Terrenos");
        }
    }
}
