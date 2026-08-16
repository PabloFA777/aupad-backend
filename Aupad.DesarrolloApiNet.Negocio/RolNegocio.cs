using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class RolNegocio : IRolNegocio
    {
        private readonly IRolRepositorio _repositorio;

        public RolNegocio(IRolRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Rol>> ObtenerTodosAsync()
        {
            return await _repositorio.ObtenerTodosAsync();
        }

        public async Task<Rol?> ObtenerPorIdAsync(int id)
        {
            return await _repositorio.ObtenerPorIdAsync(id);
        }

        public async Task<Rol> CrearAsync(Rol item)
        {
            return await _repositorio.CrearAsync(item);
        }

        public async Task<bool> ActualizarAsync(Rol item)
        {
            return await _repositorio.ActualizarAsync(item);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repositorio.EliminarAsync(id);
        }
    }
}
