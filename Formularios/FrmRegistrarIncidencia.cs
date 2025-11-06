using SistemaIncidenciasAguaPotable.Clases;
using System;
using System.Windows.Forms;

namespace SistemaIncidenciasAguaPotable.Formularios
{
    public partial class FrmRegistrarIncidencia : Form
    {
        private ListaIncidencias listaIncidencias; // Atributo para manejar la lista de incidencias
        private Usuario usuarioActual;// Atributo para manejar el usuario actual
        public FrmRegistrarIncidencia(ListaIncidencias listaIncidencias, Usuario usuario)
        {
            InitializeComponent();
            this.listaIncidencias = listaIncidencias;
            this.usuarioActual = usuario;
        }

        private void FrmRegistrarIncidencia_Load(object sender, EventArgs e)
        {
       

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un tipo de incidencia.");
                cboTipo.Focus();
                return;
            }
            if (cboSector.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un sector.");
                cboSector.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción del problema.");
                txtDescripcion.Focus();
                return;
            }

            string tipo = cboTipo.SelectedItem.ToString();
            string sector = cboSector.SelectedItem.ToString();
            string descripcion = txtDescripcion.Text.Trim();
            DateTime fecha = DateTime.Now;

            Incidencia incidencia = new Incidencia(tipo, sector, descripcion, "Pendiente", fecha, usuarioActual);
            listaIncidencias.AgregarIncidenciaBD(incidencia); // Guarda en BD y asigna Id
            listaIncidencias.AgregarIncidenciaMemoria(incidencia); // Luego la agregas a la lista en memoria


            MessageBox.Show("Incidencia registrada con éxito.");

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cboTipo.SelectedIndex = -1;
            cboSector.SelectedIndex = -1;
            txtDescripcion.Clear();
            cboTipo.Focus();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
