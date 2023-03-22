using Datos2;
using Entidades2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
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


        DataTable dt = new DataTable();
        UsuariosDB UsuariosDB = new UsuariosDB();
        Usuarios user = new Usuarios();

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

                bool inserto = UsuariosDB.Insertar(user);

                if (inserto)
                {
                    LimpiarControles();
                    DeshabilitarControles();
                    TraerUsuarios();
                    MessageBox.Show("Registro Guardado");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro");

                }

            }
            else if (tipoOperacion == "Modificar")
            {
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

                bool modifico = UsuariosDB.Editar(user);

                if (modifico)
                {
                    LimpiarControles();
                    DeshabilitarControles();
                    TraerUsuarios();
                    MessageBox.Show("Registro actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el registro");
                }

            }

        }

        private void Modificarbutton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Modificar";

            if (UsuariosdataGridView.SelectedRows.Count > 0)
            {
                CodigotextBox.Text = UsuariosdataGridView.CurrentRow.Cells["CodigoUsuario"].Value.ToString();
                NombretextBox.Text = UsuariosdataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                ContrasenatextBox.Text = UsuariosdataGridView.CurrentRow.Cells["Contrasena"].Value.ToString();
                CorreotextBox.Text = UsuariosdataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                RolcomboBox.Text = UsuariosdataGridView.CurrentRow.Cells["Rol"].Value.ToString();
                EstaActivocheckBox.Checked = Convert.ToBoolean(UsuariosdataGridView.CurrentRow.Cells["EstaActivo"].Value);

                byte[] miFoto = UsuariosDB.DevolverFoto(UsuariosdataGridView.CurrentRow.Cells["CodigoUsuario"].Value.ToString());

                if (miFoto.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(miFoto);
                    FotopictureBox.Image = System.Drawing.Bitmap.FromStream(ms);
                }

                HabilitarControles();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
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

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            TraerUsuarios();

        }

        private void TraerUsuarios()
        {
            dt = UsuariosDB.DevolverUsuarios();

            UsuariosdataGridView.DataSource = dt;

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosdataGridView.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro de eliminar el registro", "Advertencia", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    bool elimino = UsuariosDB.Eliminar(UsuariosdataGridView.CurrentRow.Cells["CodigoUsuario"].Value.ToString());

                    if (elimino)
                    {
                        LimpiarControles();
                        DeshabilitarControles();
                        TraerUsuarios();
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    { MessageBox.Show("No se pudo eliminar el registro"); }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }
    }
}
