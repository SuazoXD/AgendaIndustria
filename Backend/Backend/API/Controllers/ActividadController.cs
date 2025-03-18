using Microsoft.AspNetCore.Mvc;
using Aplication.DTOs.Actividad;
using Aplication.Interfaces.Actividades;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly IActividadService _actividadService;

        public ActividadController(IActividadService actividadService)
        {
            _actividadService = actividadService;
        }

        // Obtener todas las actividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActividadResponseDTO>>> GetActividades()
        {
            var actividades = await _actividadService.GetAllActividadesAsync();
            return Ok(actividades);
        }

        // Obtener una actividad por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ActividadResponseDTO>> GetActividadById(int id)
        {
            var actividad = await _actividadService.GetActividadByIdAsync(id);
            if (actividad == null) return NotFound();
            return Ok(actividad);
        }

        // Crear una nueva actividad
        [HttpPost]
        public async Task<ActionResult<ActividadResponseDTO>> CreateActividad(ActividadRequestDTO request)
        {
            var nuevaActividad = await _actividadService.CreateActividadAsync(request);
            return CreatedAtAction(nameof(GetActividadById), new { id = nuevaActividad.Id }, nuevaActividad);
        }

        // Actualizar una actividad existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActividad(int id, ActividadRequestDTO request)
        {
            var actualizado = await _actividadService.UpdateActividadAsync(id, request);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        // Eliminar una actividad
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            var eliminado = await _actividadService.DeleteActividadAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
