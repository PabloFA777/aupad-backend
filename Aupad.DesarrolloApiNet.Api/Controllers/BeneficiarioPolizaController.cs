using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeneficiarioPolizaController : ControllerBase
    {
        private readonly IBeneficiarioPolizaNegocio _negocio;

        public BeneficiarioPolizaController(IBeneficiarioPolizaNegocio negocio)
        {
            _negocio = negocio;
        }

        /// <summary>
        /// Obtiene los beneficiarios de una póliza
        /// </summary>
        /// <param name="polizaId">Id de la póliza</param>
        /// <returns>Lista de beneficiarios de póliza</returns>
        [HttpGet("poliza/{polizaId}")]
        public async Task<ActionResult<List<BeneficiarioPoliza>>> GetByPolizaId(int polizaId)
        {
            var lista = await _negocio.ObtenerPorPolizaIdAsync(polizaId);
            return Ok(lista);
        }

        /// <summary>
        /// Obtiene un beneficiario de póliza por su id
        /// </summary>
        /// <param name="id">Id del beneficiario de póliza</param>
        /// <returns>Beneficiario de póliza</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BeneficiarioPoliza>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        /// <summary>
        /// Crea un nuevo beneficiario de póliza
        /// </summary>
        /// <param name="item">Beneficiario de póliza a crear</param>
        /// <returns>Beneficiario de póliza creado</returns>
        [HttpPost]
        public async Task<ActionResult<BeneficiarioPoliza>> Create(BeneficiarioPoliza item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        /// <summary>
        /// Actualiza un beneficiario de póliza existente
        /// </summary>
        /// <param name="id">Id del beneficiario de póliza</param>
        /// <param name="item">Beneficiario de póliza con los datos actualizados</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, BeneficiarioPoliza item)
        {
            if (id != item.Id)
                return BadRequest("El id de la URL no coincide con el id del objeto");

            var actualizado = await _negocio.ActualizarAsync(item);
            if (!actualizado)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Elimina un beneficiario de póliza por su id
        /// </summary>
        /// <param name="id">Id del beneficiario de póliza</param>
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
