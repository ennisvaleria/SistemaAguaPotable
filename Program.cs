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
            listaUsuarios.ListarUsuariosDesdeBD();

            ListaIncidencias listaIncidencias = new ListaIncidencias();
            listaIncidencias.CargarIncidenciasDesdeBD(listaUsuarios);
            if(!listaUsuarios.ExisteUsuario("60492144"))
            {
                Usuario admin = new Usuario("Ennis Valeria", "Correa Albitres", "60492144", "159123", "Administrador"); // Usuario administrador por defecto
                listaUsuarios.AgregarUsuario(admin);
                listaUsuarios.GuardarUsuarioEnBD(admin);
            }
           

            Application.Run(new Formularios.FrmLogin(listaUsuarios, listaIncidencias));
        }
    }
}
