namespace Aupad.DesarrolloApiNet.Modelos
{
    public enum PeriodicidadPago
    {
        mensual,
        anual
    }

    public enum MonedaPoliza
    {
        Soles,
        Dolares
    }

    public enum EstadoPoliza
    {
        vigente,
        vencida,
        anulada,
        renovada
    }

    public class Poliza
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int SeguroId { get; set; }
        public string NumeroPoliza { get; set; } = string.Empty;
        public int CompaniaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int? VigenciaMeses { get; set; }
        public string? Cobertura { get; set; }
        public decimal SumaAsegurada { get; set; }
        public PeriodicidadPago PeriodicidadPago { get; set; } = PeriodicidadPago.anual;
        public MonedaPoliza Moneda { get; set; } = MonedaPoliza.Soles;
        public decimal PrimaNeta { get; set; }
        public decimal ComisionPorcentaje { get; set; } = 0.00m;
        public DateTime? FechaNotificacion { get; set; }
        public int CuotasPendientes { get; set; } = 0;
        public int CuotasPagadas { get; set; } = 0;
        public int? PolizaAnteriorId { get; set; }
        public EstadoPoliza Estado { get; set; } = EstadoPoliza.vigente;
        public int? DocumentoPrincipalId { get; set; }
        public DateTime CreadoEn { get; set; } = DateTime.Now;
        public DateTime ActualizadoEn { get; set; } = DateTime.Now;
        public int? UsuarioCreoId { get; set; }
        public int? UsuarioActualizoId { get; set; }
    }
}
