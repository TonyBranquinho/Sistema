using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.Repository;
using Sistema.Service;
using Sistema.Modelos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity.Data;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly MeuDbContext _context; // O "substituto" do ADO.NET (EF Core)
        private readonly TokenService _tokenService;

        public LoginController(MeuDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dados)
        {
            // 1. Busca o usuário no banco pelo Nome (ajuste para Email se preferir)
            // Usamos 'usuarioEncontrado' para não confundir com o nome da classe 'Usuario'
            var usuarioEncontrado = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nome == dados.Usuario);

            if (usuarioEncontrado == null)
            {
                return Unauthorized(new { sucesso = false, mensagem = "Usuário não encontrado" });
            }

            // VERIFICAÇÃO DE STATUS DO USUARIO
            if (!usuarioEncontrado.Ativo)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { sucesso = false, mensagem = "Usuário inativo no sistema" });
            }

            // 2. Validação Real: Compara a senha digitada com o Hash do Banco (Argon2)
            bool senhaEhValida = VerificadorArgon2.Validar(dados.Senha, usuarioEncontrado.SenhaHash);

            if (!senhaEhValida)
            {
                return Unauthorized(new { sucesso = false, mensagem = "Senha incorreta" });
            }

            // 3. Geração do Crachá (Token JWT)
            // Passamos o objeto completo do usuário para o serviço extrair ID, Nome e Perfil
            var token = _tokenService.GerarToken(usuarioEncontrado);

            // 4. Retorno para o Cliente (Frontend)
            return Ok(new
            {
                sucesso = true,
                token = token,
                usuarioNome = usuarioEncontrado.Nome
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
                SenhaHash = hash,
                Ativo = true
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
