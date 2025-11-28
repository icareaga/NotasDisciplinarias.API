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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evidencia>>> GetEvidencias()
        {
            return await _context.Evidencias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evidencia>> GetEvidencia(int id)
        {
            var evidencia = await _context.Evidencias.FindAsync(id);
            if (evidencia == null) return NotFound();
            return evidencia;
        }

        [HttpPost]
        public async Task<ActionResult<Evidencia>> PostEvidencia(Evidencia evidencia)
        {
            _context.Evidencias.Add(evidencia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvidencia), new { id = evidencia.Id }, evidencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvidencia(int id, Evidencia evidencia)
        {
            if (id != evidencia.Id) return BadRequest();
            _context.Entry(evidencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvidencia(int id)
        {
            var evidencia = await _context.Evidencias.FindAsync(id);
            if (evidencia == null) return NotFound();
            _context.Evidencias.Remove(evidencia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}