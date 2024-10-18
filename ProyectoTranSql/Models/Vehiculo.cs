using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTranSql.Models
{
    public class Vehiculo
    {
        public int VehiculoID { get; set; }
        public int ModeloVehiculoID { get; set; }
        public int TipoVehiculoID { get; set; }
        public int EstadoVehiculoID { get; set; }
        public string Capacidad { get; set; } 
        public string Placa { get; set; } 

   
        public virtual ModeloVehiculo ModeloVehiculo { get; set; }
        public virtual TiposVehiculo TipoVehiculo { get; set; }
        public virtual EstadosVehiculo EstadoVehiculo { get; set; }
    }


    public class TiposVehiculo
    {
       
        public int TipoVehiculoID { get; set; } 

        public string Tipo { get; set; } 
    }


    [Table("ModeloVehiculo")]
    public class ModeloVehiculo
    {
        public int ModeloVehiculoID { get; set; }
        public string Modelo { get; set; } // Nombre del modelo del vehículo
        public int Año { get; set; }
        public int MarcaVehiculoID { get; set; }

        // Relación con MarcaVehiculo
        public virtual MarcaVehiculo MarcaVehiculo { get; set; }
    }



    [Table("MarcaVehiculo")]
    public class MarcaVehiculo
    {
        public int MarcaVehiculoID { get; set; }
        public string Marca { get; set; } // Cambiado de Nombre a Marca
    }


    public class EstadosVehiculo
    {
        public int EstadoVehiculoID { get; set; }
        public string Estado { get; set; } // Cambiado a Estado para coincidir con la tabla
    }

}

