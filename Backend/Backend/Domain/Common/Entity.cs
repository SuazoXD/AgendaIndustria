namespace Domain.Common
{
    // Clase base para todas las entidades, definiendo una propiedad Id.
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
