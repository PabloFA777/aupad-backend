using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Negocio.Interfaces
{
    public interface IClienteNegocio
    {
        Task<List<Cliente>> ObtenerTodosAsync();
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task<Cliente> CrearAsync(Cliente item);
        Task<bool> ActualizarAsync(Cliente item);
        Task<bool> EliminarAsync(int id);
    }
}
