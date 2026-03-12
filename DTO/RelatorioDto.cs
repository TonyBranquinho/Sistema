namespace Sistema.DTO
{
    public class RelatorioDto
    {
        public long TerrenoId { get; set; }
        public string ImagemBase64 { get; set; }
        public string Descricao { get; set; }

        public RelatorioDto() { }

        public RelatorioDto(long terrenoId, string imagemBase64, string descricao)
        {
            TerrenoId = terrenoId;
            ImagemBase64 = imagemBase64;
            Descricao = descricao;
        }
    }
}
