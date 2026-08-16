using Aupad.DesarrolloApiNet.Modelos.Dtos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioNegocio _usuarioNegocio;
        private readonly IRolNegocio _rolNegocio;
        private readonly IConfiguration _configuration;

        public AuthController(IUsuarioNegocio usuarioNegocio, IRolNegocio rolNegocio, IConfiguration configuration)
        {
            _usuarioNegocio = usuarioNegocio;
            _rolNegocio = rolNegocio;
            _configuration = configuration;
        }

        /// <summary>
        /// Autentica a un usuario y devuelve un token JWT
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var usuario = await _usuarioNegocio.ObtenerPorCorreoAsync(request.Correo);
            if (usuario == null)
                return Unauthorized(new { mensaje = "Correo o contraseña incorrectos." });

            var passwordValida = BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash);
            if (!passwordValida)
                return Unauthorized(new { mensaje = "Correo o contraseña incorrectos." });

            if (usuario.Estado != Modelos.EstadoUsuario.activo)
                return Unauthorized(new { mensaje = "El usuario está inactivo." });

            var rol = await _rolNegocio.ObtenerPorIdAsync(usuario.RolId);
            var nombreRol = rol?.Nombre ?? "SinRol";

            var jwtKey = _configuration["Jwt:Key"]!;
            var jwtIssuer = _configuration["Jwt:Issuer"]!;
            var jwtAudience = _configuration["Jwt:Audience"]!;
            var minutos = int.Parse(_configuration["Jwt:ExpiracionMinutos"] ?? "120");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.Name, $"{usuario.Nombre} {usuario.Apellido}"),
                new Claim(ClaimTypes.Role, nombreRol)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expira = DateTime.UtcNow.AddMinutes(minutos);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: expira,
                signingCredentials: credenciales
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new LoginResponse
            {
                Token = tokenString,
                Expira = expira,
                UsuarioId = usuario.Id,
                NombreCompleto = $"{usuario.Nombre} {usuario.Apellido}",
                Rol = nombreRol
            });
        }
    }
}