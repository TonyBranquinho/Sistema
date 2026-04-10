using Sistema.Modelos;
using System;

public class RelatorioGestorDTO
{
    public int Id { get; set; }
    public string NomeFuncionario { get; set; }
    public string NomePropriedade { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }

    public List<string> Fotos { get; set; } = new List<string>();
}