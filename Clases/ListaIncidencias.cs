using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class ListaIncidencias
    {
        private Pila pilaIncidencias;
        private ConexionBD conexionBD;

        private Nodo cabeza; // Cabeza de la lista enlazada
        public ListaIncidencias()
        {
            pilaIncidencias = new Pila();
            conexionBD = new ConexionBD();

            cabeza = null; // Inicializar la cabeza de la lista como nula
        }

        public void CargarIncidenciasDesdeBD(ListaUsuarios listaUsuarios)
        {
            try
            {
                conexionBD.AbrirConexion();
                string query = "SELECT Id, Tipo, Sector, Descripcion, Estado, FechaReporte, UsuarioReportanteId FROM Incidencias";
                SqlCommand comando = new SqlCommand(query, conexionBD.ObtenerConexion());
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    int usuarioId = Convert.ToInt32(reader["UsuarioReportanteId"]);
                    Usuario usuario = listaUsuarios.BuscarUsuarioPorId(usuarioId);

                    if (usuario != null)
                    {
                        Incidencia incidencia = new Incidencia(
                            id: Convert.ToInt32(reader["Id"]),
                            tipo: reader["Tipo"].ToString(),
                            sector: reader["Sector"].ToString(),
                            descripcion: reader["Descripcion"].ToString(),
                            estado: reader["Estado"].ToString(),
                            fecha: Convert.ToDateTime(reader["FechaReporte"].ToString()),
                            usuario: usuario
                        );

                        AgregarIncidenciaMemoria(incidencia);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar incidencias: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

        }
        public void AgregarIncidenciaMemoria(Incidencia incidencia)
        {
            Nodo nuevoNodo = new Nodo(incidencia);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.siguiente != null)
                    actual = actual.siguiente;

                actual.siguiente = nuevoNodo;
            }
        }


        public void AgregarIncidenciaBD(Incidencia incidencia)
        {
            try
            {
                conexionBD.AbrirConexion();
                string query = @"
                                INSERT INTO Incidencias (Tipo, Sector, Descripcion, Estado, FechaReporte, UsuarioReportanteId)
                                OUTPUT INSERTED.Id
                                VALUES (@Tipo, @Sector, @Descripcion, @Estado, @FechaReporte, @UsuarioReportanteId);";
                SqlCommand comando = new SqlCommand(query, conexionBD.ObtenerConexion());
                comando.Parameters.AddWithValue("@Tipo", incidencia.Tipo);
                comando.Parameters.AddWithValue("@Sector", incidencia.Sector);
                comando.Parameters.AddWithValue("@Descripcion", incidencia.Descripcion);
                comando.Parameters.AddWithValue("@Estado", incidencia.Estado);
                comando.Parameters.AddWithValue("@FechaReporte", incidencia.FechaReporte);
                comando.Parameters.AddWithValue("@UsuarioReportanteId", incidencia.UsuarioReportante.Id);

                int nuevoId = Convert.ToInt32(comando.ExecuteScalar());
                incidencia.Id = nuevoId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la incidencia en la base de datos: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public bool ActualizarEstado(int id, string nuevoEstado)
        {
            Nodo actual = cabeza;
            bool actualizado = false;

            while (actual != null)
            {
                if (actual.Incidencia.Id == id)
                {
                    actual.Incidencia.Estado = nuevoEstado;
                    actualizado = true;
                    break;
                }
                actual = actual.siguiente;
            }

            if (actualizado)
            {
                try
                {
                    conexionBD.AbrirConexion();
                    string query = "UPDATE Incidencias SET Estado = @Estado WHERE Id = @Id";
                    SqlCommand comando = new SqlCommand(query, conexionBD.ObtenerConexion());
                    comando.Parameters.AddWithValue("@Estado", nuevoEstado);
                    comando.Parameters.AddWithValue("@Id", id);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar incidencia en la BD: " + ex.Message);
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }

            return actualizado;
        }
        public void ExportarTXT(string rutaArchivo)
        {
            using (StreamWriter sw = new StreamWriter(rutaArchivo)) // Abrir el archivo para escribir
            {
                Nodo actual = cabeza;
                while (actual != null)
                {
                    sw.WriteLine($"ID: {actual.Incidencia.Id}"); // Escribir los detalles de la incidencia
                    sw.WriteLine($"Tipo: {actual.Incidencia.Tipo}");
                    sw.WriteLine($"Sector: {actual.Incidencia.Sector}");
                    sw.WriteLine($"Descripción: {actual.Incidencia.Descripcion}");
                    sw.WriteLine($"Estado: {actual.Incidencia.Estado}");
                    sw.WriteLine($"Fecha: {actual.Incidencia.FechaReporte}");
                    sw.WriteLine($"Reportado por: {actual.Incidencia.UsuarioReportante.Nombres} {actual.Incidencia.UsuarioReportante.Apellidos}");
                    sw.WriteLine(new string('-', 40));
                    actual = actual.siguiente;
                }
            }
            MessageBox.Show("Incidencias exportadas exitosamente.");
        }


        public void MostrarIncidenciasEnDGV(DataGridView dgv, Usuario usuarioFiltrado = null)
        {
            if (dgv.Columns.Count == 0)
            {
                dgv.Columns.Add("Id", "ID");
                dgv.Columns.Add("FechaReporte", "Fecha Reporte");
                dgv.Columns.Add("Tipo", "Tipo");
                dgv.Columns.Add("Sector", "Sector");
                dgv.Columns.Add("Descripcion", "Descripción");
                dgv.Columns.Add("Estado", "Estado");
                dgv.Columns.Add("Nombres", "Nombres");
                dgv.Columns.Add("Apellidos", "Apellidos");
                dgv.Columns.Add("DNI", "DNI");
            }
            dgv.Rows.Clear();

            if (dgv.Columns.Count > 1)
                dgv.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            Nodo actual = cabeza;

            while (actual != null)
            {
                if (usuarioFiltrado == null || actual.Incidencia.UsuarioReportante.DNI == usuarioFiltrado.DNI)
                {
                    dgv.Rows.Add(
                        actual.Incidencia.Id,
                        actual.Incidencia.FechaReporte,
                        actual.Incidencia.Tipo,
                        actual.Incidencia.Sector,
                        actual.Incidencia.Descripcion,
                        actual.Incidencia.Estado,
                        actual.Incidencia.UsuarioReportante.Nombres,
                        actual.Incidencia.UsuarioReportante.Apellidos,
                        actual.Incidencia.UsuarioReportante.DNI
                    );
                }
                actual = actual.siguiente;
            }

            dgv.ClearSelection();
        }
        public Pila convertirAPila()
        {
            Pila pila = new Pila();
            Nodo actual = cabeza;
            while (actual != null)
            {
                pila.push(actual.Incidencia);
                actual = actual.siguiente;
            }
            return pila;
        }

    }
}
        
        