using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Negocio.Interfaces
{
    public interface ICompaniaSeguroNegocio
    {
        Task<List<CompaniaSeguro>> ObtenerTodosAsync();
        Task<CompaniaSeguro?> ObtenerPorIdAsync(int id);
        Task<CompaniaSeguro> CrearAsync(CompaniaSeguro item);
        Task<bool> ActualizarAsync(CompaniaSeguro item);
        Task<bool> EliminarAsync(int id);
    }
}