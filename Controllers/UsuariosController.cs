using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasDisciplinarias.API.Data;
using NotasDisciplinarias.API.Models;
using NotasDisciplinarias.API.Models.DTOs;

namespace NotasDisciplinarias.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly NotasDbContext _context;

        public UsuariosController(NotasDbContext context)
        {
            _context = context;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDto>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Select(u => new UsuarioResponseDto
                {
                    id_usuario = u.id_usuario,
                    Nombre_Completo = u.Nombre_Completo,
                    Correo = u.Correo,
                    Rol = u.Rol,
                    Area = u.Area,
                    Jefe_Inmediato = u.jefe_inmediato
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDto>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound("Usuario no encontrado.");

            var dto = new UsuarioResponseDto
            {
                id_usuario = usuario.id_usuario,
                Nombre_Completo = usuario.Nombre_Completo,
                Correo = usuario.Correo,
                Rol = usuario.Rol,
                Area = usuario.Area,
                Jefe_Inmediato = usuario.jefe_inmediato
            };

            return Ok(dto);
        }

        // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDto>> CrearUsuario(UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuario
            {
                Nombre_Completo = dto.Nombre_Completo,
                Correo = dto.Correo,
                Contrasena = dto.Contrasena, // ojo: después agregamos encriptación
                Rol = dto.Rol,
                Area = dto.Area,
                jefe_inmediato = dto.Jefe_Inmediato
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.id_usuario }, usuario);
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, UsuarioUpdateDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound("Usuario no encontrado.");

            usuario.Nombre_Completo = dto.Nombre_Completo;
            usuario.Rol = dto.Rol;
            usuario.Area = dto.Area;
            usuario.jefe_inmediato = dto.Jefe_Inmediato;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound("Usuario no encontrado.");

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
