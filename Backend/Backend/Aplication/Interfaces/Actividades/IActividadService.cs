using Aplication.Interfaces;
using Domain.Entities;

namespace Aplication.Interfaces.Actividades
{
    public interface IActividadRepository : IRepository<Actividad>
    {
        // M�todos adicionales para Actividad
        // e.g., Task<IEnumerable<Actividad>> GetByUsuarioIdAsync(int usuarioId);
    }
}

