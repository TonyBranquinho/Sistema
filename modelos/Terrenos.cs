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


        public Terrenos()
        {
        }

        public Terrenos(int id, int matricula, string nome, decimal area, string proprietaria)
        {
            Id = id;
            Matricula = matricula;
            Nome = nome;
            Area = area;
            Proprietaria = proprietaria;
        }
    }
}
