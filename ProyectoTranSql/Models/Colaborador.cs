using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTranSql.Models
{
    public class Colaborador
    {
        public int ColaboradorID { get; set; } // Identificador único
        public string Nombre { get; set; } // Nombre del colaborador
        public string Apellido { get; set; } // Apellido del colaborador
        public string Correo { get; set; } // Correo electrónico
        public string Telefono { get; set; } // Número de teléfono

        // Relaciones con otras entidades
        public int? DepartamentoID { get; set; } // ID del departamento (nullable)
        public Departamento? Departamento { get; set; } // Propiedad de navegación a Departamento

        public int? VehiculoID { get; set; } // ID del vehículo (nullable)
        public Vehiculo? Vehiculo { get; set; } // Propiedad de navegación a Vehiculo
    }
}


