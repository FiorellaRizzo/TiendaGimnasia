using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaGimnasia.Models
{
    [Table("Categorias")]  // la clase Categoria representa la tabla Categorias que ya existe en SQL Server.
    public class Categoria
    {
        [Key]
        public int id_categoria { get; set; }

        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
    }
}
