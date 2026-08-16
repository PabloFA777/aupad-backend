using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Negocio.Interfaces
{
    public interface IDocumentoPolizaNegocio
    {
        Task<List<DocumentoPoliza>> ObtenerPorPolizaIdAsync(int polizaId);
        Task<DocumentoPoliza?> ObtenerPorIdAsync(int id);
        Task<DocumentoPoliza> CrearAsync(DocumentoPoliza item);
        Task<bool> ActualizarAsync(DocumentoPoliza item);
        Task<bool> EliminarAsync(int id);
    }
}