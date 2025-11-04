using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class ListaUsuarios
    {
        private Nodo cabeza;

        public ListaUsuarios()
        {
            cabeza = null;
        }

        public void AgregarUsuario(Usuario nuevo)
        {
            if(nuevo == null)
            {
                MessageBox.Show("El usuario no puede ser nulo.");
                return; // Salir del método si el usuario es nulo
            }
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Usuario.DNI == nuevo.DNI)
                {
                    MessageBox.Show("El usuario con DNI " + nuevo.DNI + " ya existe.");
                    return; // Salir del método si el usuario ya existe
                }
                actual = actual.siguiente;
            }

            Nodo nuevoNodo = new Nodo(nuevo);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo temporal = cabeza;
                while (temporal.siguiente != null)
                {
                    temporal = temporal.siguiente;
                }
                temporal.siguiente = nuevoNodo;
            }
            
        }
        public Usuario BuscarUsuario(string Dni, string contraseña)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Usuario != null &&
                    actual.Usuario.DNI == Dni && 
                    actual.Usuario.Contraseña == contraseña)
                {
                    return actual.Usuario;// Usuario encontrado
                }
                actual = actual.siguiente;
            }
            return null; // Usuario no encontrado
        }

        public bool ExisteUsuario(string dni)
        {
            Nodo actual = cabeza;
            while (actual != null)                                      
            {
                if (actual.Usuario != null && actual.Usuario.DNI == dni)
                {
                    return true; // Usuario encontrado
                }
                actual = actual.siguiente;
            }
            return false; // Usuario no encontrado
        }
    }
}
