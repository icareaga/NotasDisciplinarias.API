using Microsoft.EntityFrameworkCore;
using NotasDisciplinarias.API.Models;

using Microsoft.EntityFrameworkCore;
using NotasDisciplinarias.API.Models;

namespace NotasDisciplinarias.API.Data
{
    public class NotasDbContext : DbContext
    {
        public NotasDbContext(DbContextOptions<NotasDbContext> options) : base(options) {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Caso> Casos { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<Evidencia> Evidencias { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Paso> Pasos { get; set; }
        public DbSet<SeguimientoProceso> SeguimientoProcesos { get; set; }
        public DbSet<PanelAdmin> PanelAdmin { get; set; }
    }
}
