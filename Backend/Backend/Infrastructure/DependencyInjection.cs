using Aplication.Interfaces.Packages;
using Aplication.Interfaces.Usuarios;
using Aplication.Interfaces;
using Infrastructure.Persistence;


using Infrastructure.Repositories;
using Infrastructure.Repositories.Packages;
using Infrastructure.Repositories.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
           
            services.AddDbContext<BackendDBContext>(options =>
            {
             
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

          
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

         
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        
            return services;
        }
    }
}
