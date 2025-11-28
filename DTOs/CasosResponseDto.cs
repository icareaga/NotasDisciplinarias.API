namespace NotasDisciplinarias.API.Models.DTOs
{
    public class CasoResponseDto
    {
        public int id_caso { get; set; }
        public string Usuario { get; set; }
        public string Categoria { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha_Registro { get; set; }
    }
}
