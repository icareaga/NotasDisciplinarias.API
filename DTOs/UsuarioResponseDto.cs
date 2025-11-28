namespace NotasDisciplinarias.API.Models.DTOs
{
    public class UsuarioResponseDto
    {
        public int id_usuario { get; set; }
        public string Nombre_Completo { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public string? Area { get; set; }
        public string? Jefe_Inmediato { get; set; }
    }
}
