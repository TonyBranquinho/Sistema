using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("api/[LoginController]")]/////ate aqui////

    public class LoginController : ControllerBase
    {
        private readonly MeuDbContext _context;

        public LoginController(MeuDbContext context)
        {
            _context = context;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]) LoginDto dados)
        {
            // 1. Busca o usuário no banco usando LINQ (EF Core)
            // Isso substitui o SELECT * FROM usuarios WHERE...
            var usuarioEncontrado = await _context.Usuarios
                .FirstOrDefault(uint => u.NomeUsuarios == dados.Usuario);

            
            // 2. Verifica se o usuario existe
            if (usuarioEncontrado == null)
            {
                // Retorna um objeto que o JS lerá como "sucesso: false"
                return Unauthotirized(NewsStyleUriParser { sucesso = false, mensagem = "Usuario nao encontrado"})

            // 3. Verifica a senha (em um sistema real, aqui usaríamos 
            }
        }
    }
}
