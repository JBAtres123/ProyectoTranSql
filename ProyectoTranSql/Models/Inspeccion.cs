using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTranSql.Models
{
    public class Inspeccion
    {
        [Key]
        public int InspeccionID { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreResponsableEntrega { get; set; }

        [Required]
        [Column(TypeName = "decimal(30, 2)")]
        public decimal KilometrajeInicial { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreResponsableRecepcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(30, 2)")]
        public decimal KilometrajeFinal { get; set; }

        [StringLength(200)]
        public string Observaciones { get; set; }

        // Relaciones
        public int AsignacionVehiculoID { get; set; }
        [ForeignKey("AsignacionVehiculoID")]
        public AsignacionVehiculo AsignacionVehiculo { get; set; }

        public int? AccesorioVehiculoID { get; set; }
        [ForeignKey("AccesorioVehiculoID")]
        public AccesorioVehiculo AccesorioVehiculo { get; set; }

        public int? VehiculoID { get; set; }

        public Vehiculo? Vehiculo { get; set; }
    }
}
