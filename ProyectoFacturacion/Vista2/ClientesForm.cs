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
    public partial class ClientesForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public ClientesForm()
        {
            InitializeComponent();
        }
        string operar;
        Clientes clientes;
        ClientesDB clientesDB = new ClientesDB();
        DataTable dt = new DataTable();
        private void ClientesForm_Load(object sender, EventArgs e)
        {
            TraerClientes();
        }
        private void TraerUsuarios()
        {
            dt = clientesDB.DevolverClientes();

            ClientesdataGridView.DataSource = dt;

        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            operar = "Nuevo";
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
        private void TraerClientes()
        {
            ClientesdataGridView.DataSource = clientesDB.DevolverClientes();
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
                    errorProvider1.SetError(DirreciontextBox, "Ingrese la direccion");
                    DirreciontextBox.Focus();
                    return;
                }
                errorProvider1.Clear();


                clientes = new Clientes();
                clientes.Nombre = NombretextBox.Text;
                clientes.Identidad = IdentidadtextBox.Text;
                clientes.Telefono = TelefonotextBox.Text;
                clientes.Correo = CorreotextBox.Text;
                clientes.Direccion = DirreciontextBox.Text;
                clientes.EstaActivo = EstaActivocheckBox.Checked;

                //base de datos
                bool inserto = clientesDB.Insertar(clientes);

                if (inserto)
                {
                    DeshabilitarControles();
                    LimpiarControles();
                    TraerClientes();
                    MessageBox.Show("Registro guardado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (operar == "Modificar")
            {
                bool modifico = clientesDB.Editar(clientes);
                if (modifico)
                {
                    NombretextBox.ReadOnly = false;
                    DeshabilitarControles();
                    LimpiarControles();
                    TraerClientes();
                    MessageBox.Show("Registro actualizado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puro actualizar el registro", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (ClientesdataGridView.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro de eliminar el registro", "Advertencia", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    bool elimino = clientesDB.Eliminar(ClientesdataGridView.CurrentRow.Cells["Id"].Value.ToString());

                    if (elimino)
                    {
                        LimpiarControles();
                        DeshabilitarControles();
                        TraerClientes();
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    { MessageBox.Show("No se pudo eliminar el registro"); }
                }
            }
        }

        private void Modificarbutton_Click(object sender, EventArgs e)
        {
            operar = "Modificar";
            if (ClientesdataGridView.SelectedRows.Count > 0)
            {
                NombretextBox.Text = ClientesdataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                IdentidadtextBox.Text = ClientesdataGridView.CurrentRow.Cells["Identidad"].Value.ToString();
                TelefonotextBox.Text = ClientesdataGridView.CurrentRow.Cells["Telefono"].Value.ToString();
                CorreotextBox.Text = ClientesdataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                DirreciontextBox.Text = ClientesdataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
                EstaActivocheckBox.Checked = Convert.ToBoolean(ClientesdataGridView.CurrentRow.Cells["EstaActivo"].Value);

                HabilitarControles();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }
    }
    
    
}
