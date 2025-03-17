using Aplication.DTOs.Actividad;
using Aplication.Interfaces.Actividades;
using Domain.Entities;

namespace Aplication.Services.Actividades
{
    public class ActividadService : IActividadService
    {
        private readonly IActividadRepository _actividadRepository;

        public ActividadService(IActividadRepository actividadRepository)
        {
            _actividadRepository = actividadRepository;
        }

        public async Task<ActividadResponseDTO> CreateActividadAsync(ActividadRequestDTO request)
        {
            var actividad = new Actividad
            {
                FechaHora = request.FechaHora,
                UsuarioId = request.UsuarioId,
                TipoId = request.TipoId,
                Descripcion = request.Descripcion ?? string.Empty, // Fix for CS8601
                FechaHoraInicio = request.FechaHoraInicio,
                FechaHoraFin = request.FechaHoraFin
            };

            await _actividadRepository.AddAsync(actividad);

            return new ActividadResponseDTO
            {
                Id = actividad.Id,
                FechaHora = actividad.FechaHora,
                UsuarioId = actividad.UsuarioId,
                TipoId = actividad.TipoId,
                Descripcion = actividad.Descripcion,
                FechaHoraInicio = actividad.FechaHoraInicio,
                FechaHoraFin = actividad.FechaHoraFin
            };
        }

        public async Task<IEnumerable<ActividadResponseDTO>> GetAllActividadesAsync()
        {
            var actividades = await _actividadRepository.GetAllAsync();
            return actividades.Select(a => new ActividadResponseDTO
            {
                Id = a.Id,
                FechaHora = a.FechaHora,
                UsuarioId = a.UsuarioId,
                TipoId = a.TipoId,
                Descripcion = a.Descripcion,
                FechaHoraInicio = a.FechaHoraInicio,
                FechaHoraFin = a.FechaHoraFin
            });
        }

        public async Task<ActividadResponseDTO?> GetActividadByIdAsync(int id)
        {
            var actividad = await _actividadRepository.GetByIdAsync(id);
            if (actividad == null) return null;

            return new ActividadResponseDTO
            {
                Id = actividad.Id,
                FechaHora = actividad.FechaHora,
                UsuarioId = actividad.UsuarioId,
                TipoId = actividad.TipoId,
                Descripcion = actividad.Descripcion,
                FechaHoraInicio = actividad.FechaHoraInicio,
                FechaHoraFin = actividad.FechaHoraFin
            };
        }

        public async Task<bool> UpdateActividadAsync(int id, ActividadRequestDTO request)
        {
            var actividad = await _actividadRepository.GetByIdAsync(id);
            if (actividad == null) return false;

            actividad.FechaHora = request.FechaHora;
            actividad.UsuarioId = request.UsuarioId;
            actividad.TipoId = request.TipoId;
            actividad.Descripcion = request.Descripcion ?? string.Empty; // Fix for CS8601
            actividad.FechaHoraInicio = request.FechaHoraInicio;
            actividad.FechaHoraFin = request.FechaHoraFin;

            await _actividadRepository.UpdateAsync(actividad);
            return true;
        }

        public async Task<bool> DeleteActividadAsync(int id)
        {
            var actividad = await _actividadRepository.GetByIdAsync(id);
            if (actividad == null) return false;

            await _actividadRepository.DeleteAsync(actividad);
            return true;
        }
    }
}
