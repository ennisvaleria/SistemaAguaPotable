using SistemaIncidenciasAguaPotable.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIncidenciasAguaPotable
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ListaUsuarios listaUsuarios = new ListaUsuarios();
            ListaIncidencias listaIncidencias = new ListaIncidencias();

            Usuario admin = new Usuario("Ennis Valeria", "Correa Albitres", "60492144", "159123", "Administrador"); // Usuario administrador por defecto
            listaUsuarios.AgregarUsuario(admin); // Agregar el usuario administrador a la lista de usuarios

            Application.Run(new Formularios.FrmLogin(listaUsuarios, listaIncidencias));
        }
    }
}
