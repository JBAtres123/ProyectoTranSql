using Microsoft.EntityFrameworkCore;
using ProyectoTranSql.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTranSql.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<ModeloVehiculo> ModelosVehiculo { get; set; }
        public DbSet<MarcaVehiculo> MarcasVehiculo { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<TiposVehiculo> TiposVehiculo { get; set; }
        public DbSet<EstadosVehiculo> EstadosVehiculo { get; set; }
        public DbSet<EstadosSolicitud> EstadosSolicitud { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<Piloto> Piloto { get; set; }
        public DbSet<RechazoSolicitud> RechazoSolicitud { get; set; }
        public DbSet<SolicitudReservacion> SolicitudReservacion { get; set; }
        public DbSet<AsignacionVehiculo> AsignacionVehiculo { get; set; }
        public DbSet<GaritaControl> GaritaControl { get; set; }

        public DbSet<NotificacionColaborador> NotificacionColaborador { get; set; }

        public DbSet<EstadoAccesorios> EstadoAccesorios { get; set; }
        public DbSet<Accesorios> Accesorios { get; set; }
        public DbSet<AccesorioVehiculo> AccesorioVehiculo { get; set; }

        public DbSet<Inspeccion> Inspeccion { get; set; }

        public async Task<List<Colaborador>> GetColaboradoresConRelacionesAsync()
        {
            return await Colaboradores
                .Include(c => c.Departamento) // Relación con el Departamento
                .Include(c => c.Vehiculo)     // Relación con el Vehículo (si existe)
                .ToListAsync();               // Devuelve la lista asincrónicamente
        }

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
                entity.HasKey(es => es.EstadoSolicitudID);
                entity.Property(es => es.SolicitudEstado).IsRequired().HasMaxLength(100);
            });

            // Configuración de la entidad Destino
            modelBuilder.Entity<Destino>(entity =>
            {
                entity.ToTable("Destino");
                entity.HasKey(d => d.DestinoID);
                entity.Property(d => d.NombreDestino).IsRequired().HasMaxLength(100);
            });

            // Configuración de la entidad Piloto
            modelBuilder.Entity<Piloto>(entity =>
            {
                entity.ToTable("Piloto");
                entity.HasKey(p => p.PilotoID);
                entity.Property(p => p.NombrePiloto).IsRequired().HasMaxLength(50);
            });

            // Configuración de la entidad RechazoSolicitud
            modelBuilder.Entity<RechazoSolicitud>(entity =>
            {
                entity.ToTable("RechazoSolicitud");
                entity.HasKey(r => r.RechazoID);
                entity.Property(r => r.Justificacion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(r => r.FechaRechazo)
                    .IsRequired();

                entity.HasOne(sr => sr.SolicitudReservacion)
                    .WithMany()
                    .HasForeignKey(sr => sr.SolicitudID);
                entity.HasOne(sr => sr.Colaboradores)
                    .WithMany()
                    .HasForeignKey(sr => sr.ColaboradorID);
            });

            // Configuración de la entidad SolicitudReservacion
            modelBuilder.Entity<SolicitudReservacion>(entity =>
            {
                entity.ToTable("SolicitudReservacion");
                entity.HasKey(sr => sr.SolicitudID);

                entity.HasOne(sr => sr.Colaboradores)
                    .WithMany()
                    .HasForeignKey(sr => sr.ColaboradorID);

                entity.HasOne(sr => sr.EstadosSolicitud)
                    .WithMany()
                    .HasForeignKey(sr => sr.EstadoSolicitudID);

                entity.HasOne(sr => sr.Destino)
                    .WithMany()
                    .HasForeignKey(sr => sr.DestinoID);

                entity.HasOne(sr => sr.Piloto)
                    .WithMany()
                    .HasForeignKey(sr => sr.PilotoID);
            });

            // Configuración de la entidad AsignacionVehiculo
            modelBuilder.Entity<AsignacionVehiculo>(entity =>
            {
                entity.ToTable("AsignacionVehiculo");
                entity.HasKey(av => av.AsignacionVehiculoID);

                entity.Property(av => av.FechaAsignacion)
                      .IsRequired();

                entity.HasOne(av => av.Vehiculo)
                      .WithMany()
                      .HasForeignKey(av => av.VehiculoID);

                entity.HasOne(av => av.Colaboradores)
                      .WithMany()
                      .HasForeignKey(av => av.ColaboradorID);
            });

            // Configuración de la entidad GaritaControl
            modelBuilder.Entity<GaritaControl>(entity =>
            {
                entity.ToTable("GaritaControl");
                entity.HasKey(gc => gc.GaritaID);

                entity.Property(gc => gc.NotificacionGarita)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.Property(gc => gc.FechaNotificacion)
                      .IsRequired();

                entity.HasOne(gc => gc.AsignacionVehiculo)
                      .WithMany()
                      .HasForeignKey(gc => gc.AsignacionVehiculoID);
            });

            modelBuilder.Entity<NotificacionColaborador>(entity =>
            {
                entity.ToTable("NotificacionColaborador");
                entity.HasKey(n => n.NotificacionID);
                entity.Property(n => n.Informacion) // Cambiado a 'Informacion'
                    .IsRequired()
                    .HasMaxLength(500);
                entity.Property(n => n.FechaHora)
                    .IsRequired();

                entity.HasOne(n => n.AsignacionVehiculo) // Cambiado a 'Colaboradores'
                      .WithMany()
                      .HasForeignKey(n => n.AsignacionVehiculoID);

                entity.HasOne(n => n.SolicitudReservacion) // Añadida relación con SolicitudReservacion
                      .WithMany()
                      .HasForeignKey(n => n.SolicitudID);
                entity.HasOne(n => n.Colaboradores) // Nueva relación con Colaborador
                   .WithMany() // Asumiendo que `Colaborador` puede tener muchas notificaciones
                   .HasForeignKey(n => n.ColaboradorID)
                   .OnDelete(DeleteBehavior.Restrict);
               // entity.HasOne(n => n.RechazoSolicitud) // Asumiendo que ya tienes la propiedad de navegación
                     //.WithMany() // Asumiendo que RechazoSolicitud puede tener muchas notificaciones
                     //.HasForeignKey(n => n.RechazoID) // Aquí se establece la clave foránea
                     //.OnDelete(DeleteBehavior.Restrict);
            });

             // Configuración de la entidad EstadoAccesorios
            modelBuilder.Entity<EstadoAccesorios>(entity =>
            {
                entity.ToTable("EstadoAccesorios");
                entity.HasKey(ea => ea.EstadoAccesorioID);
                entity.Property(ea => ea.AccesorioEstado)
                      .IsRequired()
                      .HasMaxLength(20);
            });

            // Configuración de la entidad Accesorios
            modelBuilder.Entity<Accesorios>(entity =>
            {
                entity.ToTable("Accesorios");
                entity.HasKey(a => a.AccesorioID);
                entity.Property(a => a.NombreAccesorio)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            // Configuración de la entidad AccesorioVehiculo
            modelBuilder.Entity<AccesorioVehiculo>(entity =>
            {
                entity.ToTable("AccesorioVehiculo");
                entity.HasKey(av => av.AccesorioVehiculoID);

                entity.HasOne(av => av.Vehiculo)
                      .WithMany()
                      .HasForeignKey(av => av.VehiculoID);

                entity.HasOne(av => av.Accesorio)
                      .WithMany()
                      .HasForeignKey(av => av.AccesorioID);

                entity.HasOne(av => av.EstadoAccesorio)
                      .WithMany()
                      .HasForeignKey(av => av.EstadoAccesorioID);
            });
            modelBuilder.Entity<Inspeccion>(entity =>
            {
                entity.ToTable("Inspeccion");
                entity.HasKey(i => i.InspeccionID);
                entity.Property(i => i.NombreResponsableEntrega)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(i => i.KilometrajeInicial)
                      .IsRequired()
                      .HasColumnType("decimal(30, 2)");
                entity.Property(i => i.NombreResponsableRecepcion)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(i => i.KilometrajeFinal)
                      .IsRequired()
                      .HasColumnType("decimal(30, 2)");
                entity.Property(i => i.Observaciones)
                      .HasMaxLength(200);

                entity.HasOne(i => i.AsignacionVehiculo)
                      .WithMany()
                      .HasForeignKey(i => i.AsignacionVehiculoID)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("FK_Inspeccion_AsignacionVehiculo");

                entity.HasOne(i => i.AccesorioVehiculo)
                      .WithMany()
                      .HasForeignKey(i => i.AccesorioVehiculoID)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("FK_Inspeccion_AccesorioVehiculo");
            });
        }
    }
}
