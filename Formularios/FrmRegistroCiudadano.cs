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
    }
}
