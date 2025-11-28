using System.ComponentModel.DataAnnotations;

namespace NotasDisciplinarias.API.Models
{
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }

        public string Nombre_Completo { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;

        public string? Area { get; set; }
        public string? jefe_inmediato { get; set; }
    }
}
