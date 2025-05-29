using Microsoft.EntityFrameworkCore;

namespace Proyecto.Data
{
    public class BDDirectorioDBContext : DbContext
    {
        public BDDirectorioDBContext(DbContextOptions<BDDirectorioDBContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<EstiloVida> EstilosVida { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación muchos a muchos entre Usuario y EstiloVida
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.EstilosVida)
                .WithMany(e => e.Usuarios);
        }
    }
}
