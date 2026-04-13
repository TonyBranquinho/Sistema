using Sistema.Modelos;
using System;

public class RelatorioGestorDTO
{
    public int Id { get; set; }
    public string NomeFuncionario { get; set; }
    public string NomePropriedade { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public List<FotoDTO> Fotos { get; set; } = new List<FotoDTO>();

    public class FotoDTO
    {
        public string NomeArquivo { get; set; }
        public DateTime? DataFoto { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}