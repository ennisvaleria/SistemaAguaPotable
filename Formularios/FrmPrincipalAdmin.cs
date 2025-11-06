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
    public partial class FrmPrincipalAdmin : Form
    {
        private ListaIncidencias listaIncidencias; // Atributo para manejar la lista de incidencias
        private ListaUsuarios listaUsuarios; // Atributo para manejar la lista de usuarios  
        private Usuario usuarioActual; // Atributo para manejar el usuario actual
        private Pila pilaIncidencias;
        public FrmPrincipalAdmin(ListaUsuarios Usuario, ListaIncidencias listaIncidencias, Usuario usuario)
        {
            InitializeComponent();
            this.listaUsuarios = Usuario;
            this.listaIncidencias = listaIncidencias;
            this.usuarioActual = usuario;

            this.pilaIncidencias = listaIncidencias.convertirAPila();
            this.pilaIncidencias.MostrarIncidenciaEnDGV(dgvIncidencias);

            lblTitulo.Text = $"Bienvenido, " + usuario.Nombres + " " + usuario.Apellidos + ":)";
        }

        private void FrmPrincipalAdmin_Load(object sender, EventArgs e)
        {

        }
        
        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            if (dgvIncidencias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una incidencia para actualizar su estado.", "Advertencia");
                return;
            }

            if (cboNuevoEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un nuevo estado");
                return;
            }
            // Obtener el ID de la incidencia seleccionada
            int id = Convert.ToInt32(dgvIncidencias.SelectedRows[0].Cells[0].Value);

            // Obtener el nuevo estado seleccionado
            string nuevoEstado = cboNuevoEstado.SelectedItem.ToString();

            // Actualizar el estado en la lista de incidencias
            bool actualizado = listaIncidencias.ActualizarEstado(id, nuevoEstado);

            if (actualizado)
            {
                MessageBox.Show("Estado actualizado correctamente.");
                pilaIncidencias.MostrarIncidenciaEnDGV(dgvIncidencias); ; // Refrescar la vista de incidencias
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el estado.");
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            saveDialog.Title = "Exportar incidencias";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                listaIncidencias.ExportarTXT(saveDialog.FileName);
            }

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin(listaUsuarios, listaIncidencias);
            login.Show();
            this.Hide();
        }

        private void dgvIncidencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
