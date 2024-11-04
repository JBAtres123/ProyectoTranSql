using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTranSql.Models
{
    public class EstadoAccesorios
    {
        [Key]
        public int EstadoAccesorioID { get; set; }
        [Required]
        [MaxLength(20)]
        public string AccesorioEstado { get; set; }
    }

    public class Accesorios
    {
        [Key]
        public int AccesorioID { get; set; }
        [Required]
        [MaxLength(50)]
        public string NombreAccesorio { get; set; }
    }

    public class AccesorioVehiculo
    {
        [Key]
        public int AccesorioVehiculoID { get; set; }

        public virtual int VehiculoID { get; set; }
        [ForeignKey("VehiculoID")]
        public Vehiculo Vehiculo { get; set; }  

        public virtual int AccesorioID { get; set; }
        [ForeignKey("AccesorioID")]
        public Accesorios Accesorio { get; set; }  

        public virtual int EstadoAccesorioID { get; set; }
        [ForeignKey("EstadoAccesorioID")]
        public virtual EstadoAccesorios EstadoAccesorio { get; set; }  
    }
}