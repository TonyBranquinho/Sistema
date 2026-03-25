using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Sistema.DTO;
using Sistema.Repository;
using Sistema.Modelos;
using System.Text;
using Microsoft.AspNetCore.Identity.Data;

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
            // 1. Busca o usuário
            var usuarioEncontrado = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nome == dados.Usuario);

            if (usuarioEncontrado == null)
            {
                return Unauthorized(new { sucesso = false, mensagem = "Usuário não encontrado" });
            }

            // verificaçao do status do usuario
            if (!usuarioEncontrado.Ativo)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { sucesso = false, mensagem = "Usuário inativo no sistema" });
            }


            // 2. VALIDAÇÃO TEMPORÁRIA (SEM ARGON2).
            bool senhaEhValida = (dados.Senha == usuarioEncontrado.SenhaHash);

            if (!senhaEhValida)
            {
                return Unauthorized(new { sucesso = false, mensagem = "Senha incorreta" });
            }


            /// 3. RETORNO SEM TOKEN
            // Enviamos um token "falso" ou vazio apenas para não quebrar o seu Frontend (JavaScript)
            return Ok(new
            {
                sucesso = true,
                token = "TOKEN_DESATIVADO",
                usuarioNome = usuarioEncontrado.Nome,
                usuarioId = usuarioEncontrado.Id // Enviando o ID para o front saber quem é
            });
        }




        [HttpPost("registrar")]
        // Metodo que recebe dados CadastroDto e entrega Task<IActionResult>
        public async Task<IActionResult> Registrar([FromBody] CadastroDto dados)
        {
            // Cria o objeto do usuário
            var novoUsuario = new Usuario
            {
                Nome = dados.Nome,
                Email = dados.Email,
                SenhaHash = dados.Senha, // Salva a senha pura
                Ativo = true
            };


            // Salva no MySQL
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
