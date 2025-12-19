namespace NotasDisciplinarias.API.DTOs
{
    public class CasoAdminResponseDto
    {
        public int IdCaso { get; set; }
        public int IdUsuario { get; set; }
        public string Empleado { get; set; } = "";
        public string Categoria { get; set; }  = "";
        public string Descripcion { get; set; }  = "";
        public DateTime FechaRegistro { get; set; }
        public string Estatus { get; set; } = "";
    }
}
