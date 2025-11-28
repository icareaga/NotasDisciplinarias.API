using System.ComponentModel.DataAnnotations;

namespace NotasDisciplinarias.API.Models
{
    public class Documento
    {
        [Key]
        public int id_documento { get; set; }
        public int id_caso { get; set; }

        public string? ruta_guardado { get; set; }
        public string? ruta_formato { get; set; }
    }
}
