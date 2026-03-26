using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Repository;
using Sistema.Enums;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            // Busca terrenos com relatórios, usuários e fotos — tudo em uma query
            var terrenos = await _context.Terrenos
                .AsNoTracking()
                .Include(t => t.Relatorios)
                    .ThenInclude(r => r.Usuario)
                .Include(t => t.Relatorios)
                    .ThenInclude(r => r.Fotos)
                .ToListAsync();

            // Projeção feita em memória após os dados chegarem do banco
            var resultado = terrenos.Select(t =>
            {
                var temSemanaAtual = t.Relatorios.Any(r =>
                    r.DataCriacao >= inicioSemana && r.DataCriacao < fimSemana);

                var temSemanaAnterior = t.Relatorios.Any(r =>
                    r.DataCriacao >= inicioSemanaAnterior && r.DataCriacao < inicioSemana);

                // Último relatório enviado independente da semana
                var ultimo = t.Relatorios
                    .OrderByDescending(r => r.DataCriacao)
                    .FirstOrDefault();

                return new
                {
                    t.Id,
                    t.Nome,
                    t.Cidade,
                    t.Proprietaria,
                    Status = temSemanaAtual
                        ? StatusRelatorio.EmDia
                        : temSemanaAnterior
                            ? StatusRelatorio.Aguardando
                            : StatusRelatorio.SemRelatorio,
                    UltimoRelatorio = ultimo == null ? null : new
                    {
                        ultimo.DataCriacao,
                        NomeFuncionario = ultimo.Usuario?.Nome,
                        ultimo.Descricao,
                        Fotos = ultimo.Fotos.Select(f => f.NomeArquivo).ToList()
                    }
                };
            });

            return Ok(resultado);
        }
    }
}
