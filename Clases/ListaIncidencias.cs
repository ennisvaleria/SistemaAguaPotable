using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class ListaIncidencias
    {
        private Nodo cabeza; // Cabeza de la lista enlazada
        private int contadorId = 1; // Contador para asignar IDs únicos a las incidencias

        public ListaIncidencias()
        {
            cabeza = null; // Inicializar la cabeza de la lista como nula
        }

        public void AgregarIncidencia(string tipo, string sector, string descripcion, string fecha, Usuario usuario) // Agregar una nueva incidencia a la lista
        {
            Incidencia nueva = new Incidencia(contadorId++, tipo, sector, descripcion, fecha, usuario);
            Nodo nuevoNodo = new Nodo(nueva);
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
                actual.siguiente = nuevoNodo; // Enlazar el nuevo nodo al final de la lista
            }
        }

        public bool ActualizarEstado(int id, string nuevoEstado)
        {
            Nodo actual = cabeza;

            while (actual != null)
            {
                if (actual.Incidencia.Id == id)
                {
                    actual.Incidencia.Estado = nuevoEstado;
                    return true;
                }
                actual = actual.siguiente; // Avanzar al siguiente nodo
            }
            return false; // No se encontró la incidencia
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

        public Nodo ObtenerCabeza()
        {
            return cabeza;
        }

        public void MostrarIncidenciasEnDGV(DataGridView dgv, Usuario usuarioFiltrado = null)
        {
            dgv.Rows.Clear();

            if (dgv.Columns.Count > 1)
            {
                dgv.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            Nodo actual = cabeza;

            while (actual != null)
            {
                if (actual.Incidencia != null)
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
                            actual.Incidencia.UsuarioReportante.DNI);
                    }
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
