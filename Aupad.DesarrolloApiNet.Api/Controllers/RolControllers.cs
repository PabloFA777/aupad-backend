using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolNegocio _negocio;

        public RolController(IRolNegocio negocio)
        {
            _negocio = negocio;
        }
        /// <summary>
        /// Obtiene todos los roles 
        /// </summary>

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> GetAll()
        {
            var lista = await _negocio.ObtenerTodosAsync();
            return Ok(lista);
        }
        /// <summary>
        /// Obtiene un rol por su id
        /// </summary>
        /// <param name="id">Id del rol</param>
        /// <returns>Rol</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        /// <summary>
        /// Crea un nuevo rol
        /// </summary>
        /// <param name="item">Rol a crear</param>
        /// <returns>Rol creado</returns>
        [HttpPost]
        public async Task<ActionResult<Rol>> Create(Rol item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        /// <summary>
        /// Actualiza un rol existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Rol item)
        {
            if (id != item.Id)
                return BadRequest("El id de la URL no coincide con el id del objeto");

            var actualizado = await _negocio.ActualizarAsync(item);
            if (!actualizado)
                return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Elimina un rol por su id
        /// </summary>
        /// <param name="id">Id del rol</param>
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