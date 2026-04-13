using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Repository;
using Sistema.Enums;
using Microsoft.AspNetCore.Authorization;
using System.IO.Compression;

using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Sistema.Modelos;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly MeuDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DashboardController(MeuDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }




        [HttpGet("listar-propriedades-status")] 
        public async Task<IActionResult> GetStatusPropriedades()
        {            

            // Calcula o intervalo da semana atual (segunda a domingo)
            var hoje = DateTime.Today;
            var diasDesdeSegunda = (int)hoje.DayOfWeek == 0 ? 6 : (int)hoje.DayOfWeek - 1;
            var inicioSemana = hoje.AddDays(-diasDesdeSegunda);
            var fimSemana = inicioSemana.AddDays(7);
            var inicioSemanaAnterior = inicioSemana.AddDays(-7);

            // A query agora é montada e enviada para o MySQL processar
            var resultado = await _context.Terrenos
                .AsNoTracking()
                .Select(t => new
                {
                    t.Id,
                    t.Nome,
                    t.Area,
                    t.Matricula,
                    t.Cidade,
                    t.Proprietaria,
                    t.Latitude,
                    t.Longitude,
                    t.MarcadoComoImportante,
                    // O banco de dados resolve o status
                    Status = t.Relatorios.Any(r => r.DataCriacao >= inicioSemana && r.DataCriacao < fimSemana)
                        ? StatusRelatorio.EmDia
                        : t.Relatorios.Any(r => r.DataCriacao >= inicioSemanaAnterior && r.DataCriacao < inicioSemana)
                            ? StatusRelatorio.Aguardando
                            : StatusRelatorio.SemRelatorio,

                    // Pega apenas o último relatório para não sobrecarregar
                    UltimoRelatorio = t.Relatorios
                        .OrderByDescending(r => r.DataCriacao)
                        .Select(r => new
                        {
                            r.Id,
                            r.DataCriacao,
                            NomeFuncionario = r.Usuario.Nome ?? "Desconhecido",
                            Descricao = r.Descricao ?? "Sem descrição disponível.",

                            // Garante que Fotos seja sempre uma lista, mesmo que vazia []
                            Fotos = r.Fotos.Select(f => new RelatorioGestorDTO.FotoDTO
                            {
                                NomeArquivo = f.NomeArquivo,
                                DataFoto = f.DataFoto,
                                Latitude = f.Latitude,
                                Longitude = f.Longitude
                            }).ToList()
                        })
                        .FirstOrDefault() // Se não houver relatório, o objeto UltimoRelatorio será null no JSON
                })
                
                .ToListAsync();

            return Ok(resultado);
        }




        [HttpPost("gerar-pdfs-selecionados")]
        public async Task<IActionResult> GerarPdfs([FromBody] List<int> idsSelecionados)
        {
            var terrenos = await _context.Terrenos
                .Where(t => idsSelecionados.Contains(t.Id))
                .Include(t => t.Relatorios)
                    .ThenInclude(r => r.Fotos)                
                .ToListAsync();

            using (var ms = new MemoryStream())
            {
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    foreach (var terreno in terrenos)
                    {
                        var pdfBytes = GerarDocumentoQuestPDF(terreno); // Sua lógica de layout aqui
                        var entry = archive.CreateEntry($"{terreno.Nome.Replace(" ", "_")}.pdf");
                        using (var entryStream = entry.Open())
                        {
                            await entryStream.WriteAsync(pdfBytes, 0, pdfBytes.Length);
                        }
                    }
                }
                return File(ms.ToArray(), "application/zip", $"Relatorios_Selecionados_{DateTime.Now:ddMMyy}.zip");
            }
        }

        private byte[] GerarDocumentoQuestPDF(Terrenos terreno)
        {
            var pastaFotos = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "fotos");

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(1, Unit.Centimetre);
                    page.Header().Text($"Relatório: {terreno.Nome}").FontSize(20).SemiBold();

                    page.Content().Column(col =>
                    {
                        col.Item().Text($"Cidade: {terreno.Cidade}");
                        col.Item().Text($"Proprietária: {terreno.Proprietaria}");

                        foreach (var rel in terreno.Relatorios)
                        {
                            col.Item().PaddingTop(15).BorderTop(1).PaddingBottom(5).Text($"Relato de {rel.DataCriacao:dd/MM/yyyy}").Bold();
                            col.Item().Text(rel.Descricao);

                            // Renderização das Fotos
                            foreach (var foto in rel.Fotos)
                            {
                                var caminhoCompleto = Path.Combine(pastaFotos, foto.NomeArquivo);
                                Console.WriteLine($"Procurando foto: {caminhoCompleto} — Existe: {System.IO.File.Exists(caminhoCompleto)}");

                                if (System.IO.File.Exists(caminhoCompleto))
                                {
                                    col.Item().PaddingTop(5).Column(fotoCol =>
                                    {
                                        // Insere a imagem no PDF
                                        fotoCol.Item().MaxWidth(300).Image(caminhoCompleto);

                                        // Opcional: Exibir metadados abaixo da foto
                                        if (foto.Latitude.HasValue && foto.Longitude.HasValue)
                                        {
                                            fotoCol.Item().Text($"Coordenadas: {foto.Latitude}, {foto.Longitude}").FontSize(8).Italic();
                                        }
                                    });
                                }
                            }
                        }
                    });
                });
            }).GeneratePdf();
        }

        [HttpGet("gerar-backup-mensal")]
        public async Task<IActionResult> GerarBackupGeral()
        {
            var dados = await _context.Terrenos
                .Include(t => t.Relatorios)
                    .ThenInclude(r => r.Fotos)
                .OrderBy(t => t.Nome)
                .ToListAsync();

            using (var ms = new MemoryStream())
            {
                using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    // 1. Criar a Planilha de Índice (Excel)
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Índice de Relatórios");
                        worksheet.Cell(1, 1).Value = "Propriedade";
                        worksheet.Cell(1, 2).Value = "Data";
                        worksheet.Cell(1, 3).Value = "Descrição";
                        worksheet.Cell(1, 4).Value = "Link Foto";

                        int linha = 2;

                        // O laço 'foreach (var t in dados)' deve envolver os relatórios
                        foreach (var t in dados)
                        {
                            foreach (var r in t.Relatorios)
                            {
                                worksheet.Cell(linha, 1).Value = t.Nome;
                                worksheet.Cell(linha, 2).Value = r.DataCriacao;
                                worksheet.Cell(linha, 3).Value = r.Descricao;

                                // Se houver fotos, pegamos a primeira para o link principal do Excel
                                var primeiraFoto = r.Fotos?.FirstOrDefault()?.NomeArquivo;
                                if (!string.IsNullOrEmpty(primeiraFoto))
                                {
                                    worksheet.Cell(linha, 4).Value = "Ver Foto";
                                    worksheet.Cell(linha, 4).GetHyperlink().ExternalAddress = new Uri($@"Fotos\{primeiraFoto}", UriKind.Relative);
                                }

                                // Adiciona TODAS as fotos do relatório ao ZIP
                                if (r.Fotos != null)
                                {
                                    foreach (var foto in r.Fotos)
                                    {
                                        var caminhoFisico = Path.Combine(_env.WebRootPath, "fotos", foto.NomeArquivo);
                                        if (System.IO.File.Exists(caminhoFisico))
                                        {
                                            // Adiciona o arquivo na subpasta Fotos dentro do ZIP
                                            archive.CreateEntryFromFile(caminhoFisico, $@"Fotos/{foto.NomeArquivo}");
                                        }
                                    }
                                }
                                linha++;
                            }
                        }

                        // Salva o Excel dentro do ZIP
                        var excelEntry = archive.CreateEntry("INDICE_GERAL.xlsx");
                        using (var entryStream = excelEntry.Open())
                        using (var excelStream = new MemoryStream())
                        {
                            workbook.SaveAs(excelStream);
                            var bytes = excelStream.ToArray();
                            await entryStream.WriteAsync(bytes, 0, bytes.Length);
                        }
                    }
                }
                return File(ms.ToArray(), "application/zip", $"BACKUP_COMPLETO_{DateTime.Now:MM_yyyy}.zip");
            }
        }




        [HttpGet("listar-relatorios-terreno/{id}")]
        public async Task<IActionResult> ListarRelatoriosTerreno(int id)
        {
            try
            {
                var relatorios = await _context.Relatorios
                    .Where(r => r.TerrenoId == id)
                    .Include(r => r.Usuario)
                    .Include(r => r.Fotos)
                    .Select(r => new RelatorioGestorDTO
                    {
                        Id = r.Id,
                        NomeFuncionario = r.Usuario.Nome,
                        //NomePropriedade = r.Terreno.Nome,
                        Descricao = r.Descricao,
                        DataCriacao = r.DataCriacao,

                        // Transforma a lista de objetos "Foto" em uma lista de strings (nomes dos arquivos)
                        Fotos = r.Fotos.Select(f => new RelatorioGestorDTO.FotoDTO
                        {
                            NomeArquivo = f.NomeArquivo,
                            DataFoto = f.DataFoto,
                            Latitude = f.Latitude,
                            Longitude = f.Longitude
                        }).ToList()
                    })
                    .OrderByDescending(r => r.DataCriacao)
                    .ToListAsync();

                return Ok(relatorios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao buscar relatórios", detalhe = ex.Message });
            }
        }
    }
}