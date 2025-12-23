using NotasDisciplinarias.API.Models.DTOs;
namespace NotasDisciplinarias.API.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = "";
        public UsuarioResponseDto Usuario { get; set; } = new();
    }
}
