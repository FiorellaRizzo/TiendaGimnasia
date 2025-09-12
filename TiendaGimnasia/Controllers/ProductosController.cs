using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaGimnasia.Data;              // TiendaContext
using TiendaGimnasia.Models;            // Entidades (Producto, Categoria)
using TiendaGimnasia.Shared.DTOs;       // DTOs compartidos

namespace TiendaGimnasia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly TiendaContext _context;

        public ProductosController(TiendaContext context)
        {
            _context = context;
        }

        // =========================
        // GET: api/productos
        // =========================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
        {
            var items = await _context.Productos
                .Include(p => p.Categoria)
                .Select(p => MapToDto(p))
                .ToListAsync();

            return items;
        }

        // =========================
        // GET: api/productos/5
        // =========================
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoDTO>> GetProducto(int id)
        {
            var prod = await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.id_producto == id);

            if (prod == null) return NotFound();

            return MapToDto(prod);
        }

        // =========================
        // POST: api/productos
        // =========================
        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> PostProducto(ProductoCreateDTO dto)
        {
            var entity = new Producto
            {
                nombre = dto.nombre,
                descripcion = dto.descripcion,
                precio = dto.precio,
                stock = dto.stock,
                imagen_url = dto.imagen_url,
                id_categoria = dto.id_categoria
            };

            _context.Productos.Add(entity);
            await _context.SaveChangesAsync();

            // recargar con la categoría para devolver el nombre
            await _context.Entry(entity).Reference(p => p.Categoria).LoadAsync();

            var result = MapToDto(entity);
            return CreatedAtAction(nameof(GetProducto), new { id = entity.id_producto }, result);
        }

        // =========================
        // PUT: api/productos/5
        // =========================
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutProducto(int id, ProductoUpdateDTO dto)
        {
            if (id != dto.id_producto) return BadRequest();

            var entity = await _context.Productos.FindAsync(id);
            if (entity == null) return NotFound();

            entity.nombre = dto.nombre;
            entity.descripcion = dto.descripcion;
            entity.precio = dto.precio;
            entity.stock = dto.stock;
            entity.imagen_url = dto.imagen_url;
            entity.id_categoria = dto.id_categoria;

            // marcamos como modificado y guardamos
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // =========================
        // DELETE: api/productos/5
        // =========================
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var entity = await _context.Productos.FindAsync(id);
            if (entity == null) return NotFound();

            _context.Productos.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // =========================
        // Helper de mapeo
        // =========================
        private static ProductoDTO MapToDto(Producto p) => new()
        {
            id_producto = p.id_producto,
            nombre = p.nombre ?? string.Empty,
            descripcion = p.descripcion,
            precio = p.precio,
            stock = p.stock,
            imagen_url = p.imagen_url,
            id_categoria = p.id_categoria,
            categoria_nombre = p.Categoria?.nombre
        };
    }
}
