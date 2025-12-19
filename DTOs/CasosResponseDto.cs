namespace NotasDisciplinarias.API.DTOs
{
    public class CasosResponseDto
    {
        public int Id { get; set; }
        public required string Empleado { get; set; }
        public required string Motivo { get; set; }
        public required string LevantadoPor { get; set; }
        public required string PasoActual { get; set; }
       public int Estado { get; set; }

        public DateTime Fecha { get; set; }
    }
}
