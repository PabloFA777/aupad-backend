using Aupad.DesarrolloApiNet.Modelos;
using Aupad.DesarrolloApiNet.Negocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aupad.DesarrolloApiNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniaSeguroController : ControllerBase
    {
        private readonly ICompaniaSeguroNegocio _negocio;

        public CompaniaSeguroController(ICompaniaSeguroNegocio negocio)
        {
            _negocio = negocio;
        }

        /// <summary>
        /// Obtiene todas las compañías de seguro
        /// </summary>
        /// <returns>Lista de compañías de seguro</returns>
        [HttpGet]
        public async Task<ActionResult<List<CompaniaSeguro>>> GetAll()
        {
            var lista = await _negocio.ObtenerTodosAsync();
            return Ok(lista);
        }

        /// <summary>
        /// Obtiene una compañía de seguro por su id
        /// </summary>
        /// <param name="id">Id de la compañía de seguro</param>
        /// <returns>Compañía de seguro</returns>   
        [HttpGet("{id}")]
        public async Task<ActionResult<CompaniaSeguro>> GetById(int id)
        {
            var item = await _negocio.ObtenerPorIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        /// <summary>
        /// Crea una nueva compañía de seguro   
        /// </summary>
        /// <param name="item">Compañía de seguro a crear</param>
        /// <returns>Compañía de seguro creada</returns>
        [HttpPost]
        public async Task<ActionResult<CompaniaSeguro>> Create(CompaniaSeguro item)
        {
            var creado = await _negocio.CrearAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        /// <summary>
        /// Actualiza una compañía de seguro existente
        /// </summary>
        /// <param name="id">Id de la compañía de seguro</param>
        /// <param name="item">Compañía de seguro con los datos actualizados</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CompaniaSeguro item)
        {
            if (id != item.Id)
                return BadRequest("El id de la URL no coincide con el id del objeto");

            var actualizado = await _negocio.ActualizarAsync(item);
            if (!actualizado)
                return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Elimina una compañía de seguro por su id    
        /// </summary>
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