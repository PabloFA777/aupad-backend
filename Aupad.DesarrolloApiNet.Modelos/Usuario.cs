namespace Aupad.DesarrolloApiNet.Modelos
{
    public enum EstadoUsuario
    {
        activo,
        inactivo
    }

    public class Usuario
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public EstadoUsuario Estado { get; set; } = EstadoUsuario.activo;
        public bool IngresoConfirmado { get; set; } = false;
        public bool RequiereCambioPassword { get; set; } = false;
        public DateTime CreadoEn { get; set; } = DateTime.Now;
        public DateTime ActualizadoEn { get; set; } = DateTime.Now;
        public int? UsuarioCreoId { get; set; }
        public int? UsuarioActualizoId { get; set; }
    }
}
