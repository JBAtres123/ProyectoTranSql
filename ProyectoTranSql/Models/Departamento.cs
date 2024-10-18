namespace ProyectoTranSql.Models
{
    public class Departamento
    {
        public int DepartamentoID { get; set; }
        public string Nombre { get; set; }


        public virtual ICollection<SolicitudReservacion> SolicitudReservacion { get; set; }
    }
}
