namespace Aupad.DesarrolloApiNet.Modelos
{
    public enum EstadoBeneficiario
    {
        Activo,
        Retirado
    }

    public class BeneficiarioPoliza
    {
        public int Id { get; set; }
        public int PolizaId { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string? Cargo { get; set; }
        public decimal? Remuneracion { get; set; }
        public byte Mes { get; set; }
        public short Anio { get; set; }
        public EstadoBeneficiario Estado { get; set; } = EstadoBeneficiario.Activo;
        public DateTime CreadoEn { get; set; } = DateTime.Now;
        public DateTime ActualizadoEn { get; set; } = DateTime.Now;
        public int? UsuarioCreoId { get; set; }
        public int? UsuarioActualizoId { get; set; }
    }
}
