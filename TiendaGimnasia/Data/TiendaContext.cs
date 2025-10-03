using Microsoft.EntityFrameworkCore;
using TiendaGimnasia.Models; 



namespace TiendaGimnasia.Data
{
    public class TiendaContext : DbContext
    {
      
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; } = null!;

        public DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.id_categoria)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
