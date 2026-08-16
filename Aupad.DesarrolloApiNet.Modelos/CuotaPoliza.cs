namespace Aupad.DesarrolloApiNet.Modelos
{
    public enum EstadoCuota
    {
        pendiente,
        pagada,
        vencida
    }

    public enum MetodoPagoCuota
    {
        transferencia,
        efectivo,
        tarjeta,
        yape,
        plin
    }

    public class CuotaPoliza
    {
        public int Id { get; set; }
        public int PolizaId { get; set; }
        public int NumeroCuota { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaVencimientoCuota { get; set; }
        public EstadoCuota Estado { get; set; } = EstadoCuota.pendiente;
        public decimal? MontoPagado { get; set; }
        public DateTime? FechaPago { get; set; }
        public MetodoPagoCuota? MetodoPago { get; set; }
        public DateTime CreadoEn { get; set; } = DateTime.Now;
        public DateTime ActualizadoEn { get; set; } = DateTime.Now;
        public int? UsuarioCreoId { get; set; }
        public int? UsuarioActualizoId { get; set; }
    }
}
