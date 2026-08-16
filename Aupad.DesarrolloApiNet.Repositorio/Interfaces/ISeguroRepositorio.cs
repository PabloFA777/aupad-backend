using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Repositorio.Interfaces
{
    public interface ISeguroRepositorio
    {
        Task<List<Seguro>> ObtenerTodosAsync();
        Task<Seguro?> ObtenerPorIdAsync(int id);
        Task<Seguro> CrearAsync(Seguro item);
        Task<bool> ActualizarAsync(Seguro item);
        Task<bool> EliminarAsync(int id);
    }
}
