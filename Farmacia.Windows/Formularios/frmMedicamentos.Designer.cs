namespace Farmacia.Windows.Formularios
{
    partial class frmMedicamentos
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslAgregar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tslBorrar = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslEditar = new System.Windows.Forms.ToolStripLabel();
            this.tslCerrar = new System.Windows.Forms.ToolStripLabel();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDroga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTipoDeMedicamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFormaFarmaceutica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLaboratorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnidadesEnStok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNivelDeReposicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCantidadesPorUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSuspendido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.clmNombre,
            this.clmDroga,
            this.clmTipoDeMedicamento,
            this.clmFormaFarmaceutica,
            this.clmLaboratorio,
            this.clmPrecioVenta,
            this.clmUnidadesEnStok,
            this.clmNivelDeReposicion,
            this.clmCantidadesPorUnidad,
            this.clmSuspendido});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 25);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(800, 425);
            this.dgvDatos.TabIndex = 5;
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
            this.toolStrip1.TabIndex = 4;
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
            // clmNombre
            // 
            this.clmNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.Name = "clmNombre";
            this.clmNombre.ReadOnly = true;
            // 
            // clmDroga
            // 
            this.clmDroga.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmDroga.HeaderText = "Droga";
            this.clmDroga.Name = "clmDroga";
            this.clmDroga.ReadOnly = true;
            // 
            // clmTipoDeMedicamento
            // 
            this.clmTipoDeMedicamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmTipoDeMedicamento.HeaderText = "Tipo de medicamento";
            this.clmTipoDeMedicamento.Name = "clmTipoDeMedicamento";
            this.clmTipoDeMedicamento.ReadOnly = true;
            // 
            // clmFormaFarmaceutica
            // 
            this.clmFormaFarmaceutica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmFormaFarmaceutica.HeaderText = "Forma farmaceutica";
            this.clmFormaFarmaceutica.Name = "clmFormaFarmaceutica";
            this.clmFormaFarmaceutica.ReadOnly = true;
            // 
            // clmLaboratorio
            // 
            this.clmLaboratorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmLaboratorio.HeaderText = "Laboratorio";
            this.clmLaboratorio.Name = "clmLaboratorio";
            this.clmLaboratorio.ReadOnly = true;
            // 
            // clmPrecioVenta
            // 
            this.clmPrecioVenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmPrecioVenta.HeaderText = "Precio de venta";
            this.clmPrecioVenta.Name = "clmPrecioVenta";
            this.clmPrecioVenta.ReadOnly = true;
            // 
            // clmUnidadesEnStok
            // 
            this.clmUnidadesEnStok.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmUnidadesEnStok.HeaderText = "Unidades en stok";
            this.clmUnidadesEnStok.Name = "clmUnidadesEnStok";
            this.clmUnidadesEnStok.ReadOnly = true;
            // 
            // clmNivelDeReposicion
            // 
            this.clmNivelDeReposicion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmNivelDeReposicion.HeaderText = "Nivel de reposicion";
            this.clmNivelDeReposicion.Name = "clmNivelDeReposicion";
            this.clmNivelDeReposicion.ReadOnly = true;
            // 
            // clmCantidadesPorUnidad
            // 
            this.clmCantidadesPorUnidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCantidadesPorUnidad.HeaderText = "Cantidades por unidades";
            this.clmCantidadesPorUnidad.Name = "clmCantidadesPorUnidad";
            this.clmCantidadesPorUnidad.ReadOnly = true;
            // 
            // clmSuspendido
            // 
            this.clmSuspendido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmSuspendido.HeaderText = "Suspendido";
            this.clmSuspendido.Name = "clmSuspendido";
            this.clmSuspendido.ReadOnly = true;
            // 
            // frmMedicamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMedicamentos";
            this.Text = "Medicamentos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMedicamentos_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDroga;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTipoDeMedicamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFormaFarmaceutica;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLaboratorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnidadesEnStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNivelDeReposicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCantidadesPorUnidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSuspendido;
    }
}