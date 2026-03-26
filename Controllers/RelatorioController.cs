using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.Repository;
using Sistema.Modelos;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
            Console.WriteLine("Requisição de relatório recebida!");
            try
            {
                


                // Validação básica: O terreno existe?
                var terrenoExiste = await _context.Terrenos.AnyAsync(t => t.Id == dados.TerrenoId);
               
                if (!terrenoExiste)
                {
                    return BadRequest(new { sucesso = false, mensagem = "Terreno não encontrado, recarregue a pagina e selecione novamente." });
                }

                if (string.IsNullOrEmpty(dados.ImagemBase64))
                {
                    return BadRequest(new { sucesso = false, mensagem = "É necessário incluir pelo menos uma foto." });
                }



                var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int usuarioId = int.Parse(claimValue);


                // Cria o relatório
                var novoRelatorio = new Relatorios
                {
                    Descricao = dados.Descricao,
                    TerrenoId = dados.TerrenoId,
                    UsuarioId = usuarioId,
                    DataCriacao = DateTime.Now,
                    Fotos = new List<Foto>() // Inicializa a lista vazia
                };


                
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
                var nomeArquivo = $"foto_{Guid.NewGuid()}.jpg";

                // Cria o caminho final: a pasta onde salvar + o nome único do arquivo
                var caminhoCompleto = Path.Combine(pastaFotos, nomeArquivo);

                // Grava os bytes convertidos no disco rígido do servidor criando o arquivo .jpg
                await System.IO.File.WriteAllBytesAsync(caminhoCompleto, imageBytes);


                    

                // Cria o objeto foto com o nome do arquivo que foi para o wwwroot
                var novaFoto = new Foto
                {
                    NomeArquivo = nomeArquivo,
                    DataCriacao = DateTime.Now,
                    Localizacao = 0
                };

                novoRelatorio.Fotos.Add(novaFoto);

                // Salva tudo no banco
                _context.Relatorios.Add(novoRelatorio);
                await _context.SaveChangesAsync();

                
                return Ok(new { sucesso = true, mensagem = "Relatório recebido com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { sucesso = false, mensagem = "Erro inesperado ao salvar, recarregue a pagina e tente novamente." + ex.Message });
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
