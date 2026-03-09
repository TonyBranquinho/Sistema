using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.repository;
using Sistema.service;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly MeuDbContext _context; // O "substituto" do ADO.NET (EF Core)

        public LoginController(MeuDbContext context)
        {
            _context = context;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dados)
        {
            // 1. Busca o usuário no banco usando LINQ (EF Core)
            // Isso substitui o SELECT * FROM usuarios WHERE...
            var usuarioEncontrado = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nome == dados.Usuario);
                    
            
            if (usuarioEncontrado == null)
            {
                // Retorna um objeto que o JS lerá como "sucesso: false"
                return Unauthorized(new { sucesso = false, mensagem = "Usuario nao encontrado"});
            }


            // 2. Verifica se o usuario existe
            bool senhaEhValida = VerificadorArgon2.Validar(dados.Senha, usuarioEncontrado.SenhaHash);

            
            if (!senhaEhValida)
            {
                return Unauthorized(new { sucesso = false, mensagem = "Senha incorreta" });
            }


            // 3. Sucesso (Igual ao que você já tinha)
            return Ok(new
            {
                sucesso = true,
                nome = usuarioEncontrado.Nome
            }); 
        }
    }
}
