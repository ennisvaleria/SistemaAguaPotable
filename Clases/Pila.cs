using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIncidenciasAguaPotable.Clases
{
    public class Pila
    {
        private Nodo inicio;                  
        public Pila()
        {
            inicio = null;
        }

        public void push (Incidencia incidencia)
        {
            Nodo nuevoNodo = new Nodo(incidencia);
            nuevoNodo.siguiente = inicio;
            inicio = nuevoNodo;
        }
        public void MostrarIncidenciaEnDGV(DataGridView dgv, Usuario usuarioFiltrado = null)
        {

            {
                dgv.Rows.Clear();

                if (dgv.Columns.Count > 1)
                {
                    dgv.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                
                Nodo actual = inicio;

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
                                actual.Incidencia.Calle,
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
        }
    }
}
