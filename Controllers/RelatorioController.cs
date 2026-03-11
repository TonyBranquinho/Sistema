using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.repository;
using Sistema.modelos;
using Microsoft.EntityFrameworkCore;

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







        [HttpPost("relatorio")]
        public async Task<IActionResult> Relatorio([FromBody] RelatorioDto dados)
        {
            // Lógica para salvar no banco ou gerar PDF entrará aqui
            return Ok(new { sucesso = true, mensagem = "Relatório recebido com sucesso!" });
        }
    }
}
