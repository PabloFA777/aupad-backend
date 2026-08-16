using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaSeguroController : ControllerBase
    {
        private readonly ICategoriaSeguroNegocio _negocio;

        public CategoriaSeguroController(ICategoriaSeguroNegocio negocio)
        {
            _negocio = negocio;
        }
        /// <summary>
        /// Obtiene todas las categorías de seguro
        /// </summary>
        /// <returns>Lista de categorías de seguro</returns>
        [HttpGet]
        public async Task<ActionResult<List<CategoriaSeguro>>> GetAll()
        {
            var lista = await _negocio.ObtenerTodosAsync();
            return Ok(lista);
        }

        /// <summary>
        /// Obtiene una categoría de seguro por su id
        /// </summary>
        /// <param name="id">Id de la categoría de seguro</param>
        /// <returns>Categoría de seguro</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaSeguro>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        /// <summary>
        /// Crea una nueva categoría de seguro
        /// </summary>
        /// <param name="item">Categoría de seguro a crear</param>
        /// <returns>Categoría de seguro creada</returns>
        [HttpPost]
        public async Task<ActionResult<CategoriaSeguro>> Create(CategoriaSeguro item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

    
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CategoriaSeguro item)
        {
            if (id != item.Id)
                return BadRequest("El id de la URL no coincide con el id del objeto");

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