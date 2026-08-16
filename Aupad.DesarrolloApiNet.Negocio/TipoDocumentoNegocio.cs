using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class TipoDocumentoNegocio : ITipoDocumentoNegocio
    {
        private readonly ITipoDocumentoRepositorio _repositorio;

        public TipoDocumentoNegocio(ITipoDocumentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<TipoDocumento>> ObtenerTodosAsync()
        {
            return await _repositorio.ObtenerTodosAsync();
        }
         public async Task<TipoDocumento?> ObtenerPorIdAsync(int id)
        {
            return await _repositorio.ObtenerPorIdAsync(id);
        }
         public async Task<TipoDocumento> CrearAsync(TipoDocumento item)
        {
            return await _repositorio.CrearAsync(item);
        }

         public async Task<bool> ActualizarAsync (TipoDocumento item)
        {
            return await _repositorio.ActualizarAsync(item);
        }
         public async Task<bool> EliminarAsync(int id)
        {
            return await _repositorio.EliminarAsync(id);
        }
    }
}
