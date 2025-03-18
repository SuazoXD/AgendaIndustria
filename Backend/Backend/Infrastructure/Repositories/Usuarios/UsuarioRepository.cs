using Aplication.Interfaces.Usuarios;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Usuarios
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BackendDBContext context)
            : base(context)
        {
        }

        public async Task<Usuario?> GetByCorreoAsync(string correo)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Correo == correo);
        }
    }
}
