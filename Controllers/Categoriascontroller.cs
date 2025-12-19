using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasDisciplinarias.API.Data;
using NotasDisciplinarias.API.Models;

namespace NotasDisciplinarias.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly NotasDbContext _context;

        public CategoriasController(NotasDbContext context)
        {
            _context = context;
        }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
    {
        return await _context.Categorias.ToListAsync();
    }


    }
    
}
