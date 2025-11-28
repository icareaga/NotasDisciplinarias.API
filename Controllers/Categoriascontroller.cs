
[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly NotasDbContext _context;
    private readonly IMapper _mapper;

    public CategoriasController(NotasDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Categorias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaResponseDto>>> GetCategorias()
    {
        var categorias = await _context.Categorias.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<CategoriaResponseDto>>(categorias));
    }

    // GET: api/Categorias/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaResponseDto>> GetCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null) return NotFound();
        return Ok(_mapper.Map<CategoriaResponseDto>(categoria));
    }

    // POST: api/Categorias
    [HttpPost]
    public async Task<ActionResult<CategoriaResponseDto>> CreateCategoria([FromBody] CategoriaCreateDto dto)
    {
        var categoria = _mapper.Map<Categorias>(dto);
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, _mapper.Map<CategoriaResponseDto>(categoria));
    }

    // PUT: api/Categorias/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CategoriaCreateDto dto)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null) return NotFound();

        _mapper.Map(dto, categoria);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/Categorias/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null) return NotFound();

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
