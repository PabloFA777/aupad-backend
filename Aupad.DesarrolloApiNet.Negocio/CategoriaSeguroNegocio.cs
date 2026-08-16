using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class CategoriaSeguroNegocio : ICategoriaSeguroNegocio
    {
        private readonly ICategoriaSeguroRepositorio _repositorio;

        public CategoriaSeguroNegocio(ICategoriaSeguroRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<CategoriaSeguro>> ObtenerTodosAsync()
        {
            return await _repositorio.ObtenerTodosAsync();
        }

        public async Task<CategoriaSeguro?> ObtenerPorIdAsync(int id)
        {
            return await _repositorio.ObtenerPorIdAsync(id);
        }

        public async Task<CategoriaSeguro> CrearAsync(CategoriaSeguro item)
        {
            return await _repositorio.CrearAsync(item);
        }

        public async Task<bool> ActualizarAsync(CategoriaSeguro item)
        {
            return await _repositorio.ActualizarAsync(item);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repositorio.EliminarAsync(id);
        }
    }
}