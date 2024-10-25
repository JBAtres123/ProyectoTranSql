using System.ComponentModel.DataAnnotations;

namespace ProyectoTranSql.Models
{
    public class GaritaControl
    {
        
            [Key]
            public int GaritaID { get; set; }

            public int AsignacionVehiculoID { get; set; }

            public string NotificacionGarita { get; set; }

            public DateTime FechaNotificacion { get; set; } = DateTime.Now;

          
            public virtual AsignacionVehiculo AsignacionVehiculo { get; set; }
        }
    }

