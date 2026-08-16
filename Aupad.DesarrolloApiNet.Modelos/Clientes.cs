namespace Aupad.DesarrolloApiNet.Modelos
{
    public enum TipoCliente
    {
        natural,
        juridica
    }

    public enum TipoDocumentoCliente
    {
        DNI,
        RUC,
        PASAPORTE,
        CE
    }

    public class Cliente
    {
        public int Id { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public TipoDocumentoCliente TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; } = string.Empty;
        public string NombreRazonSocial { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? Observaciones { get; set; }
        public int UsuarioId { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime CreadoEn { get; set; } = DateTime.Now;
        public DateTime ActualizadoEn { get; set; } = DateTime.Now;
        public int? UsuarioCreoId { get; set; }
        public int? UsuarioActualizoId { get; set; }
    }
}