using Aplication.Interfaces.Tipos;
using Aplication.DTOs.Tipo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ITipoService _tipoService;

        public TipoController(ITipoService tipoService)
        {
            _tipoService = tipoService;
        }

        // Obtener todos los tipos de actividad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoResponseDTO>>> GetTipos()
        {
            var tipos = await _tipoService.GetAllAsync();
            return Ok(tipos);
        }

        // Obtener un tipo por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoResponseDTO>> GetTipoById(int id)
        {
            var tipo = await _tipoService.GetByIdAsync(id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }

        // Crear un nuevo tipo de actividad
        [HttpPost]
        public async Task<ActionResult<TipoResponseDTO>> CreateTipo(TipoRequestDTO request)
        {
            var nuevoTipo = await _tipoService.CreateAsync(request);
            return CreatedAtAction(nameof(GetTipoById), new { id = nuevoTipo.Id }, nuevoTipo);
        }

        // Actualizar un tipo existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipo(int id, TipoRequestDTO request)
        {
            var actualizado = await _tipoService.UpdateAsync(id, request);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        // Eliminar un tipo
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo(int id)
        {
            var eliminado = await _tipoService.DeleteAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
