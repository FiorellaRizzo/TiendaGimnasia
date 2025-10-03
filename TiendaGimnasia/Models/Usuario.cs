using System.ComponentModel.DataAnnotations;

namespace TiendaGimnasia.Models
{
    public class Usuario
    {
       
            [Key]                       // <- indicar PK
            public int id_usuario { get; set; }

            public string? nombre { get; set; }
            public string? apellido { get; set; }
            public string? email { get; set; }
            public string? contrasena { get; set; }
            public string? telefono { get; set; }
            public string? direccion { get; set; }
            public string? tipo_usuario { get; set; }
        }
    }

