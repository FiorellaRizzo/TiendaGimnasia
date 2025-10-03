using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaGimnasia.Data;
using TiendaGimnasia.Models;
using TiendaGimnasia.Shared.DTOs;

namespace TiendaGimnasia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly TiendaContext _context;
        public UsuariosController(TiendaContext context) => _context = context;

        // GET api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        {
            var list = await _context.Usuarios
                .OrderBy(u => u.nombre).ThenBy(u => u.apellido)
                .Select(u => new UsuarioDTO
                {
                    id_usuario = u.id_usuario,
                    nombre = u.nombre,
                    apellido = u.apellido,
                    email = u.email,
                    telefono = u.telefono,
                    direccion = u.direccion,
                    tipo_usuario = u.tipo_usuario
                })
                .ToListAsync();

            return Ok(list);
        }

        // GET api/usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var u = await _context.Usuarios.FindAsync(id);
            if (u is null) return NotFound();

            return new UsuarioDTO
            {
                id_usuario = u.id_usuario,
                nombre = u.nombre,
                apellido = u.apellido,
                email = u.email,
                telefono = u.telefono,
                direccion = u.direccion,
                tipo_usuario = u.tipo_usuario
            };
        }

        // POST api/usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Post(UsuarioCreateDTO dto)
        {
            var u = new Usuario
            {
                nombre = dto.nombre,
                apellido = dto.apellido,
                email = dto.email,
                contrasena = dto.contrasena,   // TODO: hashear si querés
                telefono = dto.telefono,
                direccion = dto.direccion,
                tipo_usuario = dto.tipo_usuario
            };
            _context.Usuarios.Add(u);
            await _context.SaveChangesAsync();

            var result = new UsuarioDTO
            {
                id_usuario = u.id_usuario,
                nombre = u.nombre,
                apellido = u.apellido,
                email = u.email,
                telefono = u.telefono,
                direccion = u.direccion,
                tipo_usuario = u.tipo_usuario
            };
            return CreatedAtAction(nameof(Get), new { id = u.id_usuario }, result);
        }

        // PUT api/usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UsuarioUpdateDTO dto)
        {
            if (id != dto.id_usuario) return BadRequest();

            var u = await _context.Usuarios.FindAsync(id);
            if (u is null) return NotFound();

            u.nombre = dto.nombre;
            u.apellido = dto.apellido;
            u.email = dto.email;
            if (!string.IsNullOrWhiteSpace(dto.contrasena))
                u.contrasena = dto.contrasena; // TODO: hashear
            u.telefono = dto.telefono;
            u.direccion = dto.direccion;
            u.tipo_usuario = dto.tipo_usuario;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var u = await _context.Usuarios.FindAsync(id);
            if (u is null) return NotFound();

            _context.Usuarios.Remove(u);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
