using Domain.Common;


namespace Domain.Entities
{
    // Actividad se considera un Aggregate Root dentro del dominio de la agenda.
    public class Actividad : AggregateRoot
    {
        public DateTime FechaHora { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario(); // Inicializado

        public int TipoId { get; set; }
        public Tipo Tipo { get; set; } = new Tipo(); // Inicializado

        public string Descripcion { get; set; } = string.Empty; // Cadena vacía por defecto

        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }

        public Actividad() { }
    }
}
