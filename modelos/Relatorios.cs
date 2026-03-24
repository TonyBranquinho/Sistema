using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Modelos
{
    public class Relatorios
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TerrenoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }

        public Terrenos Terreno { get; set; }
        public Usuario Usuario { get; set; }

        public List<Foto> Fotos { get; set; }

        public Relatorios()
        {
        }

        public Relatorios(int id, int usuarioId, string descricao, int terrenoId)
        {
            Id = id;
            UsuarioId = usuarioId;
            Descricao = descricao;
            TerrenoId = terrenoId;
        }
    }
}
