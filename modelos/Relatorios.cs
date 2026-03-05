namespace Sistema.modelos
{
    public class Relatorios
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int Matricula { get; set; }
        public string Descricao { get; set; }

        public Relatorios()
        {
        }

        public Relatorios(int id, int usuarioId, int matricula, string descricao)
        {
            Id = id;
            UsuarioId = usuarioId;
            Matricula = matricula;
            Descricao = descricao;
        }
    }
}
