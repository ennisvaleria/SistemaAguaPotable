using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class Nodo
    {
        public Usuario Usuario;
        public Incidencia Incidencia;
        public Nodo siguiente;  

        public Nodo(Usuario usuario)
        {
            Usuario = usuario;
            siguiente = null;
        }

        public Nodo(Incidencia incidencia)
        {
            Incidencia = incidencia;
            siguiente = null;
        }
    }
}
