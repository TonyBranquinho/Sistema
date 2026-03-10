namespace Sistema.Modelos
{
    public class Terrenos
    {
        public long Id {  get; set; }
        public long Matricula {  get; set; }
        public string Nome { get; set; }
        public decimal Area { get; set; }
        public string Proprietaria { get; set; }


        public Terrenos()
        {
        }

        public Terrenos(long id, long matricula, string nome, decimal area, string proprietaria)
        {
            Id = id;
            Matricula = matricula;
            Nome = nome;
            Area = area;
            Proprietaria = proprietaria;
        }
    }
}
