using System.ComponentModel.DataAnnotations.Schema;

namespace NotasDisciplinarias.API.Models
{
    
[Table("Usuarios(sin_uso)")]
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Rol { get; set; } = "";
        public bool Activo { get; set; }
    }
}
