namespace TiendaGimnasia.Shared.DTOs;

// Para respuestas (GET)
public class ProductoDTO
{
    public int id_producto { get; set; }
    public string nombre { get; set; } = string.Empty;
    public string? descripcion { get; set; }
    public decimal precio { get; set; }
    public int stock { get; set; }
    public string? imagen_url { get; set; }
    public int id_categoria { get; set; }
    public string? categoria_nombre { get; set; } // opcional para la grilla
}

// Para creación (POST)
public class ProductoCreateDTO
{
    public string nombre { get; set; } = string.Empty;
    public string? descripcion { get; set; }
    public decimal precio { get; set; }
    public int stock { get; set; }
    public string? imagen_url { get; set; }
    public int id_categoria { get; set; }
}

// Para actualización (PUT)
public class ProductoUpdateDTO
{
    public int id_producto { get; set; }
    public string nombre { get; set; } = string.Empty;
    public string? descripcion { get; set; }
    public decimal precio { get; set; }
    public int stock { get; set; }
    public string? imagen_url { get; set; }
    public int id_categoria { get; set; }
}
