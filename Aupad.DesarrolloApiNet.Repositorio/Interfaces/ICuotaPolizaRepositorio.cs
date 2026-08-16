using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Repositorio.Interfaces
{
    public interface ICuotaPolizaRepositorio
    {
        Task<List<CuotaPoliza>> ObtenerPorPolizaIdAsync(int polizaId);
        Task<CuotaPoliza?> ObtenerPorIdAsync(int id);
        Task<CuotaPoliza> CrearAsync(CuotaPoliza item);
        Task<bool> ActualizarAsync(CuotaPoliza item);
        Task<bool> EliminarAsync(int id);
    }
}
