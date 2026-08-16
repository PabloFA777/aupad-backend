namespace Aupad.DesarrolloApiNet.Modelos
{
    public class Seguro
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime CreadoEn { get; set; } = DateTime.Now;
        public DateTime ActualizadoEn { get; set; } = DateTime.Now;
        public int? UsuarioCreoId { get; set; }
        public int? UsuarioActualizoId { get; set; }
    }
}
