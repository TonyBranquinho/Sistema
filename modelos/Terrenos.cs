namespace Sistema.Modelos
{
    public class Terrenos
    {
        public int Id {  get; set; }
        public int Matricula {  get; set; }
        public string Nome { get; set; }
        public decimal Area { get; set; }
        public string Cidade { get; set; }
        public string Proprietaria { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool MarcadoComoImportante { get; set; }

        public List<Relatorios> Relatorios { get; set; }


        public Terrenos()
        {
        }

        public Terrenos(int id, int matricula, string nome, decimal area, string proprietaria, double latitude, double longitude, bool marcadoComoImportante)
        {
            Id = id;
            Matricula = matricula;
            Nome = nome;
            Area = area;
            Proprietaria = proprietaria;
            Latitude = latitude;
            Longitude = longitude;
            MarcadoComoImportante = marcadoComoImportante;
        }
    }
}
