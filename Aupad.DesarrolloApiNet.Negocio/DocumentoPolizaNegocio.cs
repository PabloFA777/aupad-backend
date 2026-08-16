using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Aupad.DesarrolloApiNet.Repositorio.Interfaces;

namespace Aupad.DesarrolloApiNet.Negocio
{
    public class DocumentoPolizaNegocio : IDocumentoPolizaNegocio
    {
        private readonly IDocumentoPolizaRepositorio _repositorio;

        public DocumentoPolizaNegocio(IDocumentoPolizaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<DocumentoPoliza>> ObtenerPorPolizaIdAsync(int polizaId)
            => await _repositorio.ObtenerPorPolizaIdAsync(polizaId);

        public async Task<DocumentoPoliza?> ObtenerPorIdAsync(int id)
            => await _repositorio.ObtenerPorIdAsync(id);

        public async Task<DocumentoPoliza> CrearAsync(DocumentoPoliza item)
            => await _repositorio.CrearAsync(item);

        public async Task<bool> ActualizarAsync(DocumentoPoliza item)
            => await _repositorio.ActualizarAsync(item);

        public async Task<bool> EliminarAsync(int id)
            => await _repositorio.EliminarAsync(id);
    }
}