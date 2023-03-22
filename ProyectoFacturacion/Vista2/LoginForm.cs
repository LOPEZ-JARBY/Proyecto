using Datos2;
using Entidades2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (UsuariotextBox.Text == string.Empty)
            {
                errorProvider1.SetError(UsuariotextBox, "Ingrese un usuario");
                UsuariotextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(ContrasenatextBox.Text))
            {
                errorProvider1.SetError(ContrasenatextBox, "Ingrese Contraseña");
                ContrasenatextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            //validad en la base de datos

            Login login = new Login(UsuariotextBox.Text, ContrasenatextBox.Text);
            Usuarios usuario = new Usuarios();
            UsuariosDB usuarioDB = new UsuariosDB();

            usuario = usuarioDB.Autenticar(login);

            if (usuario != null)
            {
                if (usuario.EstaActivo)
                {
                    //Mostrar Menu

                    MenuForm menuFormulario = new MenuForm();
                    this.Hide();
                    menuFormulario.ShowDialog();

                }
                else
                {
                    MessageBox.Show("El usuario no esta activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
               

        }

        private void MostrarContrasenabutton_Click(object sender, EventArgs e)
        {
            if (ContrasenatextBox.PasswordChar == '*')
            {
                ContrasenatextBox.PasswordChar = '\0';
            }
            else
            {
                ContrasenatextBox.PasswordChar = '*';
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
