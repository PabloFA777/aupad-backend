using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class PolizaNegocio : IPolizaNegocio
    {
        private readonly IPolizaRepositorio _repositorio;

        public PolizaNegocio(IPolizaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Poliza>> ObtenerTodosAsync()
            => await _repositorio.ObtenerTodosAsync();

        public async Task<List<Poliza>> ObtenerPorClienteIdAsync(int clienteId)
            => await _repositorio.ObtenerPorClienteIdAsync(clienteId);

        public async Task<Poliza?> ObtenerPorIdAsync(int id)
            => await _repositorio.ObtenerPorIdAsync(id);

        public async Task<Poliza> CrearAsync(Poliza item)
            => await _repositorio.CrearAsync(item);

        public async Task<bool> ActualizarAsync(Poliza item)
            => await _repositorio.ActualizarAsync(item);

        public async Task<bool> EliminarAsync(int id)
            => await _repositorio.EliminarAsync(id);
    }
}