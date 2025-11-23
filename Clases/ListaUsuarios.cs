using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class ListaUsuarios
    {
        private ConexionBD conexionBD;
        private Nodo cabeza;

        public ListaUsuarios()
        {
            cabeza = null;
            conexionBD = new ConexionBD();
        }

        public void ListarUsuariosDesdeBD()
        {
            try
            {
                conexionBD.AbrirConexion();
                string query = "SELECT Id, Nombres, Apellidos, DNI, Contraseña, Rol FROM Usuarios";
                SqlCommand comando = new SqlCommand(query, conexionBD.ObtenerConexion());
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario(
                        reader["Id"].ToString() != null ? Convert.ToInt32(reader["Id"]) : 0, // Asegurarse de convertir a int
                        reader["Nombres"].ToString(),
                        reader["Apellidos"].ToString(),
                        reader["DNI"].ToString(),
                        reader["Contraseña"].ToString(),
                        reader["Rol"].ToString()
                    );
                    AgregarUsuarioDesdeBD(usuario);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }
        public void GuardarUsuarioEnBD(Usuario usuario)
        {
            try
            {
                conexionBD.AbrirConexion();
                string query = @"
                                 INSERT INTO Usuarios (Nombres, Apellidos, DNI, Contraseña, Rol)
                                 OUTPUT INSERTED.Id
                                 VALUES (@Nombres, @Apellidos, @DNI, @Contraseña, @Rol);";
                SqlCommand comando = new SqlCommand(query, conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                comando.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                comando.Parameters.AddWithValue("@DNI", usuario.DNI);
                comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                comando.Parameters.AddWithValue("@Rol", usuario.Rol);

                int nuevoId = Convert.ToInt32(comando.ExecuteScalar());
                usuario.Id = nuevoId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public void AgregarUsuario(Usuario nuevo)
        {
            if (DniEsInvalido(nuevo.DNI))
            {
                MessageBox.Show("El DNI ingresado no es válido. No puede contener todos los dígitos iguales.");
                return;
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
        public void AgregarUsuarioDesdeBD(Usuario usuario)
        {
            if (usuario == null) return;

            Nodo nuevoNodo = new Nodo(usuario);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.siguiente != null)
                {
                    actual = actual.siguiente;
                }
                actual.siguiente = nuevoNodo;
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

        public Usuario BuscarUsuarioPorId(int id)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Usuario != null && actual.Usuario.Id == id)
                {
                    return actual.Usuario;
                }
                actual = actual.siguiente;
            }
            return null;
        }
        public bool DniEsInvalido(string dni)
        {
            // 1. Debe tener 8 dígitos
            if (dni.Length != 8 || !dni.All(char.IsDigit))
                return true;

            // 2. Todos los dígitos iguales → inválido
            return dni.Distinct().Count() == 1;
        }
    }
}
