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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void UsuariostoolStripButton_Click(object sender, EventArgs e)
        {
            UsuariosForm userForm = new UsuariosForm();
            userForm.MdiParent = this;
            userForm.Show();
        }

        private void InvetoolStripButton_Click(object sender, EventArgs e)
        {
            ProductosForm productosForm = new ProductosForm();
            productosForm.MdiParent = this;
            productosForm.Show();
        }

        private void ClientestoolStripButton_Click(object sender, EventArgs e)
        {

        }

         private void ClientestoolStripTabItem_Click(object sender, EventArgs e)
         {
             ProductosForm clientesForm = new ProductosForm();
             clientesForm.MdiParent = this;
             clientesForm.Show();

         }

        private void NuevaFacturatoolStripButton_Click(object sender, EventArgs e)
        {

        }
    }
}
