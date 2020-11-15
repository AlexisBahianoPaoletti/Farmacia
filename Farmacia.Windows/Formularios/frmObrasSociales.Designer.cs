namespace Farmacia.Windows.Formularios
{
    partial class frmObrasSociales
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.clmObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPorcentajeDeDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslAgregar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tslBorrar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslEditar = new System.Windows.Forms.ToolStripLabel();
            this.tslCerrar = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmObraSocial,
            this.clmPorcentajeDeDescuento});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 25);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(800, 425);
            this.dgvDatos.TabIndex = 3;
            // 
            // clmObraSocial
            // 
            this.clmObraSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmObraSocial.HeaderText = "Obra social";
            this.clmObraSocial.Name = "clmObraSocial";
            this.clmObraSocial.ReadOnly = true;
            // 
            // clmPorcentajeDeDescuento
            // 
            this.clmPorcentajeDeDescuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmPorcentajeDeDescuento.HeaderText = "Porcentaje de descuento";
            this.clmPorcentajeDeDescuento.Name = "clmPorcentajeDeDescuento";
            this.clmPorcentajeDeDescuento.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslAgregar,
            this.toolStripSeparator2,
            this.tslBorrar,
            this.toolStripSeparator1,
            this.tslEditar,
            this.tslCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslAgregar
            // 
            this.tslAgregar.Name = "tslAgregar";
            this.tslAgregar.Size = new System.Drawing.Size(49, 22);
            this.tslAgregar.Text = "Agregar";
            this.tslAgregar.Click += new System.EventHandler(this.tslAgregar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tslBorrar
            // 
            this.tslBorrar.Name = "tslBorrar";
            this.tslBorrar.Size = new System.Drawing.Size(39, 22);
            this.tslBorrar.Text = "Borrar";
            this.tslBorrar.Click += new System.EventHandler(this.tslBorrar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslEditar
            // 
            this.tslEditar.Name = "tslEditar";
            this.tslEditar.Size = new System.Drawing.Size(37, 22);
            this.tslEditar.Text = "Editar";
            this.tslEditar.Click += new System.EventHandler(this.tslEditar_Click);
            // 
            // tslCerrar
            // 
            this.tslCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslCerrar.Name = "tslCerrar";
            this.tslCerrar.Size = new System.Drawing.Size(39, 22);
            this.tslCerrar.Text = "Cerrar";
            this.tslCerrar.Click += new System.EventHandler(this.tslCerrar_Click);
            // 
            // frmObrasSociales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmObrasSociales";
            this.Text = "Obras sociales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmObrasSociales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslAgregar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tslBorrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslEditar;
        private System.Windows.Forms.ToolStripLabel tslCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmObraSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPorcentajeDeDescuento;
    }
}