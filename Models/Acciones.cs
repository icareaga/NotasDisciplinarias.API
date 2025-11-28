using System.ComponentModel.DataAnnotations;

namespace NotasDisciplinarias.API.Models
{
    public class Accion
    {
        [Key]
        public int id_accion { get; set; }

        public int id_caso { get; set; }
        public string plan { get; set; }
        public DateTime? fecha_cumpl { get; set; }
        public string responsable { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_actualizacion { get; set; }
    }
}
