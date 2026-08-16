namespace Aupad.DesarrolloApiNet.Modelos.Dtos
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expira { get; set; }
        public int UsuarioId { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}