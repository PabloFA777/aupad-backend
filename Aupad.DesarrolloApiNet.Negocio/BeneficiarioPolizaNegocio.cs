using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class BeneficiarioPolizaNegocio : IBeneficiarioPolizaNegocio
    {
        private readonly IBeneficiarioPolizaRepositorio _repositorio;

        public BeneficiarioPolizaNegocio(IBeneficiarioPolizaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<BeneficiarioPoliza>> ObtenerPorPolizaIdAsync(int polizaId)
            => await _repositorio.ObtenerPorPolizaIdAsync(polizaId);

        public async Task<BeneficiarioPoliza?> ObtenerPorIdAsync(int id)
            => await _repositorio.ObtenerPorIdAsync(id);

        public async Task<BeneficiarioPoliza> CrearAsync(BeneficiarioPoliza item)
        {
            var duplicado = await _repositorio.ExisteDuplicadoAsync(item.PolizaId, item.Dni, item.Mes, item.Anio);
            if (duplicado)
                throw new InvalidOperationException("Este beneficiario ya fue declarado en este mes para esta póliza.");

            return await _repositorio.CrearAsync(item);
        }

        public async Task<bool> ActualizarAsync(BeneficiarioPoliza item)
        {
            var duplicado = await _repositorio.ExisteDuplicadoAsync(item.PolizaId, item.Dni, item.Mes, item.Anio, item.Id);
            if (duplicado)
                throw new InvalidOperationException("Este beneficiario ya fue declarado en este mes para esta póliza.");

            return await _repositorio.ActualizarAsync(item);
        }

        public async Task<bool> EliminarAsync(int id)
            => await _repositorio.EliminarAsync(id);
    }
}