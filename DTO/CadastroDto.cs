
namespace Sistema.DTO
{
    public class CadastroDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    

        public CadastroDto()
        {

        }

        public CadastroDto (string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
