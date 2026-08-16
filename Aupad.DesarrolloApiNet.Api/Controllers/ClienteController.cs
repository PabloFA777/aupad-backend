using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _negocio;

        public ClienteController(IClienteNegocio negocio)
        {
            _negocio = negocio;
        }

        /// <summary>   
        /// Obtiene todos los clientes
        /// </summary>  
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            var lista = await _negocio.ObtenerTodosAsync();
            return Ok(lista);
        }
        /// <summary>
        /// Obtiene un cliente por su id
        /// </summary>
        /// <param name="id">Id del cliente</param>
        /// <returns>Cliente</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        /// <summary>
        /// Crea un nuevo cliente
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        /// <summary>
        /// Actualiza un cliente existente
        /// </summary>  
        /// <param name="id">Id del cliente</param>
        /// <param name="item">Cliente con los datos actualizados</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Cliente item)
        {
            if (id != item.Id)
                return BadRequest("El id de la URL no coincide con el id del objeto");

            var actualizado = await _negocio.ActualizarAsync(item);
            if (!actualizado)
                return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Elimina un cliente por su id
        /// </summary>
        /// <param name="id">Id del cliente</param>
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
