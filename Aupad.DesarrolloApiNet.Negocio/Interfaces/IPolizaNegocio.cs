using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Negocio.Interfaces
{
    public interface IPolizaNegocio
    {
        Task<List<Poliza>> ObtenerTodosAsync();
        Task<List<Poliza>> ObtenerPorClienteIdAsync(int clienteId);
        Task<Poliza?> ObtenerPorIdAsync(int id);
        Task<Poliza> CrearAsync(Poliza item);
        Task<bool> ActualizarAsync(Poliza item);
        Task<bool> EliminarAsync(int id);
    }
}
