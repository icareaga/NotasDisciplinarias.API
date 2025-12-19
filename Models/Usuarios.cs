using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotasDisciplinarias.API.Models
{
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int Id_Usuario { get; set; }

        [Column("Nombre_Completo")]
        public string Nombre_Completo { get; set; } = string.Empty;

        [Column("Rol")]
        public string Rol { get; set; } = string.Empty;

        [Column("Area")]
        public string Area { get; set; } = string.Empty;

        [Column("id_jefe_inmediato")]
        public int? Id_Jefe_Inmediato { get; set; }

    }
}
