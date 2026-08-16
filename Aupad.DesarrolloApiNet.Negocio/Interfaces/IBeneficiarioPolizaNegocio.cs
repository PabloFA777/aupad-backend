using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Negocio.Interfaces
{
    public interface IBeneficiarioPolizaNegocio
    {
        Task<List<BeneficiarioPoliza>> ObtenerPorPolizaIdAsync(int polizaId);
        Task<BeneficiarioPoliza?> ObtenerPorIdAsync(int id);
        Task<BeneficiarioPoliza> CrearAsync(BeneficiarioPoliza item);
        Task<bool> ActualizarAsync(BeneficiarioPoliza item);
        Task<bool> EliminarAsync(int id);
    }
}