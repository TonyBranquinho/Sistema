using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Repository;
using Sistema.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly MeuDbContext _context;


        public DashboardController(MeuDbContext context)
        {
            _context = context;
        }


        [HttpGet("listar-propriedades")]
        public async Task<IActionResult> GetListarPropriedades(
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanhoPagina = 20)

        {
            // Proteção simples contra valores inválidos
            if (pagina < 1) pagina = 1;
            if (tamanhoPagina < 1 || tamanhoPagina > 50)
                tamanhoPagina = 20;

            var terrenos = await _context.Terrenos
                .AsNoTracking()
                .Select(t => new { 
                    t.Id,
                    //t.Matricula,
                    t.Nome,
                    t.Area,
                    t.Cidade,
                    t.Proprietaria
                })
                .OrderBy(t => t.Id)                    // necessário para paginação
                .Skip((pagina -1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            return Ok(terrenos);
        }





        [HttpGet("status-propriedades")]
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
                    t.Cidade,
                    t.Proprietaria,
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
                            // Se r.DataCriacao for null (improvável no banco, mas bom prevenir), 
                            // o JS receberá null e o seu fmtData(iso) já tratará.
                            r.DataCriacao,

                            // Usamos o operador de coalescência nula para evitar strings vazias problemáticas
                            NomeFuncionario = r.Usuario.Nome ?? "Desconhecido",

                            Descricao = r.Descricao ?? "Sem descrição disponível.",

                            // Garante que Fotos seja sempre uma lista, mesmo que vazia []
                            Fotos = r.Fotos.Select(f => f.NomeArquivo).ToList()
                        })
                        .FirstOrDefault() // Se não houver relatório, o objeto UltimoRelatorio será null no JSON
                })
                .ToListAsync();

            return Ok(resultado);
        }
    }
}
