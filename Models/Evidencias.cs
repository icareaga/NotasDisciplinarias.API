using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    namespace NotasDisciplinarias.API.Models
    {
        [Table("Evidencias")]
        public class Evidencias
        {
            [Key]
            [Column("id_evidencia")]
            public int IdEvidencia { get; set; }

            [Column("id_caso")]
            public int IdCaso { get; set; }

            [Column("ruta_archivo")]
            public string RutaArchivo { get; set; } = string.Empty;

            [Column("fecha_registro")]
            public DateTime FechaRegistro { get; set; }
        }

}
