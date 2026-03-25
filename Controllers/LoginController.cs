using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.Repository;
using Sistema.Modelos;
using System.Text;
using Microsoft.AspNetCore.Identity.Data;
using Sistema.Service;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly MeuDbContext _context; // O "substituto" do ADO.NET (EF Core)
        private readonly PasswordService _passwordService;
        private readonly TokenService _tokenService;


        public LoginController(MeuDbContext context, PasswordService passwordService, TokenService tokenService)
        {
            _context = context;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }




        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dados)
        {
            // 1. Busca o usuário
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nome == dados.Usuario);


            // NUNCA retorne "usuário não encontrado" separado de "senha incorreta".
            // Isso permite que um atacante enumere quais usuários existem no sistema
            // (user enumeration). A mensagem deve ser sempre a mesma nos dois casos.

            // Mesmo se o usuário não existe, roda o Verify com valores falsos.
            // Isso garante que o tempo de resposta seja igual nos dois casos,
            // impedindo que alguém descubra usuários válidos pelo tempo da resposta.
            bool senhaValida;


            if (usuario == null)
            {
                _passwordService.Verificar(dados.Senha, "fake.fake");
                senhaValida = false;
            }
            else
            {
                senhaValida = _passwordService.Verificar(dados.Senha, usuario.SenhaHash);
            }



            if (!senhaValida || usuario == null)
                return Unauthorized(new { sucesso = false, mensagem = "Credenciais inválidas" });

            if (!usuario.Ativo)
                return StatusCode(403, new { sucesso = false, mensagem = "Usuário inativo" });

            var token = _tokenService.Gerar(usuario);



            return Ok(new
            {
                sucesso = true,
                token = token,
                usuarioNome = usuario.Nome,
                usuarioId = usuario.Id
            });
        }






        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] CadastroDto dados)
        {
            var jaExiste = await _context.Usuarios.AnyAsync(u => u.Email == dados.Email);
            if (jaExiste)
                return Conflict(new { mensagem = "E-mail já cadastrado" });

            // Hashear retorna (hash, salt) — ambos byte[]
            var senhaHash = _passwordService.Hashear(dados.Senha);

            var novoUsuario = new Usuario
            {
                Nome = dados.Nome,
                Email = dados.Email,
                SenhaHash = senhaHash,
                Ativo = true
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Usuário criado com sucesso!" });
        }

        [HttpPost("recuperar")]
        public async Task<IActionResult> Recuperar([FromBody] RecuperarDto dados)
        {
            return Ok(new { mensagem = "Simulação: Link enviado." });
        }
    }
}
