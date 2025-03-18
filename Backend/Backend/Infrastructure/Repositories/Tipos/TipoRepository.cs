using Aplication.Interfaces.Tipos;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Tipos
{
    public class TipoRepository : Repository<Tipo>, ITipoRepository
    {
        public TipoRepository(BackendDBContext context)
            : base(context)
        {
        }

        // Métodos específicos para Tipo, si los necesitas
        // Por ejemplo:
        public async Task<Tipo?> GetByNombreAsync(string nombre)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Nombre == nombre);
        }
    }
}
