namespace Aupad.DesarrolloApiNet.Modelos;

public class TipoDocumento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Activo { get; set; }
    public DateTime CreadoEn { get; set; }
    public DateTime ActualizadoEn { get; set; }
    public int? UsuarioCreoId { get; set; }
    public int? UsuarioActualizoId { get; set; }
}
