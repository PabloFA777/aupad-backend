using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class SeguroNegocio : ISeguroNegocio
    {
        private readonly ISeguroRepositorio _repositorio;

        public SeguroNegocio(ISeguroRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Seguro>> ObtenerTodosAsync()
            => await _repositorio.ObtenerTodosAsync();

        public async Task<Seguro?> ObtenerPorIdAsync(int id)
            => await _repositorio.ObtenerPorIdAsync(id);

        public async Task<Seguro> CrearAsync(Seguro item)
            => await _repositorio.CrearAsync(item);

        public async Task<bool> ActualizarAsync(Seguro item)
            => await _repositorio.ActualizarAsync(item);

        public async Task<bool> EliminarAsync(int id)
            => await _repositorio.EliminarAsync(id);
    }
}