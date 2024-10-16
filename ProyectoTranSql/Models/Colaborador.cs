namespace ProyectoTranSql.Models
{
    public class Colaborador
    {
        public int ColaboradorID { get; set; } // Identificador único
        public string Nombre { get; set; } // Nombre del colaborador
        public string Apellido { get; set; } // Apellido del colaborador
        public string Correo { get; set; } // Correo electrónico
        public string Telefono { get; set; } // Número de teléfono
        public int? DepartamentoID { get; set; } // ID del departamento (nullable)
        public int? VehiculoID { get; set; } // ID del vehículo (nullable)
    }
}

