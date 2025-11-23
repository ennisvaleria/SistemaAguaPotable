using SistemaIncidenciasAguaPotable.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaIncidenciasAguaPotable.Formularios
{
    public partial class FrmLogin : Form
    {
        private ListaUsuarios listaUsuarios; 
        private ListaIncidencias listaIncidencias;
        public FrmLogin(ListaUsuarios usuarios, ListaIncidencias incidencias)
        {
            InitializeComponent();
            listaUsuarios = usuarios;
            listaIncidencias = incidencias;
            txtDNI.MaxLength = 8; // Limitar a 8 caracteres
            txtDNI.KeyPress += txtDNI_KeyPress;

            txtDNI.Text = "Ingrese su DNI";
            txtDNI.ForeColor = Color.Gray;

            txtDNI.Enter += txtDNI_Enter;
            txtDNI.Leave += txtDNI_Leave;

            txtContraseña.Text = "Ingrese su contraseña";
            txtContraseña.ForeColor = Color.Gray;
            txtContraseña.UseSystemPasswordChar = false;

            txtContraseña.Enter += txtContraseña_Enter;
            txtContraseña.Leave += txtContraseña_Leave;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(contraseña))// Validar que los campos no estén vacíos
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return; // Detener la ejecución si hay campos vacíos
            }

            Usuario usuario = listaUsuarios.BuscarUsuario(dni, contraseña);

            if (usuario == null)
            {
                if (listaUsuarios.ExisteUsuario(dni))
                {
                    MessageBox.Show("Contraseña incorrecta. Intente de nuevo.");
                    txtContraseña.Clear();
                    txtContraseña.Focus();
                }
                else
                {
                    MessageBox.Show("El usuario con DNI " + dni + " no existe. Por favor, regístrese.");
                    txtDNI.Clear();
                    txtDNI.Focus();
                    txtContraseña.Clear();
                }
                return;

            }
            if (usuario.Rol == "Administrador")
            {
                FrmPrincipalAdmin frmAdmin = new FrmPrincipalAdmin(listaUsuarios, listaIncidencias, usuario);
                frmAdmin.Show();
            }
            else
            {
                FrmPrincipalCiudadano frmCiudadano = new FrmPrincipalCiudadano(listaUsuarios, listaIncidencias, usuario);
                frmCiudadano.Show();
            }
            this.Hide(); // Oculta el formulario de login
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FrmRegistroCiudadano frmRegistro = new FrmRegistroCiudadano(listaUsuarios, this);
            frmRegistro.Show();
            this.Hide();// Oculta el formulario de login
        }
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como retroceso)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter si no es válido
            }
        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDNI.Text == "Ingrese su DNI")
            {
                txtDNI.Text = "";
                txtDNI.ForeColor = Color.Black;
            }
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                txtDNI.Text = "Ingrese su DNI";
                txtDNI.ForeColor = Color.Gray;
            }
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {

            if (txtContraseña.Text == "Ingrese su contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.Black;
                txtContraseña.UseSystemPasswordChar = true; // Activar contraseña al escribir
            }

        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                txtContraseña.Text = "Ingrese su contraseña";
                txtContraseña.ForeColor = Color.Gray;
                txtContraseña.UseSystemPasswordChar = false; // Mostrar el placeholder normalmente
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
