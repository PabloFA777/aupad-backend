using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Negocio.Interfaces
{
    public interface ICategoriaSeguroNegocio
    {
        Task<List<CategoriaSeguro>> ObtenerTodosAsync();
        Task<CategoriaSeguro?> ObtenerPorIdAsync(int id);
        Task<CategoriaSeguro> CrearAsync(CategoriaSeguro categoriaSeguro);
        Task<bool> ActualizarAsync(CategoriaSeguro categoriaSeguro);
        Task<bool> EliminarAsync(int id);
    }
}