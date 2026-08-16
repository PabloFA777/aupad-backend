using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Repositorio.Interfaces
{
    public interface ICategoriaSeguroRepositorio
    {
        Task<List<CategoriaSeguro>> ObtenerTodosAsync();
        Task<CategoriaSeguro?> ObtenerPorIdAsync(int id);
        Task<CategoriaSeguro> CrearAsync(CategoriaSeguro item);
        Task<bool> ActualizarAsync(CategoriaSeguro item);
        Task<bool> EliminarAsync(int id);
    }
}