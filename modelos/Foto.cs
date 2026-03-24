namespace Sistema.Modelos
{
    public class Foto
    {
        public int Id { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal Localizacao { get; set; }
        public int RelatorioId {  get; set; }

        public Relatorios Relatorios { get; set; }
    }
}
