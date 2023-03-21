using Entidades2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista2
{
    public partial class UsuariosForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
        }
        string tipoOperacion;
       
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            CodigotextBox.Focus();
            HabilitarControles();
            tipoOperacion = "Nuevo";

        }

        private void HabilitarControles()
        {
            CodigotextBox.Enabled = true;
            NombretextBox.Enabled = true;
            ContrasenatextBox.Enabled = true;
            CorreotextBox.Enabled = true;
            RolcomboBox.Enabled = true;
            EstaActivocheckBox.Enabled = true;
            AdjuntarFotobutton.Enabled = true;
            Guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;
            Modificarbutton.Enabled = false;
        }
        private void DeshabilitarControles()
        {
            CodigotextBox.Enabled = false;
            NombretextBox.Enabled = false;
            ContrasenatextBox.Enabled = false;
            CorreotextBox.Enabled = false;
            RolcomboBox.Enabled = false;
            EstaActivocheckBox.Enabled = false;
            AdjuntarFotobutton.Enabled = false;
            Guardarbutton.Enabled = false;
            Cancelarbutton.Enabled = false;
            Modificarbutton.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigotextBox.Clear();
            NombretextBox.Clear();
            ContrasenatextBox.Clear();
            CorreotextBox.Clear();
            RolcomboBox.Text = String.Empty;
            EstaActivocheckBox.Checked = false;
            FotopictureBox.Image = null;
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (tipoOperacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(CodigotextBox.Text))
                {
                    errorProvider1.SetError(CodigotextBox, "Ingrese un código");
                    CodigotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(NombretextBox.Text))
                {
                    errorProvider1.SetError(NombretextBox, "Ingrese un Nombre");
                    NombretextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(ContrasenatextBox.Text))
                {
                    errorProvider1.SetError(ContrasenatextBox, "Ingrese la contraseña");
                    ContrasenatextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(RolcomboBox.Text))
                {
                    errorProvider1.SetError(RolcomboBox, "Seleccione un rol");
                    RolcomboBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                Usuarios user = new Usuarios();
                user.CodigoUsuario = CodigotextBox.Text;
                user.Nombre = NombretextBox.Text;
                user.Contrasena = ContrasenatextBox.Text;
                user.Rol = RolcomboBox.Text;
                user.Correo = CorreotextBox.Text;
                user.EstaActivo = EstaActivocheckBox.Checked;

                if (FotopictureBox.Image != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    FotopictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    user.Foto = ms.GetBuffer();
                }

                //insertar en la base
            }
            else if (tipoOperacion == "Modificar")
            {

            }

        }

        private void Modificarbutton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Modificar";
        }

        private void AdjuntarFotobutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                FotopictureBox.Image = Image.FromFile(dialog.FileName);
            }
        }
    }
}
