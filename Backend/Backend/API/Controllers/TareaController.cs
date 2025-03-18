using Microsoft.AspNetCore.Mvc;
using Aplication.DTOs.Tarea;
using Aplication.Interfaces.Tareas;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareaController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        // Obtener todas las tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaResponseDTO>>> GetTareas()
        {
            var tareas = await _tareaService.GetAllTareasAsync();
            return Ok(tareas);
        }

        // Obtener una tarea por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TareaResponseDTO>> GetTareaById(int id)
        {
            var tarea = await _tareaService.GetTareaByIdAsync(id);
            if (tarea == null) return NotFound();
            return Ok(tarea);
        }

        // Obtener todas las tareas de una actividad específica
        [HttpGet("actividad/{actividadId}")]
        public async Task<ActionResult<IEnumerable<TareaResponseDTO>>> GetTareasByActividad(int actividadId)
        {
            if (actividadId <= 0)
            {
                return BadRequest("ID de actividad inválido.");
            }

            var tareas = await _tareaService.GetAllTareasAsync();
            var tareasFiltradas = tareas.Where(t => t.ActividadId == actividadId).ToList();

            if (tareasFiltradas.Count == 0)
            {
                return NotFound("No se encontraron tareas para esta actividad.");
            }

            return Ok(tareasFiltradas);
        }

        /*[HttpGet("actividad/{actividadId}")]
        public async Task<ActionResult<IEnumerable<TareaResponseDTO>>> GetTareasByActividad(int actividadId)
        {
            var tareas = await _tareaService.GetAllTareasAsync();
            var tareasFiltradas = tareas.Where(t => t.ActividadId == actividadId).ToList();
            return Ok(tareasFiltradas);
        }*/

        // Crear una nueva tarea
        [HttpPost]
        public async Task<ActionResult<TareaResponseDTO>> CreateTarea(TareaRequestDTO request)
        {
            var nuevaTarea = await _tareaService.CreateTareaAsync(request);
            return CreatedAtAction(nameof(GetTareaById), new { id = nuevaTarea.Id }, nuevaTarea);
        }

        // Actualizar una tarea existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarea(int id, TareaRequestDTO request)
        {
            var actualizado = await _tareaService.UpdateTareaAsync(id, request);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        // Eliminar una tarea
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var eliminado = await _tareaService.DeleteTareaAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }

    }
}
