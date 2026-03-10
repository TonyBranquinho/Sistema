namespace Sistema.DTO
{
    public class RelatorioDto
    {
        public long MatriculaTerreno { get; set; }
        public string Foto { get; set; }
        public DateTime? Date { get; set; }
        public string Descricao { get; set; }

        public RelatorioDto() { }

        public RelatorioDto(long matriculaTerreno, string foto, DateTime? date, string descricao)
        {
            MatriculaTerreno = matriculaTerreno;
            Foto = foto;
            Date = date;
            Descricao = descricao;
        }
    }
}
