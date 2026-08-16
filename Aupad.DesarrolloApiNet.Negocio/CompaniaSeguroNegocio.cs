using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class CompaniaSeguroNegocio : ICompaniaSeguroNegocio
    {
        private readonly ICompaniaSeguroRepositorio _repositorio;

        public CompaniaSeguroNegocio(ICompaniaSeguroRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<CompaniaSeguro>> ObtenerTodosAsync()
        {
            return await _repositorio.ObtenerTodosAsync();
        }

        public async Task<CompaniaSeguro?> ObtenerPorIdAsync(int id)
        {
            return await _repositorio.ObtenerPorIdAsync(id);
        }

        public async Task<CompaniaSeguro> CrearAsync(CompaniaSeguro item)
        {
            return await _repositorio.CrearAsync(item);
        }

        public async Task<bool> ActualizarAsync(CompaniaSeguro item)
        {
            return await _repositorio.ActualizarAsync(item);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repositorio.EliminarAsync(id);
        }
    }
}