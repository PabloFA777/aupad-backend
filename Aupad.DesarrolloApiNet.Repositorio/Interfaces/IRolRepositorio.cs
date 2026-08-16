using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Repositorio.Interfaces
{
    public interface IRolRepositorio
    {
        Task<List<Rol>> ObtenerTodosAsync();
        Task<Rol?> ObtenerPorIdAsync(int id);
        Task<Rol> CrearAsync(Rol item);
        Task<bool> ActualizarAsync(Rol item);
        Task<bool> EliminarAsync(int id);
    }
}
