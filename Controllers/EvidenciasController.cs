using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasDisciplinarias.API.Data;
using NotasDisciplinarias.API.Models;

namespace NotasDisciplinarias.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvidenciasController : ControllerBase
    {
        private readonly NotasDbContext _context;

        public EvidenciasController(NotasDbContext context)
        {
            _context = context;
        }

        // GET: api/Evidencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evidencias>>> GetEvidencias()
        {
            return await _context.Evidencias.ToListAsync();
        }

        // GET: api/Evidencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evidencias>> GetEvidencia(int id)
        {
            var evidencia = await _context.Evidencias.FindAsync(id);

            if (evidencia == null)
            {
                return NotFound();
            }

            return evidencia;
        }

        // POST: api/Evidencias
        [HttpPost]
        public async Task<ActionResult<Evidencias>> PostEvidencia(Evidencias evidencia)
        {
            _context.Evidencias.Add(evidencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvidencia), new { id = evidencia.IdEvidencia }, evidencia);
        }

        // DELETE: api/Evidencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvidencia(int id)
        {
            var evidencia = await _context.Evidencias.FindAsync(id);

            if (evidencia == null)
            {
                return NotFound();
            }

            _context.Evidencias.Remove(evidencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
