using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class CuotaPolizaNegocio : ICuotaPolizaNegocio
    {
        private readonly ICuotaPolizaRepositorio _repositorio;

        public CuotaPolizaNegocio(ICuotaPolizaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<CuotaPoliza>> ObtenerPorPolizaIdAsync(int polizaId)
            => await _repositorio.ObtenerPorPolizaIdAsync(polizaId);

        public async Task<CuotaPoliza?> ObtenerPorIdAsync(int id)
            => await _repositorio.ObtenerPorIdAsync(id);

        public async Task<CuotaPoliza> CrearAsync(CuotaPoliza item)
            => await _repositorio.CrearAsync(item);

        public async Task<bool> ActualizarAsync(CuotaPoliza item)
            => await _repositorio.ActualizarAsync(item);

        public async Task<bool> EliminarAsync(int id)
            => await _repositorio.EliminarAsync(id);
    }
}