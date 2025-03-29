using Microsoft.EntityFrameworkCore;
using muriel_backend.Models;

namespace muriel_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // DbSet para as entidades
        public DbSet<User> Users { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        // Configurações adicionais de relacionamento, se necessário
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Defina aqui relacionamentos ou restrições adicionais, se necessário
        }
    }
}
