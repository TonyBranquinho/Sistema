namespace Sistema.Modelos
{
    public class Foto
    {
        public int Id { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime? DataFoto { get; set; } // EXIF Nulavel
        public decimal? Latitude { get; set; } // EXIF Nulavel
        public decimal? Longitude { get; set; } // EXIF Nulavel
        public int RelatorioId {  get; set; }

        public Relatorios Relatorios { get; set; }
    }
}
