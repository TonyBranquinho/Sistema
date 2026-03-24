using Microsoft.EntityFrameworkCore;
using Sistema.Modelos;

namespace Sistema.Repository

{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Terrenos> Terrenos { get; set; }
        public DbSet<Relatorios> Relatorios { get; set; }
        public DbSet<Foto> Foto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Foto>()
            .HasOne(f => f.Relatorios)
            .WithMany(r => r.Fotos)
            .HasForeignKey(f => f.RelatorioId);

            modelBuilder.Entity<Terrenos>().HasData(
                new Terrenos { Id = 1, Nome = "Casa do Baixo Quiriri", Area = 5000, Matricula = 767375, Proprietaria = "Hacasa", Cidade = "Joinville" },
                new Terrenos { Id = 2, Nome = "Casa do Alto Quiriri", Area = 10000, Matricula = 6537523, Proprietaria = "Ciser", Cidade = "Campo alegre" },
                new Terrenos { Id = 3, Nome = "Terreno Loteamento Espinheiro", Area = 1000, Matricula = 59375237, Proprietaria = "Hacasa", Cidade = "Sao Francisco do Sul" },
                new Terrenos { Id = 4, Nome = "Terreno Loteamento Boa Vista", Area = 5000, Matricula = 837539, Proprietaria = "Ciser", Cidade = "Joinville" },
                new Terrenos { Id = 5, Nome = "Terreno Loteamento America", Area = 100, Matricula = 31398375, Proprietaria = "Ciser", Cidade = "Sao Francisco do Sul" },
                new Terrenos { Id = 6, Nome = "Chacara Campo Alegre", Area = 50000, Matricula = 2697867, Proprietaria = "Parana", Cidade = "Campo alegre" },
                new Terrenos { Id = 7, Nome = "Sede Ciser", Area = 8000, Matricula = 1785, Proprietaria = "Hacasa", Cidade = "Joinville" }

                );
        }
    }
}

