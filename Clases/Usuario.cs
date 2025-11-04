using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class Usuario
    {
        public string Nombres;
        public string Apellidos;
        public string DNI;
        public string Contraseña;
        public string Rol;

        public Usuario(string nombres, string apellidos, string Dni, string contraseña, string rol)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            DNI = Dni;
            Contraseña = contraseña;
            Rol = rol;
        }
        
    }
}
