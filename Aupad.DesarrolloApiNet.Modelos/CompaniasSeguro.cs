namespace Aupad.DesarrolloApiNet.Modelos
{
    public class CompaniaSeguro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Ruc { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public string? PaginaWeb { get; set; }
        public string? ContactoComercial { get; set; }
        public bool Activo { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
        public int? UsuarioCreoId { get; set; }
        public int? UsuarioActualizoId { get; set; }
    }
}