namespace Aupad.DesarrolloApiNet.Modelos
{
    public class DocumentoPoliza
    {
        public int Id { get; set; }
        public int PolizaId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NombreArchivo { get; set; } = string.Empty;
        public string UrlArchivo { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public DateTime CreadoEn { get; set; } = DateTime.Now;
        public DateTime ActualizadoEn { get; set; } = DateTime.Now;
        public int? UsuarioCreoId { get; set; }
        public int? UsuarioActualizoId { get; set; }
    }
}
