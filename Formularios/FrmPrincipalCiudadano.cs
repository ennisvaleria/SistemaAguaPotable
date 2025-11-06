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
            lblTitulo.Text = $"Bienvenido, " + usuario.Nombres + " " + usuario.Apellidos + ":)";

        }

        private void FrmPrincipalCiudadano_Load(object sender, EventArgs e)
        {
            if (listaIncidencias != null && dgvIncidencias != null)
            {
                listaIncidencias.MostrarIncidenciasEnDGV(dgvIncidencias, usuarioActual); // Mostrar las incidencias en el DataGridView
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
    }
}
