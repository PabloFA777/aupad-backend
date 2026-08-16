namespace Aupad.DesarrolloApiNet.Modelos
{
    public class CategoriaSeguro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int? CategoriaPadreId { get; set; }
        public bool Activo { get; set; }
         public DateTime CreadoEn { get; set; }
         public DateTime ActualizadoEn { get; set; }
         public int? UsuarioCreoId { get; set; }
         public int? UsuarioActualizoId { get; set; }
         
    }
}