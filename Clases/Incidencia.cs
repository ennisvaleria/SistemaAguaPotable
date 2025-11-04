using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class Incidencia
    {
        public int Id;
        public string Tipo;
        public string Sector;
        public string Descripcion;
        public string Estado;
        public DateTime FechaReporte;
        public Usuario UsuarioReportante;

        public Incidencia(int id, string tipo, string sector, string descripcion, string fecha, Usuario usuario)
        {
            Id = id;
            Tipo = tipo;
            Sector = sector;
            Descripcion = descripcion;
            Estado = "Pendiente"; 
            FechaReporte = DateTime.Parse(fecha);
            UsuarioReportante = usuario;
        }
    }
}
