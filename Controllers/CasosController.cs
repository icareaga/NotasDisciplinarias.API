using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasDisciplinarias.API.Data;
using NotasDisciplinarias.API.DTOs;
using NotasDisciplinarias.API.Models;

[ApiController]
[Route("api/[controller]")]
public class CasosController : ControllerBase
{
    private readonly NotasDbContext _context;

    public CasosController(NotasDbContext context)
    {
        _context = context;
    }

    [HttpPost("crear")]
    public async Task<IActionResult> CrearCaso([FromBody] CasosCreateDto dto)
    {
            var caso = new Casos
        {
            IdUsuario = dto.Id_usuario,
            IdCategoria = dto.Id_categoria,
            Descripcion = dto.Descripcion,
            FechaRegistro = DateTime.Now,
            Estatus = 1
        };


        _context.Casos.Add(caso);
        await _context.SaveChangesAsync();

        return Ok(caso);
    }
}
