namespace Aplication.DTOs.Actividad
{
    public class ActividadResponseDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }

        public int UsuarioId { get; set; }
        public int TipoId { get; set; }

        public string? Descripcion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }
}
