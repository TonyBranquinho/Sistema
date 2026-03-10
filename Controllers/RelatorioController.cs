using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.repository;
using Sistema.modelos;

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



        [HttpPost("relatorio")]
        public async Task<IActionResult> Relatorio([FromBody] RelatorioDto dados)
        {
            // Lógica para salvar no banco ou gerar PDF entrará aqui
            return Ok(new { sucesso = true, mensagem = "Relatório recebido com sucesso!" });
        }
    }
}
