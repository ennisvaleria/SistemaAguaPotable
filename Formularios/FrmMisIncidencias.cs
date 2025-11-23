using SistemaIncidenciasAguaPotable.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIncidenciasAguaPotable.Formularios
{
    public partial class FrmMisIncidencias : Form
    {
        private ListaIncidencias listaIncidencias;// Atributo para manejar la lista de incidencias
        private Usuario usuarioActual; //Atributo para manejar el usuario actual
        private Pila pilaIncidencias;
        public FrmMisIncidencias(ListaIncidencias listaIncidencias, Usuario usuario) // Constructor que recibe la lista de incidencias y el usuario actual
        {
            InitializeComponent();
            this.listaIncidencias = listaIncidencias;
            this.usuarioActual = usuario;

            dgvIncidencias.CellFormatting += dgvIncidencias_CellFormatting;

            this.pilaIncidencias = listaIncidencias.convertirAPila();
            this.pilaIncidencias.MostrarIncidenciaEnDGV(dgvIncidencias, usuarioActual);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmMisIncidencias_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvIncidencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvIncidencias.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString().Trim();

                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.Black;

                if (estado.Equals("Resuelto", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (estado.Equals("En proceso", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.Khaki;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }
    }
}
