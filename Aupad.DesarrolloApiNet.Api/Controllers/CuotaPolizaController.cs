using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuotaPolizaController : ControllerBase
    {
        private readonly ICuotaPolizaNegocio _negocio;

        public CuotaPolizaController(ICuotaPolizaNegocio negocio)
        {
            _negocio = negocio;
        }
        /// <summary>
        /// Obtiene todas las cuotas de póliza por el id de la póliza
        /// </summary>
        /// <param name="polizaId">Id de la póliza</param>
        /// <returns>Lista de cuotas de póliza</returns>
        [HttpGet("poliza/{polizaId}")]
        public async Task<ActionResult<List<CuotaPoliza>>> GetByPolizaId(int polizaId)
        {
            var lista = await _negocio.ObtenerPorPolizaIdAsync(polizaId);
            return Ok(lista);
        }
        /// <summary>
        /// Obtiene una cuota de póliza por su id
        /// </summary>
        /// <param name="id">Id de la cuota de póliza</param>
        /// <returns>Cuota de póliza</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CuotaPoliza>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        /// <summary>
        /// Crea una nueva cuota de póliza  
        /// </summary>
        /// <param name="item">Cuota de póliza a crear</param>
        /// <returns>Cuota de póliza creada</returns>
        [HttpPost]
        public async Task<ActionResult<CuotaPoliza>> Create(CuotaPoliza item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        /// <summary>
        /// Actualiza una cuota de póliza existente
        /// </summary>
        /// <param name="id">Id de la cuota de póliza</param>
        /// <param name="item">Cuota de póliza con los datos actualizados</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CuotaPoliza item)
        {
            if (id != item.Id)
                return BadRequest("El id de la URL no coincide con el id del objeto");

            var actualizado = await _negocio.ActualizarAsync(item);
            if (!actualizado)
                return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Elimina una cuota de póliza por su id
        /// </summary>
        /// <param name="id">Id de la cuota de póliza</param>
        /// <returns></returns>
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