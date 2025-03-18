using Domain.Common;

namespace Domain.Entities
{
    // Hereda de EntityCatalog para aprovechar propiedades comunes (por ejemplo, Nombre)
    public class Tipo : EntityCatalog
    {
        public string? Descripcion { get; set; }
    }
}
