using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Negocio.Interfaces
{
    public interface ICuotaPolizaNegocio
    {
        Task<List<CuotaPoliza>> ObtenerPorPolizaIdAsync(int polizaId);
        Task<CuotaPoliza?> ObtenerPorIdAsync(int id);
        Task<CuotaPoliza> CrearAsync(CuotaPoliza item);
        Task<bool> ActualizarAsync(CuotaPoliza item);
        Task<bool> EliminarAsync(int id);
    }
}