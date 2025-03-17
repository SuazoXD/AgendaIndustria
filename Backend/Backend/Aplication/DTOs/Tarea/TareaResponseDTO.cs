namespace Aplication.DTOs.Tarea
{
    public class TareaResponseDTO
    {
        public int Id { get; set; }
        public int ActividadId { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public DateTime? FechaCompletado { get; set; }
    }
}
