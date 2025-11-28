using System.ComponentModel.DataAnnotations;

namespace NotasDisciplinarias.API.Models
{
    public class SeguimientoProceso
    {
        [Key]
        public int id_seguimiento { get; set; }
        public int id_paso { get; set; }

        public string? observaciones { get; set; }
        public string? responsable { get; set; }

        public DateTime fecha_actualizacion { get; set; } = DateTime.Now;
        public string estatus { get; set; } = "En proceso";
    }
}
