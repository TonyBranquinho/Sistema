namespace Sistema.Modelos
{
    public class Terrenos
    {
        public long Id {  get; set; }
        public string Nome { get; set; }
        public decimal Area { get; set; }
        public string Proprietaria { get; set; }


        public Terrenos()
        {
        }

        public Terrenos(long id, string nome, decimal area, string proprietaria)
        {
            Id = id;
            Nome = nome;
            Area = area;
            Proprietaria = proprietaria;
        }
    }
}
