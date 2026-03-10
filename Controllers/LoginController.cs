using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.repository;
using Sistema.service;
using Sistema.modelos;

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
                return Unauthorized(new { sucesso = false, mensagem = "Usuario nao encontrado" });
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




        [HttpPost("registrar")]
        // Metodo que recebe dados CadastroDto e entrega Task<IActionResult>
        public async Task<IActionResult> Registrar([FromBody] CadastroDto dados)
        {
            // 1. Gera o hash da senha usando Argon2
            var hash = VerificadorArgon2.GerarHash(dados.Senha);

            // 2. Cria o objeto do usuário
            var novoUsuario = new Usuario
            {
                Nome = dados.Nome,
                Email = dados.Email,
                SenhaHash = hash
            };

            // 3. Salva no MySQL
            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Usuário criado com sucesso!" });
        }




        [HttpPost("recuperar")]
        // Metodo que recebe dados RecuperarDto e entega Task<IActionResult>
        public async Task<IActionResult> Recuperar([FromBody] RecuperarDto dados)
        {
            // 1. Procurar o usuário no banco pelo e-mail
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dados.Email);

            // 2. Segurança: Mesmo que o e-mail não exista, o mercado recomenda 
            // responder "Sucesso" para evitar que hackers descubram quais e-mails estão cadastrados.
            if (usuario == null)
            {
                return Ok(new { mensagem = "Se o e-mail existir, um link de recuperação foi enviado." });
            }

            // 3. Lógica de envio (Aqui entraria o código para enviar um e-mail real)
            // Por enquanto, apenas simulamos.
            return Ok(new { mensagem = "Se o e-mail existir, um link de recuperação foi enviado." });
        }
    }
}
