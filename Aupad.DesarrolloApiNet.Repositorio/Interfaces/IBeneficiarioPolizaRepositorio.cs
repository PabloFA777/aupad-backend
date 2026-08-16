using Aupad.DesarrolloApiNet.Modelos;

namespace Aupad.DesarrolloApiNet.Repositorio.Interfaces
{
    public interface IBeneficiarioPolizaRepositorio
    {
        Task<List<BeneficiarioPoliza>> ObtenerPorPolizaIdAsync(int polizaId);
        Task<BeneficiarioPoliza?> ObtenerPorIdAsync(int id);
        Task<bool> ExisteDuplicadoAsync(int polizaId, string dni, byte mes, short anio, int? excluirId = null);
        Task<BeneficiarioPoliza> CrearAsync(BeneficiarioPoliza item);
        Task<bool> ActualizarAsync(BeneficiarioPoliza item);
        Task<bool> EliminarAsync(int id);
    }
}
