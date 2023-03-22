using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista2
{
    public partial class ClientesForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public ClientesForm()
        {
            InitializeComponent();
        }
        string operar;
        private void ClientesForm_Load(object sender, EventArgs e)
        {

        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            NombretextBox.Focus();
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            NombretextBox.Enabled = true;
            IdentidadtextBox.Enabled = true;
            TelefonotextBox.Enabled = true;
            CorreotextBox.Enabled = true;
            DirreciontextBox.Enabled = true;
            EstaActivocheckBox.Enabled = true;
            Guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;
            Eliminarbutton.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            NombretextBox.Enabled = false;
            IdentidadtextBox.Enabled = false;
            TelefonotextBox.Enabled = false;
            CorreotextBox.Enabled = false;
            DirreciontextBox.Enabled = false;
            EstaActivocheckBox.Enabled = false;
            Guardarbutton.Enabled = false;
            Eliminarbutton.Enabled = true;
        }

        private void LimpiarControles()
        {
            NombretextBox.Clear();
            IdentidadtextBox.Clear();
            TelefonotextBox.Clear();
            CorreotextBox.Clear();
            DirreciontextBox.Clear();
            EstaActivocheckBox.Checked = false;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (operar == "Nuevo")
            {
                if (string.IsNullOrEmpty(NombretextBox.Text))
                {
                    errorProvider1.SetError(NombretextBox, "Ingrese el nombre");
                    NombretextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(IdentidadtextBox.Text))
                {
                    errorProvider1.SetError(IdentidadtextBox, "Ingrese su numero de identidad");
                    IdentidadtextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(TelefonotextBox.Text))
                {
                    errorProvider1.SetError(TelefonotextBox, "Ingrese su telefono");
                    TelefonotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(CorreotextBox.Text))
                {
                    errorProvider1.SetError(CorreotextBox, "Ingrese su correo");
                    CorreotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(DirreciontextBox.Text))
                {
                    errorProvider1.SetError(DirreciontextBox, "Ingrese su correo");
                    DirreciontextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
            }else
            {

            }

        }
    }
}
