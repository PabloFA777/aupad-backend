using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoPolizaController : ControllerBase
    {
        private readonly IDocumentoPolizaNegocio _negocio;

        public DocumentoPolizaController(IDocumentoPolizaNegocio negocio)
        {
            _negocio = negocio;
        }
        /// <summary>
        /// Obtiene documentos de póliza por su id
        /// </summary>
        /// <param name="polizaId">Id de la póliza</param>
        /// <returns>Lista de documentos de póliza</returns>
        [HttpGet("poliza/{polizaId}")]
        public async Task<ActionResult<List<DocumentoPoliza>>> GetByPolizaId(int polizaId)
        {
            var lista = await _negocio.ObtenerPorPolizaIdAsync(polizaId);
            return Ok(lista);
        }

        /// <summary>
        /// Obtiene un documento de póliza por su id
        /// </summary>
        /// <param name="id">Id del documento de póliza</param>
        /// <returns>Documento de póliza</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoPoliza>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        
        [HttpPost]
        public async Task<ActionResult<DocumentoPoliza>> Create(DocumentoPoliza item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        /// <summary>
        /// Actualiza un documento de póliza existente  
        /// </summary>
        /// <param name="id">Id del documento de póliza</param>
        /// <param name="item">Documento de póliza con los datos actualizados</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DocumentoPoliza item)
        {
            if (id != item.Id)
                return BadRequest("El id de la URL no coincide con el id del objeto");

            var actualizado = await _negocio.ActualizarAsync(item);
            if (!actualizado)
                return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Elimina un documento de póliza por su id    
        /// </summary>
        /// <param name="id">Id del documento de póliza</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _negocio.EliminarAsync(id);
            if (!eliminado)
                return NotFound();
            return NoContent();
        }
    }
}