using System.ComponentModel.DataAnnotations;
namespace NotasDisciplinarias.API.Models
{
    public class Evidencia
    {
        [Key]
        public int Id { get; set; }   // <-- ESTA ES LA QUE FALTA
        public int id_caso { get; set; }
        public string tipo_archivo { get; set; }
        public DateTime fecha_subida { get; set; }
        
        public Caso Caso { get; set; } // FK
    }
}
