using System.ComponentModel.DataAnnotations;

namespace NotasDisciplinarias.API.Models
{
    public class Paso
    {
        [Key]
        public int id_paso { get; set; }
        public int id_caso { get; set; }

        public string nombre_paso { get; set; } = string.Empty;
        public string? descripcion { get; set; }

        public DateTime fecha_inicio { get; set; } = DateTime.Now;
        public DateTime? fecha_fin { get; set; }

        public string estado { get; set; } = "Pendiente";
    }
}
