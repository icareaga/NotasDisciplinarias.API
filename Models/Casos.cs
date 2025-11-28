using System.ComponentModel.DataAnnotations;
namespace NotasDisciplinarias.API.Models
{
    public class Caso
    {
        [Key]
        public int id_caso { get; set; }

        public int id_usuario { get; set; }
        public int id_categoria { get; set; }

        public Usuario Usuario { get; set; }
        public Categoria Categoria { get; set; }

        public string? descripcion { get; set; }
        public DateTime fecha_registro { get; set; } = DateTime.Now;
    }
}
