using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.repository;
using Sistema.modelos;
using Microsoft.EntityFrameworkCore;
using Sistema.Modelos;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Sistema.controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RelatorioController : ControllerBase
    {        
        private readonly MeuDbContext _context; // O "substituto" do ADO.NET (EF Core)

        public RelatorioController(MeuDbContext context)
        {
            _context = context;
        }






        [HttpGet("buscar-por-filtro")]
        public async Task<IActionResult> GetTerrenosFiltrados(string empresa, string cidade)
        {
            var terrenos = await _context.Terrenos
                .Where(t => t.Proprietaria == empresa && t.Cidade == cidade)
                .Select(t => new { t.Id, t.Matricula, t.Nome })
                .ToListAsync();

            return Ok(terrenos);
        }





        [HttpGet("listar-cidades")]
        public async Task<IActionResult> GetCidades()
        {
            var cidades = await _context.Terrenos
                .Select(t => t.Cidade)
                .Distinct()
                .ToListAsync();
            return Ok(cidades);
        }

        [HttpGet("listar-empresas")]
        public async Task<IActionResult> GetEmpresas()
        {
            var empresas = await _context.Terrenos
                .Select(t => t.Proprietaria)
                .Distinct()
                .ToListAsync();
            return Ok(empresas);
        }






        [HttpPost("relatorio")]
        public async Task<IActionResult> Relatorio([FromBody] RelatorioDto dados)
        {
            try
            {   
                // Validação básica: O terreno existe?
                var terrenoExiste = await _context.Terrenos.AnyAsync(t => t.Id == dados.TerrenoId);
               
                if (!terrenoExiste)
                {
                    return BadRequest(new { sucesso = false, mensagem = "Terreno não encontrado." });
                }




                string nomeArquivo = "";

                if (!string.IsNullOrEmpty(dados.ImagemBase64))
                {
                    // A string Base64 do navegador vem com um cabeçalho (ex: "data:image/jpeg;base64,...")
                    // Esta linha localiza a vírgula e pega apenas o que vem depois dela, que é o código da imagem real
                    var base64Data = dados.ImagemBase64.Substring(dados.ImagemBase64.IndexOf(",") + 1);

                    // Converte a string de texto Base64 em um array de bytes (dados binários que formam o arquivo)
                    byte[] imageBytes = Convert.FromBase64String(base64Data);

                    // Directory.GetCurrentDirectory() pega a pasta raiz do projeto
                    // Path.Combine junta os nomes de pastas garantindo que as barras ( \ ou / ) fiquem corretas conforme o sistema operacional
                    var pastaFotos = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fotos");

                    // Verifica se a pasta "wwwroot/fotos" existe no servidor; se não existir, o sistema a cria automaticamente
                    if (!Directory.Exists(pastaFotos)) Directory.CreateDirectory(pastaFotos);

                    // Guid.NewGuid() gera um código aleatório único (ex: a1b2-c3d4...). 
                    // Isso evita que, se dois usuários mandarem fotos com o mesmo nome original, uma apague a outra.
                    nomeArquivo = $"foto_{Guid.NewGuid()}.jpg";

                    // Cria o caminho final: a pasta onde salvar + o nome único do arquivo
                    var caminhoCompleto = Path.Combine(pastaFotos, nomeArquivo);

                    // Grava os bytes convertidos no disco rígido do servidor criando o arquivo .jpg
                    await System.IO.File.WriteAllBytesAsync(caminhoCompleto, imageBytes);
                }




                var novoRelatorio = new Relatorios
                {
                    Descricao = dados.Descricao,
                    TerrenoId = dados.TerrenoId,
                    ImagemBase64 = dados.ImagemBase64,
                    UsuarioId = 1
                };


                _context.Relatorios.Add(novoRelatorio);
                await _context.SaveChangesAsync();


                // Lógica para salvar no banco ou gerar PDF entrará aqui
                return Ok(new { sucesso = true, mensagem = "Relatório recebido com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = "Erro ao salvar: " + ex.Message });
            }
        }




        /*

        [HttpGet("gerar-pdf/{id}")]
        public async Task<IActionResult> GerarPdf(int id)
        {
            // 1. Busca o relatório
            var relatorio = await _context.Relatorios.FindAsync(id);
            if (relatorio == null)
                return NotFound(new { mensagem = "Relatório não encontrado." });

            // 2. Busca os dados do terreno correspondente
            var terreno = await _context.Terrenos.FindAsync(relatorio.TerrenoId);

            // 3. Desenha a estrutura do PDF
            var documento = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    // Cabeçalho
                    page.Header()
                        .Text($"Relatório: {terreno.Nome}")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Darken2);

                    // Conteúdo
                    page.Content().PaddingVertical(1, Unit.Centimetre).Column(col =>
                    {
                        col.Item().Text($"Matrícula: {terreno.Matricula}");
                        col.Item().Text($"Cidade: {terreno.Cidade}");
                        col.Item().Text($"Empresa: {terreno.Proprietaria}");
                        col.Item().Text($"Área: {terreno.Area} m²");

                        col.Item().PaddingTop(15).Text("Descrição do Relatório:").SemiBold();
                        col.Item().Text(relatorio.Descricao);

                        // 4. Lógica para anexar a foto, se existir
                        if (!string.IsNullOrEmpty(relatorio.ImagemBase64))
                        {
                            // Usa o mesmo caminho físico que você configurou no POST
                            var caminhoImagem = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fotos", relatorio.ImagemBase64);

                            if (System.IO.File.Exists(caminhoImagem))
                            {
                                col.Item().PaddingTop(20).Image(caminhoImagem);
                            }
                        }
                    });

                    // Rodapé com paginação
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                });
            });

            // 5. Gera os bytes do PDF e retorna como download
            byte[] pdfBytes = documento.GeneratePdf();
            return File(pdfBytes, "application/pdf", $"Relatorio_Matricula_{terreno.Matricula}.pdf");    
        }   */
    }
}
