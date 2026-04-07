using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.Repository;
using Sistema.Modelos;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MetadataExtractor.Formats.Exif;
using MetadataExtractor;

namespace Sistema.controllers
{
    [ApiController]
    [Route("api/[controller]")]

    [Authorize]
    public class RelatorioController : ControllerBase
    {        
        private readonly MeuDbContext _context; // O "substituto" do ADO.NET (EF Core)

        public RelatorioController(MeuDbContext context)
        {
            _context = context;
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



        [HttpGet("listar-empresas")] // define que esse método responde a requisições GET na rota "listar-empresas"
        public async Task<IActionResult> GetEmpresas(string cidade) // recebe o nome da cidade como parâmetro da URL
        {
            var empresas = await _context.Terrenos // acessa a tabela Terrenos no banco
                .Where(t => t.Cidade == cidade) // filtra apenas os terrenos que pertencem à cidade recebida
                .Select(t => t.Proprietaria) // de cada terreno filtrado, pega apenas o campo Proprietaria
                .Distinct() // remove empresas duplicadas — se a empresa tem 3 terrenos na cidade, aparece só uma vez
                .ToListAsync(); // executa a query no banco e retorna como lista

            return Ok(empresas); // retorna a lista de empresas com status 200
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









        [HttpPost("relatorio")]
        public async Task<IActionResult> Relatorio([FromBody] RelatorioDto dados)
        {
            try
            {
                var terrenoExiste = await _context.Terrenos.AnyAsync(t => t.Id == dados.TerrenoId);
                if (!terrenoExiste) return BadRequest(new { sucesso = false, mensagem = "Terreno não encontrado." });

                if (dados.ImagensBase64 == null || !dados.ImagensBase64.Any())
                    return BadRequest(new { sucesso = false, mensagem = "Inclua pelo menos uma foto." });

                var claimValue = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                int usuarioId = int.Parse(claimValue);

                // 1. Salva o Relatório primeiro
                var novoRelatorio = new Relatorios
                {
                    Descricao = dados.Descricao,
                    TerrenoId = dados.TerrenoId,
                    UsuarioId = usuarioId,
                    DataCriacao = DateTime.Now
                };

                _context.Relatorios.Add(novoRelatorio);
                await _context.SaveChangesAsync();

                // 2. Loop para processar cada foto da lista
                foreach (var imagemBase64 in dados.ImagensBase64)
                {
                    var base64Data = imagemBase64.Substring(imagemBase64.IndexOf(",") + 1);
                    byte[] imageBytes = Convert.FromBase64String(base64Data);

                    // Uso explícito de System.IO para evitar erro CS0104
                    var pastaFotos = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "fotos");
                    if (!System.IO.Directory.Exists(pastaFotos)) System.IO.Directory.CreateDirectory(pastaFotos);

                    var nomeArquivo = $"foto_{Guid.NewGuid()}.jpg";
                    var caminhoCompleto = Path.Combine(pastaFotos, nomeArquivo);
                    await System.IO.File.WriteAllBytesAsync(caminhoCompleto, imageBytes);

                    var novaFoto = new Foto
                    {
                        NomeArquivo = nomeArquivo,
                        RelatorioId = novoRelatorio.Id
                    };

                    // Extração de Metadados
                    try
                    {
                        var diretorios = ImageMetadataReader.ReadMetadata(new MemoryStream(imageBytes));
                        var subIfd = diretorios.OfType<ExifSubIfdDirectory>().FirstOrDefault();
                        if (subIfd != null && subIfd.TryGetDateTime(ExifDirectoryBase.TagDateTimeOriginal, out var data))
                            novaFoto.DataFoto = data;

                        var gps = diretorios.OfType<GpsDirectory>().FirstOrDefault();
                        if (gps != null)
                        {
                            var lat = gps.GetRationalArray(GpsDirectory.TagLatitude);
                            var lon = gps.GetRationalArray(GpsDirectory.TagLongitude);
                            var latRef = gps.GetString(GpsDirectory.TagLatitudeRef);
                            var lonRef = gps.GetString(GpsDirectory.TagLongitudeRef);
                            if (lat != null && lon != null)
                            {
                                novaFoto.Latitude = (decimal)(lat[0].ToDouble() + lat[1].ToDouble() / 60 + lat[2].ToDouble() / 3600) * (latRef == "S" ? -1 : 1);
                                novaFoto.Longitude = (decimal)(lon[0].ToDouble() + lon[1].ToDouble() / 60 + lon[2].ToDouble() / 3600) * (lonRef == "W" ? -1 : 1);
                            }
                        }
                    }
                    catch { /* Ignora erro de metadados se a foto não tiver */ }

                    // IMPORTANTE: Use o nome correto da sua tabela de fotos abaixo
                    _context.Foto.Add(novaFoto);
                }

                await _context.SaveChangesAsync();
                return Ok(new { sucesso = true, mensagem = "Relatório e fotos salvos com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = "Erro: " + ex.Message });
            }
        }



        [HttpGet("listar-todos")]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var relatorios = await _context.Relatorios
                    .Include(r => r.Terreno)
                    .Include(r => r.Usuario)
                    .Include(r => r.Fotos)
                    .Select(r => new RelatorioGestorDTO
                    {
                        Id = r.Id,
                        NomeFuncionario = r.Usuario.Nome,
                        NomePropriedade = r.Terreno.Nome,
                        Descricao = r.Descricao,
                        DataCriacao = r.DataCriacao,

                        // Transforma a lista de objetos "Foto" em uma lista de strings (nomes dos arquivos)
                        Fotos = r.Fotos.Select(f => f.NomeArquivo).ToList()
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
