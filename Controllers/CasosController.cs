using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasDisciplinarias.API.Data;
using NotasDisciplinarias.API.Models;
using NotasDisciplinarias.API.Models.DTOs;

namespace NotasDisciplinarias.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CasosController : ControllerBase
    {
        private readonly NotasDbContext _context;

        public CasosController(NotasDbContext context)
        {
            _context = context;
        }

        // GET: api/casos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CasoResponseDto>>> GetCasos()
        {
            var casos = await _context.Casos
                .Include(c => c.Usuario)
                .Include(c => c.Categoria)
                .Select(c => new CasoResponseDto
                {
                    id_caso = c.id_caso,
                    Usuario = c.Usuario.Nombre_Completo,
                    Categoria = c.Categoria.nombre,
                    Descripcion = c.descripcion,
                    Fecha_Registro = c.fecha_registro
                })
                .ToListAsync();

            return Ok(casos);
        }

        // GET: api/casos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CasoResponseDto>> GetCaso(int id)
        {
            var caso = await _context.Casos
                .Include(c => c.Usuario)
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(c => c.id_caso == id);

            if (caso == null)
                return NotFound("Caso no encontrado.");

            var dto = new CasoResponseDto
            {
                id_caso = caso.id_caso,
                Usuario = caso.Usuario.Nombre_Completo,
                Categoria = caso.Categoria.nombre,
                Descripcion = caso.descripcion,
                Fecha_Registro = caso.fecha_registro
            };

            return Ok(dto);
        }

        // POST: api/casos
        [HttpPost]
        public async Task<ActionResult<CasoResponseDto>> CrearCaso(CasoCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validar usuario
            var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.id_usuario == dto.id_usuario);
            if (!usuarioExiste)
                return BadRequest("El usuario indicado no existe.");

            // Validar categoría
            var categoriaExiste = await _context.Categorias.AnyAsync(c => c.id_categoria == dto.id_categoria);
            if (!categoriaExiste)
                return BadRequest("La categoría indicada no existe.");

            var caso = new Caso
            {
                id_usuario = dto.id_usuario,
                id_categoria = dto.id_categoria,
                descripcion = dto.descripcion,
                fecha_registro = DateTime.Now
            };

            _context.Casos.Add(caso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCaso), new { id = caso.id_caso }, caso);
        }

        // PUT: api/casos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCaso(int id, CasoCreateDto dto)
        {
            var caso = await _context.Casos.FindAsync(id);

            if (caso == null)
                return NotFound("Caso no encontrado.");

            caso.id_usuario = dto.id_usuario;
            caso.id_categoria = dto.id_categoria;
            caso.descripcion = dto.descripcion;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/casos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCaso(int id)
        {
            var caso = await _context.Casos.FindAsync(id);

            if (caso == null)
                return NotFound("Caso no encontrado.");

            _context.Casos.Remove(caso);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
