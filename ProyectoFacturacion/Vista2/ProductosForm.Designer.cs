namespace Vista2
{
    partial class ProductosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.CodigotextBox = new System.Windows.Forms.TextBox();
            this.DescripciontextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ExistenciatextBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.PreciotextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FotopictureBox = new System.Windows.Forms.PictureBox();
            this.Cancelarbutton = new System.Windows.Forms.Button();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.Modificarbutton = new System.Windows.Forms.Button();
            this.Nuevobutton = new System.Windows.Forms.Button();
            this.AdjuntarFotobutton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FotopictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo :";
            // 
            // CodigotextBox
            // 
            this.CodigotextBox.Enabled = false;
            this.CodigotextBox.Location = new System.Drawing.Point(156, 39);
            this.CodigotextBox.Name = "CodigotextBox";
            this.CodigotextBox.Size = new System.Drawing.Size(124, 27);
            this.CodigotextBox.TabIndex = 1;
            // 
            // DescripciontextBox
            // 
            this.DescripciontextBox.Enabled = false;
            this.DescripciontextBox.Location = new System.Drawing.Point(156, 88);
            this.DescripciontextBox.Name = "DescripciontextBox";
            this.DescripciontextBox.Size = new System.Drawing.Size(186, 27);
            this.DescripciontextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion :";
            // 
            // ExistenciatextBox
            // 
            this.ExistenciatextBox.Enabled = false;
            this.ExistenciatextBox.Location = new System.Drawing.Point(156, 136);
            this.ExistenciatextBox.Name = "ExistenciatextBox";
            this.ExistenciatextBox.Size = new System.Drawing.Size(186, 27);
            this.ExistenciatextBox.TabIndex = 5;
            this.ExistenciatextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExistenciatextBox_KeyPress);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(56, 139);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(96, 20);
            this.label.TabIndex = 4;
            this.label.Text = "Existencia :";
            // 
            // PreciotextBox
            // 
            this.PreciotextBox.Enabled = false;
            this.PreciotextBox.Location = new System.Drawing.Point(156, 181);
            this.PreciotextBox.Name = "PreciotextBox";
            this.PreciotextBox.Size = new System.Drawing.Size(124, 27);
            this.PreciotextBox.TabIndex = 7;
            this.PreciotextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PreciotextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio :";
            // 
            // FotopictureBox
            // 
            this.FotopictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FotopictureBox.Enabled = false;
            this.FotopictureBox.Location = new System.Drawing.Point(370, 16);
            this.FotopictureBox.Name = "FotopictureBox";
            this.FotopictureBox.Size = new System.Drawing.Size(159, 133);
            this.FotopictureBox.TabIndex = 9;
            this.FotopictureBox.TabStop = false;
            // 
            // Cancelarbutton
            // 
            this.Cancelarbutton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Cancelarbutton.Enabled = false;
            this.Cancelarbutton.Location = new System.Drawing.Point(451, 276);
            this.Cancelarbutton.Name = "Cancelarbutton";
            this.Cancelarbutton.Size = new System.Drawing.Size(107, 42);
            this.Cancelarbutton.TabIndex = 25;
            this.Cancelarbutton.Text = "Cancelar";
            this.Cancelarbutton.UseVisualStyleBackColor = false;
            this.Cancelarbutton.Click += new System.EventHandler(this.Cancelarbutton_Click);
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Eliminarbutton.Enabled = false;
            this.Eliminarbutton.Location = new System.Drawing.Point(350, 278);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(93, 40);
            this.Eliminarbutton.TabIndex = 24;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.UseVisualStyleBackColor = false;
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Guardarbutton.Enabled = false;
            this.Guardarbutton.Location = new System.Drawing.Point(241, 277);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(101, 40);
            this.Guardarbutton.TabIndex = 23;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.UseVisualStyleBackColor = false;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // Modificarbutton
            // 
            this.Modificarbutton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Modificarbutton.Enabled = false;
            this.Modificarbutton.Location = new System.Drawing.Point(121, 276);
            this.Modificarbutton.Name = "Modificarbutton";
            this.Modificarbutton.Size = new System.Drawing.Size(112, 42);
            this.Modificarbutton.TabIndex = 22;
            this.Modificarbutton.Text = "Modificar";
            this.Modificarbutton.UseVisualStyleBackColor = false;
            this.Modificarbutton.Click += new System.EventHandler(this.Modificarbutton_Click);
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Nuevobutton.Location = new System.Drawing.Point(20, 273);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(93, 44);
            this.Nuevobutton.TabIndex = 21;
            this.Nuevobutton.Text = "Nuevo";
            this.Nuevobutton.UseVisualStyleBackColor = false;
            this.Nuevobutton.Click += new System.EventHandler(this.Nuevobutton_Click);
            // 
            // AdjuntarFotobutton
            // 
            this.AdjuntarFotobutton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AdjuntarFotobutton.Image = global::Vista2.Properties.Resources.lupa;
            this.AdjuntarFotobutton.Location = new System.Drawing.Point(538, 109);
            this.AdjuntarFotobutton.Name = "AdjuntarFotobutton";
            this.AdjuntarFotobutton.Size = new System.Drawing.Size(47, 40);
            this.AdjuntarFotobutton.TabIndex = 26;
            this.AdjuntarFotobutton.UseCompatibleTextRendering = true;
            this.AdjuntarFotobutton.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(637, 472);
            this.Controls.Add(this.AdjuntarFotobutton);
            this.Controls.Add(this.Cancelarbutton);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.Modificarbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.FotopictureBox);
            this.Controls.Add(this.PreciotextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExistenciatextBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.DescripciontextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CodigotextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProductosForm";
            this.Text = "ProductosForm";
            ((System.ComponentModel.ISupportInitialize)(this.FotopictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CodigotextBox;
        private System.Windows.Forms.TextBox DescripciontextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ExistenciatextBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox PreciotextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox FotopictureBox;
        private System.Windows.Forms.Button Cancelarbutton;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button Modificarbutton;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.Button AdjuntarFotobutton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}