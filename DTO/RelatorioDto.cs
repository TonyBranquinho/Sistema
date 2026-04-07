namespace Sistema.DTO
{
    public class RelatorioDto
    {
        public int TerrenoId { get; set; }
        public string Descricao { get; set; }


        public List<string> ImagensBase64 { get; set; }


        public RelatorioDto()
        {
            ImagensBase64 = new List<string>();
        }

        public RelatorioDto(int terrenoId, List<string> imagensBase64, string descricao)
        {
            TerrenoId = terrenoId;
            ImagensBase64 = imagensBase64;
            Descricao = descricao;
        }
    }
}
