using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasDisciplinarias.API.Data;
using NotasDisciplinarias.API.DTOs;

namespace NotasDisciplinarias.API.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly NotasDbContext _context;

        public AdminController(NotasDbContext context)
        {
            _context = context;
        }

        // GET: api/admin/casos-activos/
       [HttpGet("casos-activos/{idJefe}")]
public async Task<IActionResult> GetCasosActivos(int idJefe)
{
    var casos = await (
        from c in _context.Casos
        join u in _context.Usuarios on c.IdUsuario equals u.Id_Usuario
        join cat in _context.Categorias on c.IdCategoria equals cat.Id_Categoria
        where u.Id_Jefe_Inmediato == idJefe
              && c.Estatus == 1
        select new CasoAdminResponseDto
        {
            IdCaso = c.IdCaso,
            IdUsuario = u.Id_Usuario,
            Empleado = u.Nombre_Completo,   // string
            Categoria = cat.Nombre,         // string
            Descripcion = c.Descripcion,
            FechaRegistro = c.FechaRegistro,
            Estatus = c.Estatus.ToString ()
        }
    ).ToListAsync();

    return Ok(casos);
}

    }
}
