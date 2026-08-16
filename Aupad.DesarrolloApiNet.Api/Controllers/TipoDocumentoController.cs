using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoNegocio _negocio;

        public TipoDocumentoController(ITipoDocumentoNegocio negocio)
        {
            _negocio = negocio;
        }
        /// <summary>
        /// Obtiene todos los tipos de documento
        /// </summary>
        /// <returns>Lista de tipos de documento</returns>
        [HttpGet]
        public async Task<ActionResult<List<TipoDocumento>>> GetAll()
        {
            var lista = await _negocio.ObtenerTodosAsync();
            return Ok(lista);
        }
        /// <summary>
        /// Obtiene un tipo de documento por su id
        /// </summary>
        /// <param name="id">Id del tipo de documento</param>
        /// <returns>Tipo de documento</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumento>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        /// <summary>   
        /// Crea un nuevo tipo de documento
        /// </summary>
        /// <param name="item">Tipo de documento a crear</param>
        /// <returns>Tipo de documento creado</returns>
        [HttpPost]
        public async Task<ActionResult<TipoDocumento>> Create(TipoDocumento item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        /// <summary>
        /// Actualiza un tipo de documento existente
        /// </summary>
        /// <param name="id">Id del tipo de documento</param>
        /// <param name="item">Tipo de documento con los datos actualizados</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TipoDocumento item)
        {
            item.Id = id;

            var actualizado = await _negocio.ActualizarAsync(item);
            if (!actualizado)
            return NotFound();
            return NoContent();
        }
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
