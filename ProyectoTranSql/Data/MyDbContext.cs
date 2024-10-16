using Microsoft.EntityFrameworkCore;
using ProyectoTranSql.Models;

namespace ProyectoTranSql.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<ModeloVehiculo> ModelosVehiculo { get; set; }
        public DbSet<MarcaVehiculo> MarcasVehiculo { get; set; }
        public DbSet<EstadosVehiculo> EstadosVehiculo { get; set; }
        public DbSet<Usuario> Usuarios { get; set; } // DbSet para la tabla Usuario
        public DbSet<Colaborador> Colaboradores { get; set; } // DbSet para la tabla Colaboradores
        public DbSet<Departamento> Departamentos { get; set; } // DbSet para la tabla Departamentos
        public DbSet<TiposVehiculo> TiposVehiculo { get; set; } // DbSet para la tabla TiposVehiculo

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.NombreUsuario).IsRequired().HasMaxLength(50);
                entity.Property(u => u.TipoUsuario).IsRequired().HasMaxLength(20);
            });

            // Configuración de la entidad Colaborador
            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.ToTable("Colaboradores");
                entity.HasKey(c => c.ColaboradorID);
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Apellido).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Correo).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Telefono).IsRequired().HasMaxLength(15);
                entity.Property(c => c.DepartamentoID).IsRequired(false);
                entity.Property(c => c.VehiculoID).IsRequired(false);
            });

            // Configuración de la entidad Departamento
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("Departamentos");
                entity.HasKey(d => d.DepartamentoID);
                entity.Property(d => d.Nombre).IsRequired().HasMaxLength(50);
            });

            // Configuración de la entidad EstadosVehiculo
            modelBuilder.Entity<EstadosVehiculo>(entity =>
            {
                entity.ToTable("EstadosVehiculo"); // Asegúrate de que coincida con el nombre de tu tabla
                entity.HasKey(e => e.EstadoVehiculoID); // Definir la clave primaria
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(50); // Configurar propiedades
            });

            // Configuración de la entidad TiposVehiculo
            modelBuilder.Entity<TiposVehiculo>(entity =>
            {
                entity.ToTable("TiposVehiculo"); // Nombre de la tabla
                entity.HasKey(t => t.TipoVehiculoID); // Definir la clave primaria
                entity.Property(t => t.Tipo).IsRequired().HasMaxLength(50); // Configurar propiedad
            });
        }
    }
}


