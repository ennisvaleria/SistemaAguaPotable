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
        public FrmPrincipalAdmin(ListaUsuarios Usuario, ListaIncidencias listaIncidencias, Usuario usuario)
        {
            InitializeComponent();
            this.listaUsuarios = Usuario;
            this.listaIncidencias = listaIncidencias;
            this.usuarioActual = usuario;

            txtDNI.KeyPress += txtDNI_KeyPress;
            txtDNI.MaxLength = 8;

            listaIncidencias.MostrarIncidenciasEnDGV(dgvIncidencias);

            lblTitulo.Text = usuario.Nombres + " " + usuario.Apellidos;
        }

        private void FrmPrincipalAdmin_Load(object sender, EventArgs e)
        {

            txtDNI.Text = "Ingrese un DNI...";
            txtDNI.ForeColor = Color.Gray;
            txtDNI.Enter += txtDNI_Enter;
            txtDNI.Leave += txtDNI_Leave;

            dgvIncidencias.CellFormatting += dgvIncidencias_CellFormatting;
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
            bool actualizado = listaIncidencias.ActualizarEstadoBD(id, nuevoEstado);

            if (actualizado)
            {
                MessageBox.Show("Estado actualizado correctamente.");
                listaIncidencias.MostrarIncidenciasEnDGV(dgvIncidencias);  // Refrescar la vista de incidencias
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el estado.");
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvIncidencias.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            saveDialog.Title = "Exportar incidencias";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ExportarDatosVisibles(saveDialog.FileName);
                MessageBox.Show("Datos exportados correctamente.", "Éxito");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como retroceso)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter si no es válido
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text;
            txtDNI.Focus();

            listaIncidencias.CargarIncidenciasDesdeBD(listaUsuarios);
            listaIncidencias.BuscarPorDNI(dgvIncidencias, dni);
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            listaIncidencias.MostrarIncidenciasEnDGV(dgvIncidencias);
            txtDNI.Clear();

            txtDNI.Text = "Ingrese un DNI...";
            txtDNI.ForeColor = Color.Gray;
        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDNI.Text == "Ingrese un DNI...")
            {
                txtDNI.Text = "";
                txtDNI.ForeColor = Color.Black;
            }
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                txtDNI.Text = "Ingrese un DNI...";
                txtDNI.ForeColor = Color.Gray;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExportarDatosVisibles(string rutaArchivo)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(rutaArchivo))
            {
                for (int i = 0; i < dgvIncidencias.Columns.Count; i++)
                {
                    sw.Write(dgvIncidencias.Columns[i].HeaderText);
                    if (i < dgvIncidencias.Columns.Count - 1)
                        sw.Write("\t");
                }
                sw.WriteLine();

                foreach (DataGridViewRow fila in dgvIncidencias.Rows)
                {
                    if (fila.IsNewRow) continue;

                    for (int i = 0; i < dgvIncidencias.Columns.Count; i++)
                    {
                        sw.Write(fila.Cells[i].Value?.ToString());
                        if (i < dgvIncidencias.Columns.Count - 1)
                            sw.Write("\t");
                    }
                    sw.WriteLine();
                }
            }
        }

        private void dgvIncidencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvIncidencias.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();

                switch (estado)
                {
                    case "Resuelto":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.Black;
                        break;

                    case "Pendiente":
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.White;
                        break;

                    case "En proceso":
                        e.CellStyle.BackColor = Color.Khaki;
                        e.CellStyle.ForeColor = Color.Black;
                        break;

                    default:
                        e.CellStyle.BackColor = dgvIncidencias.DefaultCellStyle.BackColor;
                        e.CellStyle.ForeColor = dgvIncidencias.DefaultCellStyle.ForeColor;
                        break;
                }
            }
        }
    }
}
