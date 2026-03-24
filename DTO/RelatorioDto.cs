namespace Sistema.DTO
{
    public class RelatorioDto
    {
        public int TerrenoId { get; set; }
        public string ImagemBase64 { get; set; }
        public string Descricao { get; set; }

        public RelatorioDto() { }

        public RelatorioDto(int terrenoId, string imagemBase64, string descricao)
        {
            TerrenoId = terrenoId;
            ImagemBase64 = imagemBase64;
            Descricao = descricao;
        }
    }
}
