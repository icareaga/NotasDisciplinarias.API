using System.ComponentModel.DataAnnotations;

namespace NotasDisciplinarias.API.Models.DTOs
{
    public class CasoCreateDto
    {
        [Required]
        public int id_usuario { get; set; }

        [Required]
        public int id_categoria { get; set; }

        public string? descripcion { get; set; }
    }
}
