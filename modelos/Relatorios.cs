using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.modelos
{
    public class Relatorios
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public long TerrenoId { get; set; }
        public string Descricao { get; set; }
        public string ImagemBase64 { get; set; }


        [NotMapped]
        public int Matricula { get; set; }
        

        public Relatorios()
        {
        }

        public Relatorios(int id, int usuarioId, int matricula, string descricao, string imagemBase64, long terrenoId)
        {
            Id = id;
            UsuarioId = usuarioId;
            Matricula = matricula;
            Descricao = descricao;
            ImagemBase64 = imagemBase64;
            TerrenoId = terrenoId;
        }
    }
}
