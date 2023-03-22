using Entidades2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista2
{
    public partial class ProductosForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public ProductosForm()
        {
            InitializeComponent();
        }
        string operacion;

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            HabilitarControles();

        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();

        }

        private void HabilitarControles()
        {
            CodigotextBox.Enabled = true;
            DescripciontextBox.Enabled = true;
            ExistenciatextBox.Enabled = true;
            PreciotextBox.Enabled = true;
            AdjuntarFotobutton.Enabled = true;
            Guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;
            Nuevobutton.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            CodigotextBox.Enabled = false;
            DescripciontextBox.Enabled = false;
            ExistenciatextBox.Enabled = false;
            PreciotextBox.Enabled = false;
            AdjuntarFotobutton.Enabled = false;
            Guardarbutton.Enabled = false;
            Cancelarbutton.Enabled = false;
            Nuevobutton.Enabled = true;
        }
        private void LimpiarControles()
        {
            CodigotextBox.Clear();
            DescripciontextBox.Clear();
            ExistenciatextBox.Clear();
            PreciotextBox.Clear();
            FotopictureBox.Image = null;
            //producto = null;
        }

        private void Modificarbutton_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (operacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(CodigotextBox.Text))
                {
                    errorProvider1.SetError(CodigotextBox, "Ingrese un código");
                    CodigotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(DescripciontextBox.Text))
                {
                    errorProvider1.SetError(DescripciontextBox, "Ingrese una descripcion");
                    DescripciontextBox.Focus();
                    return;
                }
                errorProvider1.Clear();


                if (string.IsNullOrEmpty(ExistenciatextBox.Text))
                {
                    errorProvider1.SetError(ExistenciatextBox, "Ingrese la Existencia");
                    ExistenciatextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(PreciotextBox.Text))
                {
                    errorProvider1.SetError(PreciotextBox, "Ingrese el precio");
                    PreciotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();


            }
            else if (operacion == "Modificar")
            {
                
            }
        }

        private void ExistenciatextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {

            }
            else
            {
                e.Handled = true;
            }

        }

        private void PreciotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
