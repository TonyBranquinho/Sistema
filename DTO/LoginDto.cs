using Sistema.modelos;

namespace Sistema.DTO
{
    public class LoginDto
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public LoginDto()
        {
        }

        public LoginDto(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }
    }
}
