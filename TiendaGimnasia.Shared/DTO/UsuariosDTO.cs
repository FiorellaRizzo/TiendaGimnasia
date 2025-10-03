namespace TiendaGimnasia.Shared.DTOs
{
    // Lo que se muestra en la tabla / GET
    public class UsuarioDTO
    {
        public int id_usuario { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? email { get; set; }
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public string? tipo_usuario { get; set; } // puede ser cliente , administrador, etc.
    }

    // Para crear
    public class UsuarioCreateDTO
    {
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? email { get; set; }
        public string? contrasena { get; set; }     
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public string? tipo_usuario { get; set; }  
    }

    // Para actualizar (la contraseña la dejamos opcional)
    public class UsuarioUpdateDTO
    {
        public int id_usuario { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? email { get; set; }
        public string? contrasena { get; set; }     // null = no cambia
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public string? tipo_usuario { get; set; }
    }
}
