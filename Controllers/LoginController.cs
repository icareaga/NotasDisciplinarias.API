using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NotasDisciplinarias.API.Data;
using NotasDisciplinarias.API.DTOs;
using NotasDisciplinarias.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Humanizer;
using Microsoft.AspNetCore.Authorization;

namespace NotasDisciplinarias.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly NotasDbContext _context;
        private readonly IConfiguration _config;

        public LoginController(NotasDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            /* 1) Buscar credenciales en tabla Usuarios
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Usuario == request.Usuario && u.Activo);

            if (user == null)
                return Unauthorized("Usuario o contraseña incorrectos");

            // 2) Validar password con BCrypt
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return Unauthorized("Usuario o contraseña incorrectos");*/

            // 3) Cargar datos del empleado desde la vista
            var vista = await _context.UsuariosVista
                .FirstOrDefaultAsync(v => v.id == Int32.Parse(request.UserId));

            if (vista == null)
                return Unauthorized("No se encontró información del colaborador en UsuariosVista");

          
            // 4) Claims
            var claims = new List<Claim>
            {
                new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, vista.id.ToString()),
                new System.Security.Claims.Claim("Role", vista.rol),

                new System.Security.Claims.Claim("Nombre", vista.Nombre_Completo),
                new System.Security.Claims.Claim("Correo", vista.correo),
                new System.Security.Claims.Claim("Area", vista.area),
                new System.Security.Claims.Claim("Departamento", vista.departamento),
                new System.Security.Claims.Claim("Plaza", vista.plaza.ToString()),
                new System.Security.Claims.Claim("PlazaJefe", vista.plaza_jefe.ToString())

            };

            var token = GenerarToken(claims);

            // 5) Response
            /*  var response = new LoginResponseDto
              {
                  Token = token,
                  Usuario = new UsuarioResponseDto
                  {
                      Id = vista.id,
                      Rol = vista.rol,
                      Nombre_Completo = vista.Nombre_Completo,
                      Correo = vista.correo
                  },
                  ejec
              };
            */
            var url = "http://localhost:4200/login?acces_token=" + token;
            return Ok(new { ejecucion = true, link = url, data =  new {
                Id = vista.id,
                      Rol = vista.rol,
                      Nombre_Completo = vista.Nombre_Completo,
                      Correo = vista.correo
                  }
        });

          
        }

        private string GenerarToken(List<Claim> claims)
        {
            var key = _config["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key no configurada");
            var issuer = _config["Jwt:Issuer"] ?? throw new InvalidOperationException("Jwt:Issuer no configurado");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
