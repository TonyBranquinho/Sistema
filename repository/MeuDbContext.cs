using Microsoft.EntityFrameworkCore;
using Sistema.modelos;
using Sistema.Modelos;

namespace Sistema.repository

{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Terrenos> Terrenos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Terrenos>().HasData(
                new Terrenos { Id = 1, Nome = "Casa do Baixo Quiriri", Area = 5000, Matricula = 7, Proprietaria = "Hacasa" },
                new Terrenos { Id = 2, Nome = "Casa do Alto Quiriri", Area = 10000, Matricula = 6, Proprietaria = "Ciser" },
                new Terrenos { Id = 3, Nome = "Terreno Loteamento Espinheiro", Area = 1000, Matricula = 5, Proprietaria = "Hacasa" },
                new Terrenos { Id = 4, Nome = "Terreno Loteamento Boa Vista", Area = 5000, Matricula = 8, Proprietaria = "Ciser" },
                new Terrenos { Id = 5, Nome = "Terreno Loteamento America", Area = 100, Matricula = 3, Proprietaria = "Ciser" },
                new Terrenos { Id = 6, Nome = "Chacara Campo Alegre", Area = 50000, Matricula = 2, Proprietaria = "Parana" },
                new Terrenos { Id = 7, Nome = "Sede Ciser", Area = 8000, Matricula = 1, Proprietaria = "Hacasa" }

                );
        }
    }
}

