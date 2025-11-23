using System;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class Incidencia
    {
        public int Id;
        public string Tipo;
        public string Calle;
        public string Descripcion;
        public string Estado;
        public DateTime FechaReporte;
        public Usuario UsuarioReportante;

        // Constructor para incidencias cargadas desde la BD (con ID)
        public Incidencia(int id, string tipo, string calle, string descripcion, string estado, DateTime fecha, Usuario usuario)
        {
            Id = id;
            Tipo = tipo;
            Calle = calle;
            Descripcion = descripcion;
            Estado = estado; 
            FechaReporte = fecha;
            UsuarioReportante = usuario;
        }
        // Constructor para incidencias nuevas (sin ID)
        public Incidencia(string tipo, string calle, string descripcion, string estado, DateTime fecha, Usuario usuario)
        {
            Tipo = tipo;
            Calle = calle;
            Descripcion = descripcion;
            Estado = estado;
            FechaReporte = fecha;
            UsuarioReportante = usuario;
        }
    }
}
