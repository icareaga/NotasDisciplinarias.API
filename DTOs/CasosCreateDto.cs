using System.ComponentModel.DataAnnotations;

namespace NotasDisciplinarias.API.DTOs
{
    public class CasosCreateDto
    {
        [Required]
        public int Id_usuario { get; set; }

        [Required]
        public int Id_categoria { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;
    }
}
