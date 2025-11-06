using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class Usuario
    {
        public int? Id { get; set; } // Permitir nulo para nuevos usuarios sin ID asignado
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }

        public Usuario(int? id, string nombres, string apellidos, string Dni, string contraseña, string rol)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            DNI = Dni;
            Contraseña = contraseña;
            Rol = rol;
        }

        public Usuario(string nombres, string apellidos, string dni, string contraseña, string rol)
        : this(null, nombres, apellidos, dni, contraseña, rol) { }

    }
}
