namespace ProyectoTranSql.Models
{
    public class NotificacionColaborador
    {
        public int NotificacionID { get; set; } // Clave primaria
        public int? AsignacionVehiculoID { get; set; }
        public int SolicitudID { get; set; } // Llave foránea a SolicitudReservacion
        public int? ColaboradorID { get; set; } // Llave foránea a Colaborador
        public string Informacion { get; set; } // Mensaje de la notificación
        public DateTime FechaHora { get; set; } // Fecha de la notificación

        //public int? RechazoID { get; set; }
        public virtual SolicitudReservacion SolicitudReservacion { get; set; }
        public virtual AsignacionVehiculo AsignacionVehiculo { get; set; }
        public virtual Colaborador Colaboradores { get; set; } // Propiedad de navegación a Colaborador
        //public virtual RechazoSolicitud RechazoSolicitud { get; set; }
    }
}

