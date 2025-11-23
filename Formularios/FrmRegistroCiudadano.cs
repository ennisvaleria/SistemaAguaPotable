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
    public partial class FrmRegistroCiudadano : Form
    {
        private ListaUsuarios listaUsuarios;
        private FrmLogin loginForm;
        public FrmRegistroCiudadano(ListaUsuarios listaUsuarios, FrmLogin loginForm)
        {
            InitializeComponent();
            this.listaUsuarios = listaUsuarios;
            this.loginForm = loginForm; // Inicializar el formulario de login
            this.FormClosing += FrmRegistroCiudadano_FormClosing; // Suscribirse al evento FormClosing}
            txtNombres.KeyPress += txtNombres_KeyPress;
            txtApellidos.KeyPress += txtApellidos_KeyPress;
            txtDNI.KeyPress += txtDNI_KeyPress;
            txtDNI.MaxLength = 8; // Limitar a 8 caracteres
        }

        private void FrmRegistroCiudadano_Load(object sender, EventArgs e)
        {
            txtNombres.Text = "Ingrese sus nombres";
            txtNombres.ForeColor = Color.Gray;

            txtNombres.Enter += txtDNI_Enter;
            txtNombres.Leave += txtDNI_Leave;

            txtApellidos.Text = "Ingrese sus apellidos";
            txtApellidos.ForeColor = Color.Gray;

            txtApellidos.Enter += txtDNI_Enter;
            txtApellidos.Leave += txtDNI_Leave;

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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string Dni = txtDNI.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos) ||
                string.IsNullOrEmpty(Dni) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return; // Detener la ejecución si hay campos vacíos
            }
            if(Dni.Length != 8 || !Dni.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe tener 8 digítos.");
                txtDNI.Clear();
                txtDNI.Focus();
                return;
            }
            if (listaUsuarios.ExisteUsuario(Dni))//Llama al método y verifica si el DNI ya existe
            {
                MessageBox.Show("El DNI ya está registrado. Por favor, use otro.");
                txtDNI.Clear();
                txtDNI.Focus();
                return; // Detener la ejecución si el DNI ya existe
            }

            Usuario nuevoUsuario = new Usuario(nombres, apellidos, Dni, contraseña, "Ciudadano");
            listaUsuarios.AgregarUsuario(nuevoUsuario);
            listaUsuarios.GuardarUsuarioEnBD(nuevoUsuario);

            loginForm.Show();// Mostrar el formulario de login
            this.Hide();// Ocultar el formulario actual
        }
        
        private void FrmRegistroCiudadano_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Show(); // Mostrar el formulario de login
            
        }
        
        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios y teclas de control (como retroceso)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Ignorar el carácter si no es válido
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios y teclas de control (como retroceso)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Ignorar el carácter si no es válido
            }
        }
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como retroceso)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter si no es válido
            }
        }

        private void txtNombres_Enter(object sender, EventArgs e)
        {
            if (txtNombres.Text == "Ingrese sus nombres")
            {
                txtNombres.Text = "";
                txtNombres.ForeColor = Color.Black;
            }
        }

        private void txtNombres_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                txtNombres.Text = "Ingrese sus nombres";
                txtNombres.ForeColor = Color.Gray;
            }
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidos_Enter(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "Ingrese sus apellidos")
            {
                txtApellidos.Text = "";
                txtApellidos.ForeColor = Color.Black;
            }
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                txtApellidos.Text = "Ingrese sus apellidos";
                txtApellidos.ForeColor = Color.Gray;
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
    }
}
