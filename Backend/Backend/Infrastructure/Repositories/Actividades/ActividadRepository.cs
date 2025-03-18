using Aplication.Interfaces.Actividades;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Actividades
{
    public class ActividadRepository : Repository<Actividad>, IActividadRepository
    {
        public ActividadRepository(BackendDBContext context)
            : base(context)
        {
        }


        public async Task<IEnumerable<Actividad>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _dbSet
                .Where(a => a.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
