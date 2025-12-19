using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotasDisciplinarias.API.Models
{
    [Table("Casos")]
    public class Casos
    {
        [Key]
        [Column("id_caso")]
        public int IdCaso { get; set; }

        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("fecha_registro")]
        public DateTime FechaRegistro { get; set; }

        [Column("estatus")]
        public int Estatus { get; set; }
        
    }
}
