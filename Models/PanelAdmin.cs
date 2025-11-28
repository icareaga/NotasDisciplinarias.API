using System.ComponentModel.DataAnnotations;

namespace NotasDisciplinarias.API.Models
{
    public class PanelAdmin
    {
        [Key]
        public int id_panel { get; set; }
        public int id_usuario { get; set; }
        public int id_caso { get; set; }

        public int acciones_realizadas { get; set; }
        public int evidencias_subidas { get; set; }
        public int documentos_generados { get; set; }

        public DateTime fecha_revision { get; set; } = DateTime.Now;
        public string? observaciones { get; set; }
    }
}
