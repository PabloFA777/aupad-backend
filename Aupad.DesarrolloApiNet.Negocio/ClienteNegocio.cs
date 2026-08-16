using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteNegocio(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            return await _repositorio.ObtenerTodosAsync();
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            return await _repositorio.ObtenerPorIdAsync(id);
        }

        public async Task<Cliente> CrearAsync(Cliente item)
        {
            return await _repositorio.CrearAsync(item);
        }

        public async Task<bool> ActualizarAsync(Cliente item)
        {
            return await _repositorio.ActualizarAsync(item);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repositorio.EliminarAsync(id);
        }
    }
}
