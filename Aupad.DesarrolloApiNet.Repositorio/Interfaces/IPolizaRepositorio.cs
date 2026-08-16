using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Repositorio.Interfaces
{
    public interface IPolizaRepositorio
    {
        Task<List<Poliza>> ObtenerTodosAsync();
        Task<List<Poliza>> ObtenerPorClienteIdAsync(int clienteId);
        Task<Poliza?> ObtenerPorIdAsync(int id);
        Task<Poliza> CrearAsync(Poliza item);
        Task<bool> ActualizarAsync(Poliza item);
        Task<bool> EliminarAsync(int id);
    }
}
