using System.ComponentModel.DataAnnotations.Schema;


    namespace ProyectoTranSql.Models
    {
        public class AsignacionVehiculo
        {
            public int AsignacionVehiculoID { get; set; }
            public int? ColaboradorID { get; set; }
            public int? VehiculoID { get; set; }
            public DateTime FechaAsignacion { get; set; }

            [ForeignKey("ColaboradorID")]
            public Colaborador Colaboradores { get; set; }

            [ForeignKey("VehiculoID")]
            public Vehiculo Vehiculo { get; set; }
        }
    }

