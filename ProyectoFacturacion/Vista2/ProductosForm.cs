using Datos2;
using Entidades2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        ProductosDB productoDB = new ProductosDB();
        Productos productos;

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
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

            if (ProductosdataGridView.SelectedRows.Count > 0)
            {
                CodigotextBox.Text = ProductosdataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                DescripciontextBox.Text = ProductosdataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                ExistenciatextBox.Text = ProductosdataGridView.CurrentRow.Cells["Existencia"].Value.ToString();
                PreciotextBox.Text = ProductosdataGridView.CurrentRow.Cells["Precio"].Value.ToString();

                byte[] img = productoDB.DevolverFoto(ProductosdataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                if (img.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(img);
                    FotopictureBox.Image = System.Drawing.Bitmap.FromStream(ms);
                }
                HabilitarControles();
                CodigotextBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            productos = new Productos();
            productos.Codigo = CodigotextBox.Text;
            productos.Descripcion = DescripciontextBox.Text;
            productos.Precio = Convert.ToDecimal(PreciotextBox.Text);
            productos.Existencia = Convert.ToInt32(ExistenciatextBox.Text);
          
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

                bool inserto = productoDB.Insertar(productos);
                if (inserto)
                {
                    DeshabilitarControles();
                    LimpiarControles();
                    TraerProductos();
                    MessageBox.Show("Registro guardado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puro guardar el registro", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (operacion == "Modificar")
            {

                bool modifico = productoDB.Editar(productos);
                if (modifico)
                {
                    CodigotextBox.ReadOnly = false;
                    DeshabilitarControles();
                    LimpiarControles();
                    TraerProductos();
                    MessageBox.Show("Registro actualizado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puro actualizar el registro", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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

        private void AdjuntarFotobutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                FotopictureBox.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (ProductosdataGridView.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro de eliminar el registro", "Advertencia", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    bool elimino = productoDB.Eliminar(ProductosdataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                    if (elimino)
                    {
                        LimpiarControles();
                        DeshabilitarControles();
                        TraerProductos();
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    { MessageBox.Show("No se pudo eliminar el registro"); }
                }
            }
        }

        private void TraerProductos()
        {
            throw new NotImplementedException();
        }

        private void ProductosForm_Load(object sender, EventArgs e)
        {

            TraerProductos();
        }
    }
}
