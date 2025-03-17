namespace Aplication.DTOs.Tarea
{
    public class TareaRequestDTO
    {
        public int ActividadId { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }

        // Si tiene valor, la tarea está finalizada
        public DateTime? FechaCompletado { get; set; }
    }
}
