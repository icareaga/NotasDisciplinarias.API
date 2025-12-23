using Microsoft.EntityFrameworkCore;
namespace NotasDisciplinarias.API.Models
{
    [Keyless]
    public class UsuariosVista
    {
        public int id { get; set; }
        public string Nombre_Completo { get; set; } = "";
        public string area { get; set; } = "";
        public string puesto { get; set; } = "";
        public string departamento { get; set; } = "";
        public int? id_jefe_inmediato { get; set; }
        public string plaza { get; set; } = "";
        public string plaza_jefe { get; set; } = "";
        public string correo { get; set; } = "";
    }
}