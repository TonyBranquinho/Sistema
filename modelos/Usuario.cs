namespace Sistema.modelos
{
    public class Usuario
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }


        public string SenhaHash { get; set; }
        public bool Ativo { get; set; }


        public Usuario()
        {
        }

        public Usuario(int id, string nome, string email, string senhaHash, bool ativo)
        {
            this.Id = id;
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Ativo = ativo;
        }
    }
}
