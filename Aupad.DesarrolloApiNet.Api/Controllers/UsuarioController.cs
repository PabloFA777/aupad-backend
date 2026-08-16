using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioNegocio _negocio;

        public UsuarioController(IUsuarioNegocio negocio)
        {
            _negocio = negocio;
        }
        /// <summary>
        /// Obtiene todos los usuarios  
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            var lista = await _negocio.ObtenerTodosAsync();
            return Ok(lista);
        }
        /// <summary>
        /// Obtiene un usuario por su id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        /// <summary>
        /// Crea un nuevo usuario   
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Usuario>> Create(Usuario item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Usuario item)
        {
            if (id != item.Id)
                return BadRequest("El id de la URL no coincide con el id del objeto");

            var actualizado = await _negocio.ActualizarAsync(item);
            if (!actualizado)
                return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Elimina un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario</param>
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