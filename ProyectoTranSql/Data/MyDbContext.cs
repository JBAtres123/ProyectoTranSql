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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<TiposVehiculo> TiposVehiculo { get; set; }
        public DbSet<EstadosSolicitud> EstadosSolicitud { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<Piloto> Piloto { get; set; }
        public DbSet<RechazoSolicitud> RechazoSolicitud { get; set; }
        public DbSet<SolicitudReservacion> SolicitudReservacion { get; set; }

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
                entity.ToTable("EstadosVehiculo");
                entity.HasKey(e => e.EstadoVehiculoID);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(50);
            });

            // Configuración de la entidad TiposVehiculo
            modelBuilder.Entity<TiposVehiculo>(entity =>
            {
                entity.ToTable("TiposVehiculo");
                entity.HasKey(t => t.TipoVehiculoID);
                entity.Property(t => t.Tipo).IsRequired().HasMaxLength(50);
            });

            // Configuración de la entidad EstadoSolicitud
            modelBuilder.Entity<EstadosSolicitud>(entity =>
            {
                entity.ToTable("EstadosSolicitud");
                entity.HasKey(es => es.EstadoSolicitudID); // Definir la clave primaria
                entity.Property(es => es.SolicitudEstado).IsRequired().HasMaxLength(100); // Propiedades adicionales
            });

            // Configuración de la entidad Destino
            modelBuilder.Entity<Destino>(entity =>
            {
                entity.ToTable("Destino");
                entity.HasKey(d => d.DestinoID); // Definir la clave primaria
                entity.Property(d => d.NombreDestino).IsRequired().HasMaxLength(100); // Propiedades adicionales
            });

            // Configuración de la entidad Piloto
            modelBuilder.Entity<Piloto>(entity =>
            {
                entity.ToTable("Piloto");
                entity.HasKey(p => p.PilotoID); // Definir la clave primaria
                entity.Property(p => p.NombrePiloto).IsRequired().HasMaxLength(50); // Propiedades adicionales
              
            });

            // Configuración de la entidad RechazoSolicitud
            modelBuilder.Entity<RechazoSolicitud>(entity =>
            {
                entity.ToTable("RechazoSolicitud");
                entity.HasKey(r => r.RechazoID); // Definir la clave primaria
                entity.Property(r => r.Justificacion)
                 .IsRequired()
                 .HasMaxLength(500); // Ajusta el tamaño según tus necesidades

                entity.Property(r => r.FechaRechazo)
                    .IsRequired();
            });

            // Configuración de la entidad SolicitudReservacion
            modelBuilder.Entity<SolicitudReservacion>(entity =>
            {
                entity.ToTable("SolicitudReservacion");
                entity.HasKey(sr => sr.SolicitudID); // Definir la clave primaria

                entity.HasOne(sr => sr.Colaboradores)
                    .WithMany() // Relación con Colaborador
                    .HasForeignKey(sr => sr.ColaboradorID);

                entity.HasOne(sr => sr.EstadosSolicitud)
                    .WithMany() // Relación con EstadoSolicitud
                    .HasForeignKey(sr => sr.EstadoSolicitudID);

                entity.HasOne(sr => sr.Destino)
                    .WithMany() // Relación con Destino
                    .HasForeignKey(sr => sr.DestinoID);

                entity.HasOne(sr => sr.Piloto)
                    .WithMany() // Relación con Piloto
                    .HasForeignKey(sr => sr.PilotoID);

                entity.HasOne(sr => sr.RechazoSolicitud)
                    .WithMany() // Relación con RechazoSolicitud
                    .HasForeignKey(sr => sr.RechazoID);
            });
        }
    }
}


