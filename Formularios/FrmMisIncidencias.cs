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
        public FrmMisIncidencias(ListaIncidencias listaIncidencias, Usuario usuario) // Constructor que recibe la lista de incidencias y el usuario actual
        {
            InitializeComponent();
            this.listaIncidencias = listaIncidencias;
            this.usuarioActual = usuario;
            listaIncidencias.MostrarIncidenciasEnDGV(dgvIncidencias, usuarioActual);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmMisIncidencias_Load(object sender, EventArgs e)
        {
            listaIncidencias.MostrarIncidenciasEnDGV(dgvIncidencias, usuarioActual);
        }

        
    }
}
