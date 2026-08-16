using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaNegocio _negocio;

        public PolizaController(IPolizaNegocio negocio)
        {
            _negocio = negocio;
        }
        /// <summary>
        /// Obtiene todas las pólizas
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Poliza>>> GetAll()
        {
            var lista = await _negocio.ObtenerTodosAsync();
            return Ok(lista);
        }

        /// <summary>
        /// Obtiene todas las pólizas por el id del cliente
        /// </summary>
        /// <param name="clienteId">Id del cliente</param>
        /// <returns>Lista de pólizas</returns>
        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<List<Poliza>>> GetByClienteId(int clienteId)
        {
            var lista = await _negocio.ObtenerPorClienteIdAsync(clienteId);
            return Ok(lista);
        }
        /// <summary>
        /// Obtiene una póliza por su id
        /// </summary>
        /// <param name="id">Id de la póliza</param>
        /// <returns>Póliza</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Poliza>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        /// <summary>
        /// Crea una nueva póliza   
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Poliza>> Create(Poliza item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        /// <summary>
        /// Actualiza una póliza existente
        /// </summary>
        /// <param name="id">Id de la póliza</param>
        /// <param name="item">Póliza con los datos actualizados</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Poliza item)
        {
            if (id != item.Id)
                return BadRequest("El id de la URL no coincide con el id del objeto");

            var actualizado = await _negocio.ActualizarAsync(item);
            if (!actualizado)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Elimina una póliza por su id
        /// </summary>
        /// <param name="id">Id de la póliza</param>
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