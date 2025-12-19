using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotasDisciplinarias.API.Models
{
    public class Categoria
    {
        [Key]
        [Column("id_categoria")]
        public int Id_Categoria { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

    }
}
