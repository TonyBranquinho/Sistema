using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sistema.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Terrenos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Proprietaria = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrenos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SenhaHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TerrenoId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatorios_Terrenos_TerrenoId",
                        column: x => x.TerrenoId,
                        principalTable: "Terrenos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relatorios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeArquivo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Localizacao = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    RelatorioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foto_Relatorios_RelatorioId",
                        column: x => x.RelatorioId,
                        principalTable: "Relatorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Terrenos",
                columns: new[] { "Id", "Area", "Cidade", "Matricula", "Nome", "Proprietaria" },
                values: new object[,]
                {
                    { 1, 5000m, "Joinville", 767375, "Casa do Baixo Quiriri", "Hacasa" },
                    { 2, 10000m, "Campo alegre", 6537523, "Casa do Alto Quiriri", "Ciser" },
                    { 3, 1000m, "Sao Francisco do Sul", 59375237, "Terreno Loteamento Espinheiro", "Hacasa" },
                    { 4, 5000m, "Joinville", 837539, "Terreno Loteamento Boa Vista", "Ciser" },
                    { 5, 100m, "Sao Francisco do Sul", 31398375, "Terreno Loteamento America", "Ciser" },
                    { 6, 50000m, "Campo alegre", 2697867, "Chacara Campo Alegre", "Parana" },
                    { 7, 8000m, "Joinville", 1785, "Sede Ciser", "Hacasa" },
                    { 8, 12000m, "Londrina", 2451, "Fazenda Boa Vista", "AgroSul" },
                    { 9, 4500m, "Maringá", 3124, "Sítio Recanto Verde", "VerdeVale" },
                    { 10, 3000m, "Curitiba", 1987, "Chácara Santa Luzia", "Família Souza" },
                    { 11, 25000m, "Campo Grande", 5562, "Fazenda Horizonte", "TerraNova" },
                    { 12, 5200m, "Guarapuava", 2874, "Sítio Bela Serra", "SerraAlta" },
                    { 13, 3800m, "Ponta Grossa", 3345, "Chácara Vale do Sol", "ValeSul" },
                    { 14, 18000m, "Cascavel", 6721, "Fazenda Três Rios", "AgroRios" },
                    { 15, 6100m, "Blumenau", 4210, "Sítio Pedra Branca", "PedraSul" },
                    { 16, 2900m, "Florianópolis", 3891, "Chácara Primavera", "Primavera Ltda" },
                    { 17, 22000m, "Dourados", 7453, "Fazenda Alto Alegre", "Alto Agro" },
                    { 18, 4700m, "Uberlândia", 2987, "Sítio Campo Belo", "Campo Forte" },
                    { 19, 3500m, "Ribeirão Preto", 3654, "Chácara Estrela do Sul", "Estrela Agro" },
                    { 20, 27000m, "Goiânia", 8123, "Fazenda Santa Helena", "Helena Agropecuária" },
                    { 21, 5400m, "Chapecó", 2765, "Sítio Água Clara", "Água Viva" },
                    { 22, 4100m, "Poços de Caldas", 3498, "Chácara Monte Verde", "Monte Verde Ltda" },
                    { 23, 31000m, "Uberaba", 9231, "Fazenda Ouro Branco", "Ouro Agro" },
                    { 24, 4800m, "Joinville", 2574, "Sítio Lago Azul", "Lago Azul Ltda" },
                    { 25, 3300m, "Sorocaba", 3189, "Chácara Boa Esperança", "Esperança Rural" },
                    { 26, 29000m, "Palmas", 8675, "Fazenda Santa Rita", "Santa Rita Agro" },
                    { 27, 5600m, "Nova Friburgo", 2999, "Sítio Encanto da Serra", "Encanto Verde" },
                    { 28, 21000m, "Sinop", 9342, "Fazenda Rio Dourado", "Rio Agro" },
                    { 29, 4300m, "Itu", 2781, "Sítio Bela Vista", "Bela Vista Rural" },
                    { 30, 3200m, "Jundiaí", 3567, "Chácara Recanto Feliz", "Recanto Ltda" },
                    { 31, 26000m, "Rondonópolis", 8452, "Fazenda Santa Clara", "Santa Clara Agro" },
                    { 32, 5100m, "Passo Fundo", 2643, "Sítio Vale Verde", "Vale Verde Ltda" },
                    { 33, 3700m, "Campinas", 3894, "Chácara Sol Nascente", "Sol Nascente Agro" },
                    { 34, 28000m, "Três Lagoas", 9021, "Fazenda Três Lagoas", "Lagoas Agro" },
                    { 35, 4900m, "Domingos Martins", 2956, "Sítio Pedra Azul", "Pedra Azul Ltda" },
                    { 36, 3400m, "Atibaia", 3722, "Chácara Vale Encantado", "Encanto Rural" },
                    { 37, 30000m, "Barreiras", 9784, "Fazenda Boa Esperança", "Boa Esperança Agro" },
                    { 38, 4600m, "São José dos Pinhais", 2819, "Sítio Água Verde", "Água Verde Ltda" },
                    { 39, 3600m, "Anápolis", 3475, "Chácara Serra Dourada", "Serra Dourada Agro" },
                    { 40, 27000m, "Campo Grande", 8891, "Fazenda Campo Grande", "Campo Grande Agro" },
                    { 41, 5200m, "Lages", 2637, "Sítio Vista Alegre", "Vista Alegre Rural" },
                    { 42, 3100m, "Araraquara", 3588, "Chácara Morada do Sol", "Morada Ltda" },
                    { 43, 24000m, "Cuiabá", 8129, "Fazenda Santa Tereza", "Santa Tereza Agro" },
                    { 44, 4800m, "Holambra", 2991, "Sítio Recanto das Flores", "Flores do Campo" },
                    { 45, 3500m, "São Carlos", 3662, "Chácara Jardim das Palmeiras", "Palmeiras Ltda" },
                    { 46, 32000m, "Imperatriz", 9953, "Fazenda Vale do Rio", "Vale do Rio Agro" },
                    { 47, 5300m, "Petrópolis", 2714, "Sítio Encosta Verde", "Encosta Ltda" },
                    { 48, 23000m, "Londrina", 9027, "Fazenda Boa Vista", "AgroSul" },
                    { 49, 5000m, "Guarapuava", 2841, "Sítio Bela Serra", "SerraAlta" },
                    { 50, 3600m, "Ponta Grossa", 3312, "Chácara Vale do Sol", "ValeSul" },
                    { 51, 25500m, "Campo Grande", 5610, "Fazenda Horizonte", "TerraNova" },
                    { 52, 6200m, "Blumenau", 4268, "Sítio Pedra Branca", "PedraSul" },
                    { 53, 3000m, "Florianópolis", 3925, "Chácara Primavera", "Primavera Ltda" },
                    { 54, 21500m, "Dourados", 7489, "Fazenda Alto Alegre", "Alto Agro" },
                    { 55, 4700m, "Uberlândia", 2971, "Sítio Campo Belo", "Campo Forte" },
                    { 56, 3400m, "Ribeirão Preto", 3620, "Chácara Estrela do Sul", "Estrela Agro" },
                    { 57, 27500m, "Goiânia", 8188, "Fazenda Santa Helena", "Helena Agropecuária" },
                    { 58, 5500m, "Chapecó", 2793, "Sítio Água Clara", "Água Viva" },
                    { 59, 4200m, "Poços de Caldas", 3521, "Chácara Monte Verde", "Monte Verde Ltda" },
                    { 60, 30500m, "Uberaba", 9277, "Fazenda Ouro Branco", "Ouro Agro" },
                    { 61, 4900m, "Joinville", 2598, "Sítio Lago Azul", "Lago Azul Ltda" },
                    { 62, 3200m, "Sorocaba", 3155, "Chácara Boa Esperança", "Esperança Rural" },
                    { 63, 29500m, "Palmas", 8721, "Fazenda Santa Rita", "Santa Rita Agro" },
                    { 64, 5700m, "Nova Friburgo", 3012, "Sítio Encanto da Serra", "Encanto Verde" },
                    { 65, 3300m, "Jundiaí", 3599, "Chácara Recanto Feliz", "Recanto Ltda" },
                    { 66, 26800m, "Campo Grande", 8842, "Fazenda Campo Grande", "Campo Grande Agro" },
                    { 67, 5100m, "Lages", 2610, "Sítio Vista Alegre", "Vista Alegre Rural" },
                    { 68, 22500m, "Sinop", 9365, "Fazenda Rio Dourado", "Rio Agro" },
                    { 69, 4400m, "Itu", 2798, "Sítio Bela Vista", "Bela Vista Rural" },
                    { 70, 3800m, "Campinas", 3912, "Chácara Sol Nascente", "Sol Nascente Agro" },
                    { 71, 28500m, "Três Lagoas", 9054, "Fazenda Três Lagoas", "Lagoas Agro" },
                    { 72, 5000m, "Domingos Martins", 2983, "Sítio Pedra Azul", "Pedra Azul Ltda" },
                    { 73, 3500m, "Atibaia", 3740, "Chácara Vale Encantado", "Encanto Rural" },
                    { 74, 30500m, "Barreiras", 9802, "Fazenda Boa Esperança", "Boa Esperança Agro" },
                    { 75, 4700m, "São José dos Pinhais", 2835, "Sítio Água Verde", "Água Verde Ltda" },
                    { 76, 3650m, "Anápolis", 3492, "Chácara Serra Dourada", "Serra Dourada Agro" },
                    { 77, 26000m, "Rondonópolis", 8477, "Fazenda Santa Clara", "Santa Clara Agro" },
                    { 78, 5200m, "Passo Fundo", 2661, "Sítio Vale Verde", "Vale Verde Ltda" },
                    { 79, 3200m, "Araraquara", 3604, "Chácara Morada do Sol", "Morada Ltda" },
                    { 80, 24500m, "Cuiabá", 8150, "Fazenda Santa Tereza", "Santa Tereza Agro" },
                    { 81, 4900m, "Holambra", 3007, "Sítio Recanto das Flores", "Flores do Campo" },
                    { 82, 3600m, "São Carlos", 3688, "Chácara Jardim das Palmeiras", "Palmeiras Ltda" },
                    { 83, 32500m, "Imperatriz", 9981, "Fazenda Vale do Rio", "Vale do Rio Agro" },
                    { 84, 5400m, "Petrópolis", 2730, "Sítio Encosta Verde", "Encosta Ltda" },
                    { 85, 3300m, "Maringá", 3615, "Chácara Recanto Verde", "VerdeVale" },
                    { 86, 18200m, "Cascavel", 6754, "Fazenda Três Rios", "AgroRios" },
                    { 87, 5600m, "Chapecó", 3033, "Sítio Água Clara", "Água Viva" },
                    { 88, 26000m, "Campo Grande", 5638, "Fazenda Horizonte", "TerraNova" },
                    { 89, 6300m, "Blumenau", 4285, "Sítio Pedra Branca", "PedraSul" },
                    { 90, 3100m, "Florianópolis", 3950, "Chácara Primavera", "Primavera Ltda" },
                    { 91, 22000m, "Dourados", 7521, "Fazenda Alto Alegre", "Alto Agro" },
                    { 92, 4800m, "Uberlândia", 2995, "Sítio Campo Belo", "Campo Forte" },
                    { 93, 3500m, "Ribeirão Preto", 3641, "Chácara Estrela do Sul", "Estrela Agro" },
                    { 94, 28000m, "Goiânia", 8205, "Fazenda Santa Helena", "Helena Agropecuária" },
                    { 95, 5700m, "Chapecó", 3050, "Sítio Água Clara", "Água Viva" },
                    { 96, 4300m, "Poços de Caldas", 3544, "Chácara Monte Verde", "Monte Verde Ltda" },
                    { 97, 31000m, "Uberaba", 9302, "Fazenda Ouro Branco", "Ouro Agro" },
                    { 98, 5000m, "Joinville", 2620, "Sítio Lago Azul", "Lago Azul Ltda" },
                    { 99, 3400m, "Sorocaba", 3180, "Chácara Boa Esperança", "Esperança Rural" },
                    { 100, 30000m, "Palmas", 8750, "Fazenda Santa Rita", "Santa Rita Agro" },
                    { 101, 5800m, "Nova Friburgo", 3072, "Sítio Encanto da Serra", "Encanto Verde" },
                    { 102, 3500m, "Jundiaí", 3628, "Chácara Recanto Feliz", "Recanto Ltda" },
                    { 103, 27500m, "Campo Grande", 8870, "Fazenda Campo Grande", "Campo Grande Agro" },
                    { 104, 5200m, "Lages", 2630, "Sítio Vista Alegre", "Vista Alegre Rural" },
                    { 105, 3300m, "Araraquara", 3639, "Chácara Morada do Sol", "Morada Ltda" },
                    { 106, 25000m, "Cuiabá", 8182, "Fazenda Santa Tereza", "Santa Tereza Agro" },
                    { 107, 5000m, "Holambra", 3095, "Sítio Recanto das Flores", "Flores do Campo" },
                    { 108, 24000m, "Londrina", 9842, "Fazenda Boa Vista", "AgroSul" },
                    { 109, 5100m, "Guarapuava", 2888, "Sítio Bela Serra", "SerraAlta" },
                    { 110, 3700m, "Ponta Grossa", 3360, "Chácara Vale do Sol", "ValeSul" },
                    { 111, 26500m, "Campo Grande", 5689, "Fazenda Horizonte", "TerraNova" },
                    { 112, 6400m, "Blumenau", 4310, "Sítio Pedra Branca", "PedraSul" },
                    { 113, 3200m, "Florianópolis", 3982, "Chácara Primavera", "Primavera Ltda" },
                    { 114, 22500m, "Dourados", 7560, "Fazenda Alto Alegre", "Alto Agro" },
                    { 115, 4900m, "Uberlândia", 3011, "Sítio Campo Belo", "Campo Forte" },
                    { 116, 3600m, "Ribeirão Preto", 3678, "Chácara Estrela do Sul", "Estrela Agro" },
                    { 117, 28500m, "Goiânia", 8239, "Fazenda Santa Helena", "Helena Agropecuária" },
                    { 118, 5800m, "Chapecó", 3108, "Sítio Água Clara", "Água Viva" },
                    { 119, 4400m, "Poços de Caldas", 3570, "Chácara Monte Verde", "Monte Verde Ltda" },
                    { 120, 31500m, "Uberaba", 9350, "Fazenda Ouro Branco", "Ouro Agro" },
                    { 121, 5100m, "Joinville", 2655, "Sítio Lago Azul", "Lago Azul Ltda" },
                    { 122, 3500m, "Sorocaba", 3202, "Chácara Boa Esperança", "Esperança Rural" },
                    { 123, 30500m, "Palmas", 8799, "Fazenda Santa Rita", "Santa Rita Agro" },
                    { 124, 5900m, "Nova Friburgo", 3125, "Sítio Encanto da Serra", "Encanto Verde" },
                    { 125, 3600m, "Jundiaí", 3666, "Chácara Recanto Feliz", "Recanto Ltda" },
                    { 126, 28000m, "Campo Grande", 8915, "Fazenda Campo Grande", "Campo Grande Agro" },
                    { 127, 5300m, "Lages", 2668, "Sítio Vista Alegre", "Vista Alegre Rural" },
                    { 128, 3400m, "Araraquara", 3695, "Chácara Morada do Sol", "Morada Ltda" },
                    { 129, 25500m, "Cuiabá", 8221, "Fazenda Santa Tereza", "Santa Tereza Agro" },
                    { 130, 5100m, "Holambra", 3133, "Sítio Recanto das Flores", "Flores do Campo" },
                    { 131, 3700m, "São Carlos", 3710, "Chácara Jardim das Palmeiras", "Palmeiras Ltda" },
                    { 132, 33000m, "Imperatriz", 10012, "Fazenda Vale do Rio", "Vale do Rio Agro" },
                    { 133, 5500m, "Petrópolis", 2755, "Sítio Encosta Verde", "Encosta Ltda" },
                    { 134, 3400m, "Maringá", 3640, "Chácara Recanto Verde", "VerdeVale" },
                    { 135, 18500m, "Cascavel", 6788, "Fazenda Três Rios", "AgroRios" },
                    { 136, 6000m, "Chapecó", 3159, "Sítio Água Clara", "Água Viva" },
                    { 137, 3900m, "Campinas", 3935, "Chácara Sol Nascente", "Sol Nascente Agro" },
                    { 138, 29000m, "Três Lagoas", 9089, "Fazenda Três Lagoas", "Lagoas Agro" },
                    { 139, 5200m, "Domingos Martins", 3008, "Sítio Pedra Azul", "Pedra Azul Ltda" },
                    { 140, 3600m, "Atibaia", 3762, "Chácara Vale Encantado", "Encanto Rural" },
                    { 141, 31000m, "Barreiras", 9833, "Fazenda Boa Esperança", "Boa Esperança Agro" },
                    { 142, 4800m, "São José dos Pinhais", 2860, "Sítio Água Verde", "Água Verde Ltda" },
                    { 143, 3700m, "Anápolis", 3515, "Chácara Serra Dourada", "Serra Dourada Agro" },
                    { 144, 26500m, "Rondonópolis", 8505, "Fazenda Santa Clara", "Santa Clara Agro" },
                    { 145, 5300m, "Passo Fundo", 2689, "Sítio Vale Verde", "Vale Verde Ltda" },
                    { 146, 3700m, "Jundiaí", 3685, "Chácara Recanto Feliz", "Recanto Ltda" },
                    { 147, 28500m, "Campo Grande", 8950, "Fazenda Campo Grande", "Campo Grande Agro" },
                    { 148, 5400m, "Lages", 2705, "Sítio Vista Alegre", "Vista Alegre Rural" },
                    { 149, 3500m, "Araraquara", 3728, "Chácara Morada do Sol", "Morada Ltda" },
                    { 150, 26000m, "Cuiabá", 8254, "Fazenda Santa Tereza", "Santa Tereza Agro" },
                    { 151, 5200m, "Holambra", 3167, "Sítio Recanto das Flores", "Flores do Campo" },
                    { 152, 3800m, "São Carlos", 3739, "Chácara Jardim das Palmeiras", "Palmeiras Ltda" },
                    { 153, 33500m, "Imperatriz", 10045, "Fazenda Vale do Rio", "Vale do Rio Agro" },
                    { 154, 5600m, "Petrópolis", 2780, "Sítio Encosta Verde", "Encosta Ltda" },
                    { 155, 3500m, "Maringá", 3661, "Chácara Recanto Verde", "VerdeVale" },
                    { 156, 19000m, "Cascavel", 6812, "Fazenda Três Rios", "AgroRios" },
                    { 157, 6100m, "Chapecó", 3184, "Sítio Água Clara", "Água Viva" },
                    { 158, 4000m, "Campinas", 3960, "Chácara Sol Nascente", "Sol Nascente Agro" },
                    { 159, 29500m, "Três Lagoas", 9120, "Fazenda Três Lagoas", "Lagoas Agro" },
                    { 160, 5300m, "Domingos Martins", 3035, "Sítio Pedra Azul", "Pedra Azul Ltda" },
                    { 161, 3700m, "Atibaia", 3788, "Chácara Vale Encantado", "Encanto Rural" },
                    { 162, 31500m, "Barreiras", 9860, "Fazenda Boa Esperança", "Boa Esperança Agro" },
                    { 163, 4900m, "São José dos Pinhais", 2884, "Sítio Água Verde", "Água Verde Ltda" },
                    { 164, 3800m, "Anápolis", 3540, "Chácara Serra Dourada", "Serra Dourada Agro" },
                    { 165, 27000m, "Rondonópolis", 8533, "Fazenda Santa Clara", "Santa Clara Agro" },
                    { 166, 5400m, "Passo Fundo", 2715, "Sítio Vale Verde", "Vale Verde Ltda" },
                    { 167, 3800m, "Jundiaí", 3709, "Chácara Recanto Feliz", "Recanto Ltda" },
                    { 168, 29000m, "Campo Grande", 8982, "Fazenda Campo Grande", "Campo Grande Agro" },
                    { 169, 5500m, "Lages", 2738, "Sítio Vista Alegre", "Vista Alegre Rural" },
                    { 170, 3600m, "Araraquara", 3756, "Chácara Morada do Sol", "Morada Ltda" },
                    { 171, 26500m, "Cuiabá", 8289, "Fazenda Santa Tereza", "Santa Tereza Agro" },
                    { 172, 5300m, "Holambra", 3199, "Sítio Recanto das Flores", "Flores do Campo" },
                    { 173, 3900m, "São Carlos", 3768, "Chácara Jardim das Palmeiras", "Palmeiras Ltda" },
                    { 174, 34000m, "Imperatriz", 10078, "Fazenda Vale do Rio", "Vale do Rio Agro" },
                    { 175, 5700m, "Petrópolis", 2804, "Sítio Encosta Verde", "Encosta Ltda" },
                    { 176, 3600m, "Maringá", 3684, "Chácara Recanto Verde", "VerdeVale" },
                    { 177, 19500m, "Cascavel", 6845, "Fazenda Três Rios", "AgroRios" },
                    { 178, 6200m, "Chapecó", 3210, "Sítio Água Clara", "Água Viva" },
                    { 179, 4100m, "Campinas", 3987, "Chácara Sol Nascente", "Sol Nascente Agro" },
                    { 180, 30000m, "Três Lagoas", 9156, "Fazenda Três Lagoas", "Lagoas Agro" },
                    { 181, 5400m, "Domingos Martins", 3062, "Sítio Pedra Azul", "Pedra Azul Ltda" },
                    { 182, 3800m, "Atibaia", 3815, "Chácara Vale Encantado", "Encanto Rural" },
                    { 183, 32000m, "Barreiras", 9894, "Fazenda Boa Esperança", "Boa Esperança Agro" },
                    { 184, 5000m, "São José dos Pinhais", 2907, "Sítio Água Verde", "Água Verde Ltda" },
                    { 185, 3900m, "Anápolis", 3566, "Chácara Serra Dourada", "Serra Dourada Agro" },
                    { 186, 27500m, "Rondonópolis", 8570, "Fazenda Santa Clara", "Santa Clara Agro" },
                    { 187, 5500m, "Passo Fundo", 2742, "Sítio Vale Verde", "Vale Verde Ltda" },
                    { 188, 3900m, "Jundiaí", 3735, "Chácara Recanto Feliz", "Recanto Ltda" },
                    { 189, 29500m, "Campo Grande", 9010, "Fazenda Campo Grande", "Campo Grande Agro" },
                    { 190, 5600m, "Lages", 2766, "Sítio Vista Alegre", "Vista Alegre Rural" },
                    { 191, 3700m, "Araraquara", 3780, "Chácara Morada do Sol", "Morada Ltda" },
                    { 192, 27000m, "Cuiabá", 8320, "Fazenda Santa Tereza", "Santa Tereza Agro" },
                    { 193, 5400m, "Holambra", 3228, "Sítio Recanto das Flores", "Flores do Campo" },
                    { 194, 4000m, "São Carlos", 3799, "Chácara Jardim das Palmeiras", "Palmeiras Ltda" },
                    { 195, 34500m, "Imperatriz", 10105, "Fazenda Vale do Rio", "Vale do Rio Agro" },
                    { 196, 5800m, "Petrópolis", 2831, "Sítio Encosta Verde", "Encosta Ltda" },
                    { 197, 3700m, "Maringá", 3702, "Chácara Recanto Verde", "VerdeVale" },
                    { 198, 20000m, "Cascavel", 6879, "Fazenda Três Rios", "AgroRios" },
                    { 199, 6300m, "Chapecó", 3244, "Sítio Água Clara", "Água Viva" },
                    { 200, 4200m, "Campinas", 4012, "Chácara Sol Nascente", "Sol Nascente Agro" },
                    { 201, 30500m, "Três Lagoas", 9188, "Fazenda Três Lagoas", "Lagoas Agro" },
                    { 202, 5500m, "Domingos Martins", 3089, "Sítio Pedra Azul", "Pedra Azul Ltda" },
                    { 203, 3900m, "Atibaia", 3840, "Chácara Vale Encantado", "Encanto Rural" },
                    { 204, 32500m, "Barreiras", 9925, "Fazenda Boa Esperança", "Boa Esperança Agro" },
                    { 205, 5100m, "São José dos Pinhais", 2930, "Sítio Água Verde", "Água Verde Ltda" },
                    { 206, 4000m, "Anápolis", 3592, "Chácara Serra Dourada", "Serra Dourada Agro" },
                    { 207, 28000m, "Rondonópolis", 8602, "Fazenda Santa Clara", "Santa Clara Agro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foto_RelatorioId",
                table: "Foto",
                column: "RelatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_TerrenoId",
                table: "Relatorios",
                column: "TerrenoId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_UsuarioId",
                table: "Relatorios",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropTable(
                name: "Terrenos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
