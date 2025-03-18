namespace Domain.Common
{
    // Clase base para entidades que actúan como catálogos (por ejemplo, Tipo),
    // donde además de Id, comparten propiedades comunes.
    public abstract class EntityCatalog : Entity
    {
        public string? Nombre { get; set; }
    }
}
