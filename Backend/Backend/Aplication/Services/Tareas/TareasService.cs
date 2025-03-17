using Aplication.DTOs.Tarea;
using Aplication.Interfaces.Tareas;
using Domain.Entities;

namespace Aplication.Services.Tareas
{
    public class TareaService : ITareaService
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaService(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        public async Task<TareaResponseDTO> CreateTareaAsync(TareaRequestDTO request)
        {
            var tarea = new Tarea
            {
                ActividadId = request.ActividadId,
                Actividad = new Actividad(), // Add this line to initialize the required property
                Descripcion = request.Descripcion,
                FechaHoraInicio = request.FechaHoraInicio,
                FechaHoraFin = request.FechaHoraFin,
                FechaCompletado = request.FechaCompletado
            };

            await _tareaRepository.AddAsync(tarea);

            return new TareaResponseDTO
            {
                Id = tarea.Id,
                ActividadId = tarea.ActividadId,
                Descripcion = tarea.Descripcion,
                FechaHoraInicio = tarea.FechaHoraInicio,
                FechaHoraFin = tarea.FechaHoraFin,
                FechaCompletado = tarea.FechaCompletado
            };
        }

        public async Task<IEnumerable<TareaResponseDTO>> GetAllTareasAsync()
        {
            var tareas = await _tareaRepository.GetAllAsync();
            return tareas.Select(t => new TareaResponseDTO
            {
                Id = t.Id,
                ActividadId = t.ActividadId,
                Descripcion = t.Descripcion,
                FechaHoraInicio = t.FechaHoraInicio,
                FechaHoraFin = t.FechaHoraFin,
                FechaCompletado = t.FechaCompletado
            });
        }

        public async Task<TareaResponseDTO?> GetTareaByIdAsync(int id)
        {
            var tarea = await _tareaRepository.GetByIdAsync(id);
            if (tarea == null) return null;

            return new TareaResponseDTO
            {
                Id = tarea.Id,
                ActividadId = tarea.ActividadId,
                Descripcion = tarea.Descripcion,
                FechaHoraInicio = tarea.FechaHoraInicio,
                FechaHoraFin = tarea.FechaHoraFin,
                FechaCompletado = tarea.FechaCompletado
            };
        }

        public async Task<bool> UpdateTareaAsync(int id, TareaRequestDTO request)
        {
            var tarea = await _tareaRepository.GetByIdAsync(id);
            if (tarea == null) return false;

            tarea.Descripcion = request.Descripcion;
            tarea.FechaHoraInicio = request.FechaHoraInicio;
            tarea.FechaHoraFin = request.FechaHoraFin;
            tarea.FechaCompletado = request.FechaCompletado;

            await _tareaRepository.UpdateAsync(tarea);
            return true;
        }

        public async Task<bool> DeleteTareaAsync(int id)
        {
            var tarea = await _tareaRepository.GetByIdAsync(id);
            if (tarea == null) return false;

            await _tareaRepository.DeleteAsync(tarea);
            return true;
        }
    }
