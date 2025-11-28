namespace NotasDisciplinarias.API.Models.DTOs
{
    public class UsuarioCreateDto
    {
        public string Nombre_Completo { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public string? Area { get; set; }
        public string? Jefe_Inmediato { get; set; }
    }
}
