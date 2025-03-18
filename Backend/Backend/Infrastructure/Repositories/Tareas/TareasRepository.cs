using System.Threading;
using Aplication.Interfaces.Tareas;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Tareas
{
    public class TareaRepository : Repository<Tarea>, ITareaRepository
    {
        public TareaRepository(BackendDBContext context)
            : base(context)
        {
        }

        // Métodos adicionales para Tarea, si tu interfaz ITareaRepository los define
        // Ejemplo:
        public async Task<IEnumerable<Tarea>> GetByActividadIdAsync(int actividadId)
        {
            return await _dbSet
                .Where(t => t.ActividadId == actividadId)
                .ToListAsync();
        }
    }
}
