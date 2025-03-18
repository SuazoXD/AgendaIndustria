using Domain.Common;

namespace Domain.Entities
{
    // Una tarea pertenece a una actividad. Se modela como Aggregate Root o entidad simple según necesidades.
    public class Tarea : AggregateRoot
    {
        public int ActividadId { get; set; }
        public required Actividad Actividad { get; set; }

        public string? Descripcion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }

        // Si tiene valor, la tarea está completada.
        public DateTime? FechaCompletado { get; set; }
    }
}
