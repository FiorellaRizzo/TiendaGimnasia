using Microsoft.EntityFrameworkCore;
using TiendaGimnasia.Models; 



namespace TiendaGimnasia.Data
{
    public class TiendaContext : DbContext
    {
      
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
