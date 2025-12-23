using Microsoft.EntityFrameworkCore;
using NotasDisciplinarias.API.Models;

namespace NotasDisciplinarias.API.Data
{
    public class NotasDbContext : DbContext
    {
        public NotasDbContext(DbContextOptions<NotasDbContext> options)
            : base(options)
        {
        }

       // TABLAS
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Casos> Casos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Evidencias> Evidencias { get; set; }


        // VISTAS
        public DbSet<UsuariosVista> UsuariosVista { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo de la vista UsuariosVista
            modelBuilder.Entity<UsuariosVista>()
                .ToView("UsuariosVista")
                .HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
