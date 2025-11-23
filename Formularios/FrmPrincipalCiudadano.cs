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
    public partial class FrmPrincipalCiudadano : Form
    {
        private ListaUsuarios listaUsuarios; // Atributo para manejar la lista de usuarios
        private ListaIncidencias listaIncidencias; // Atributo para manejar la lista de incidencias
        private Usuario usuarioActual; // Atributo para manejar el usuario actual
        public FrmPrincipalCiudadano(ListaUsuarios listaUsuarios, ListaIncidencias listaIncidencias, Usuario usuario)// Constructor que recibe la lista de usuarios, la lista de incidencias y el usuario actual
        {
            InitializeComponent();
            this.listaUsuarios = listaUsuarios; // Asignar la lista de usuarios al atributo
            this.listaIncidencias = listaIncidencias; // Asignar la lista de incidencias al atributo
            this.usuarioActual = usuario; //    Asignar el usuario actual al atributo

            txtDNI.KeyPress += txtDNI_KeyPress;
            txtDNI.MaxLength = 8;
            lblTitulo.Text =  usuario.Nombres + " " + usuario.Apellidos;

        }
        private void FrmPrincipalCiudadano_Load(object sender, EventArgs e)
        {
            txtDNI.Text = "Ingrese un DNI...";
            txtDNI.ForeColor = Color.Gray;

            txtDNI.Enter += txtDNI_Enter;
            txtDNI.Leave += txtDNI_Leave;
            dgvIncidencias.CellFormatting += dgvIncidencias_CellFormatting;
            if (listaIncidencias != null && dgvIncidencias != null)
            {
                listaIncidencias.MostrarIncidenciasEnDGV(dgvIncidencias); // Mostrar las incidencias en el DataGridView
            }
            
            if (dgvIncidencias.Columns["Fecha Reporte"] != null)
            {
                dgvIncidencias.Columns["Fecha Reporte"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";// Formatear la columna de fecha y hora

            }
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FrmRegistrarIncidencia frm = new FrmRegistrarIncidencia(listaIncidencias, usuarioActual);// Crear una nueva instancia del formulario de registro de incidencias
            frm.ShowDialog();

            listaIncidencias.MostrarIncidenciasEnDGV(dgvIncidencias);// Actualizar la vista de incidencias
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            listaIncidencias.MostrarIncidenciasEnDGV(dgvIncidencias);// Actualizar la vista de incidencias
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin(listaUsuarios, listaIncidencias);// Crear una nueva instancia del formulario de login
            login.Show();// Mostrar el formulario de login
            this.Hide();// Cerrar el formulario actual
        }

        private void btnVerMisIncidencias_Click(object sender, EventArgs e)
        {
            FrmMisIncidencias frmMis = new FrmMisIncidencias(listaIncidencias, usuarioActual);// Crear una nueva instancia del formulario de mis incidencias
            frmMis.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();
            txtDNI.Focus();
            listaIncidencias.CargarIncidenciasDesdeBD(listaUsuarios); // Recargar incidencias desde la BD antes de buscar
            listaIncidencias.BuscarPorDNI(dgvIncidencias, dni);
        }
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como retroceso)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter si no es válido
            }
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            listaIncidencias.MostrarIncidenciasEnDGV(dgvIncidencias);
            txtDNI.Clear();
            txtDNI.Text = "Ingrese un DNI...";
            txtDNI.ForeColor = Color.Gray;
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

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
