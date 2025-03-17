using Domain.Entities;
using Domain.AggregateRoots.Package;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class BackendDBContext : DbContext
    {
        public BackendDBContext(DbContextOptions<BackendDBContext> options)
            : base(options)
        {
        }

      
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

       
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageDetail> PackageDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Correo)
                .IsUnique();

            
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Actividad)
                .WithMany()   
                .HasForeignKey(t => t.ActividadId)
                .OnDelete(DeleteBehavior.Restrict);

           
        }
    }
}
