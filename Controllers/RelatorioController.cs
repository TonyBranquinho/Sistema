using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.repository;
using Sistema.modelos;
using Microsoft.EntityFrameworkCore;
using Sistema.Modelos;

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
                
                var novoRelatorio = new Relatorios
                {
                    Descricao = dados.Descricao,
                    TerrenoId = dados.TerrenoId,
                    ImagemBase64 = dados.ImagemBase64
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
    }
}
