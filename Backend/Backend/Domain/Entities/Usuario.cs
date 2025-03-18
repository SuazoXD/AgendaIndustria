using Domain.Common;

namespace Domain.Entities
{
    public class Usuario : Entity
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contrasenia { get; set; }
    }
}
