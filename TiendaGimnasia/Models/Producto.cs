
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaGimnasia.Models
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public int id_producto { get; set; }

        [Required, MaxLength(100)]
        public string nombre { get; set; } = string.Empty;

        public string? descripcion { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal precio { get; set; }

        public int stock { get; set; }

        [MaxLength(255)]
        public string? imagen_url { get; set; }

        // FK
        public int id_categoria { get; set; }

        // Navegación
        public Categoria? Categoria { get; set; }
    }
}
