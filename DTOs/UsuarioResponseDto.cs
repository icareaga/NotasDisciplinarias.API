namespace NotasDisciplinarias.API.DTOs
{
    public class UsuarioResponseDto
    {
        public int Id { get; set; }
        public string Rol { get; set; } = "";
        public string Nombre_Completo { get; set; } = "";
        public string Correo { get; set; } = "";
    }
}
