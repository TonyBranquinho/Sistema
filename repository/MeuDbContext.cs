using Microsoft.EntityFrameworkCore;
using Sistema.modelos;

namespace Sistema.repository

{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}

