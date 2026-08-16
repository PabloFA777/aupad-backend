using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiguracionSistemaController : ControllerBase
    {
        private readonly IConfiguracionSistemaNegocio _negocio;

        public ConfiguracionSistemaController(IConfiguracionSistemaNegocio negocio)
        {
            _negocio = negocio;
        }
        /// <summary>
        /// Obtiene todas las configuraciones del sistema
        /// </summary>
        /// <returns>Lista de configuraciones del sistema</returns>
        [HttpGet]
        public async Task<ActionResult<List<ConfiguracionSistema>>> GetAll()
        {
            var lista = await _negocio.ObtenerTodosAsync();
            return Ok(lista);
        }

        /// <summary>
        /// Obtiene una configuración del sistema por su id
        /// </summary>
        /// <param name="id">Id de la configuración del sistema</param>
        /// <returns>Configuración del sistema</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfiguracionSistema>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        /// <summary>
        /// Crea una nueva configuración del sistema
        /// </summary>
        /// <param name="item">Configuración del sistema a crear</param>
        /// <returns>Configuración del sistema creada</returns>
        [HttpPost]
        public async Task<ActionResult<ConfiguracionSistema>> Create(ConfiguracionSistema item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        /// <summary>
        /// Actualiza una configuración del sistema existente
        /// </summary>
        /// <param name="id">Id de la configuración del sistema</param>
        /// <param name="item">Configuración del sistema con los datos actualizados</param> 
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ConfiguracionSistema item)
        {
            if (id != item.Id)
                return BadRequest("El id de la URL no coincide con el id del objeto");

            var actualizado = await _negocio.ActualizarAsync(item);
            if (!actualizado)
                return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Elimina una configuración del sistema por su id
        /// </summary>
        /// <param name="id">Id de la configuración del sistema</param>
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