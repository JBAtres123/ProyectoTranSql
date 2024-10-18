using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTranSql.Models
{
    public class SolicitudReservacion
    {
        public int SolicitudID { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaSolicitud { get; set; }

        // Claves foráneas
        public int? ColaboradorID { get; set; }
        public int? DepartamentoID { get; set; } // Cambiado a Nullable si puede ser nulo
        public int DestinoID { get; set; }
        public int PilotoID { get; set; }
        public int? RechazoID { get; set; }

        public int? EstadoSolicitudID { get; set; }// Nullable si puede ser nulo

        // Propiedades de navegación
        public virtual Colaborador Colaboradores { get; set; }
        public virtual Departamento Departamentos { get; set; } // Proporciona acceso al departamento
        public virtual EstadosSolicitud EstadosSolicitud { get; set; }
        public virtual Destino Destino { get; set; }
        public virtual Piloto Piloto { get; set; }
        public virtual RechazoSolicitud RechazoSolicitud { get; set; }
    }

    public class EstadosSolicitud
    {
        public int EstadoSolicitudID { get; set; }
        public string SolicitudEstado { get; set; }
    }

    public class Destino
    {
        public int DestinoID { get; set; }
        public string NombreDestino { get; set; }
    }

    public class Piloto
    {
        public int PilotoID { get; set; }
        public string NombrePiloto { get; set; }
    }

    public class RechazoSolicitud
    {
        public int RechazoID { get; set; }
        public int SolicitudID { get; set; }
        public string Justificacion { get; set; }
        public DateTime FechaRechazo { get; set; }
    }

    
}

