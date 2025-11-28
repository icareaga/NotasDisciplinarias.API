
using System.ComponentModel.DataAnnotations;
namespace NotasDisciplinarias.API.Models
{
    public class Categoria
    {
        [Key]



        public int id_categoria { get; set; }

        public string nombre { get; set; } = string.Empty;
        public string? descripcion { get; set; }
    }
}
