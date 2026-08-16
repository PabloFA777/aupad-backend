using Aupad.DesarrolloApiNet.Modelos;
namespace Aupad.DesarrolloApiNet.Repositorio.Interfaces

{
    public interface ITipoDocumentoRepositorio
    {
        Task<List<TipoDocumento>> ObtenerTodosAsync();
        Task<TipoDocumento?> ObtenerPorIdAsync(int id);
        Task<TipoDocumento> CrearAsync(TipoDocumento tipoDocumento);
        Task<bool> ActualizarAsync(TipoDocumento tipoDocumento);
        Task<bool> EliminarAsync(int id);
    }
}
