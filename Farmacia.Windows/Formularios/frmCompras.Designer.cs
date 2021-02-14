namespace Farmacia.Windows.Formularios
{
    partial class frmCompras
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
            this.dgbDatos = new System.Windows.Forms.DataGridView();
            this.clmProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMedicamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBorrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.cbmProveedor = new System.Windows.Forms.ComboBox();
            this.cbmMedicamento = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.process1 = new System.Diagnostics.Process();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgbDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgbDatos
            // 
            this.dgbDatos.AllowUserToAddRows = false;
            this.dgbDatos.AllowUserToDeleteRows = false;
            this.dgbDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmProveedor,
            this.clmMedicamento,
            this.clmCantidad,
            this.clmTotal,
            this.clmBorrar});
            this.dgbDatos.Location = new System.Drawing.Point(12, 100);
            this.dgbDatos.Name = "dgbDatos";
            this.dgbDatos.ReadOnly = true;
            this.dgbDatos.RowHeadersVisible = false;
            this.dgbDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgbDatos.Size = new System.Drawing.Size(776, 292);
            this.dgbDatos.TabIndex = 0;
            this.dgbDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbDatos_CellClick);
            // 
            // clmProveedor
            // 
            this.clmProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmProveedor.HeaderText = "Proveedor";
            this.clmProveedor.Name = "clmProveedor";
            this.clmProveedor.ReadOnly = true;
            // 
            // clmMedicamento
            // 
            this.clmMedicamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmMedicamento.HeaderText = "Medicamento";
            this.clmMedicamento.Name = "clmMedicamento";
            this.clmMedicamento.ReadOnly = true;
            // 
            // clmCantidad
            // 
            this.clmCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCantidad.HeaderText = "Cantidad";
            this.clmCantidad.Name = "clmCantidad";
            this.clmCantidad.ReadOnly = true;
            // 
            // clmTotal
            // 
            this.clmTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmTotal.HeaderText = "Total";
            this.clmTotal.Name = "clmTotal";
            this.clmTotal.ReadOnly = true;
            // 
            // clmBorrar
            // 
            this.clmBorrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmBorrar.HeaderText = "Borrar";
            this.clmBorrar.Image = global::Farmacia.Windows.Properties.Resources.close_window_40px;
            this.clmBorrar.Name = "clmBorrar";
            this.clmBorrar.ReadOnly = true;
            this.clmBorrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmBorrar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cbmProveedor
            // 
            this.cbmProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmProveedor.FormattingEnabled = true;
            this.cbmProveedor.Location = new System.Drawing.Point(29, 52);
            this.cbmProveedor.Name = "cbmProveedor";
            this.cbmProveedor.Size = new System.Drawing.Size(169, 21);
            this.cbmProveedor.TabIndex = 1;
            this.cbmProveedor.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbmMedicamento
            // 
            this.cbmMedicamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmMedicamento.FormattingEnabled = true;
            this.cbmMedicamento.Location = new System.Drawing.Point(236, 52);
            this.cbmMedicamento.Name = "cbmMedicamento";
            this.cbmMedicamento.Size = new System.Drawing.Size(173, 21);
            this.cbmMedicamento.TabIndex = 2;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(495, 50);
            this.txtCantidad.MaxLength = 100;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(654, 50);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(683, 410);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 23);
            this.btnComprar.TabIndex = 5;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(571, 410);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Medicamento";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(294, 413);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(218, 20);
            this.txtTotal.TabIndex = 9;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "TOTAL:";
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cantidad";
            // 
            // frmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 463);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cbmMedicamento);
            this.Controls.Add(this.cbmProveedor);
            this.Controls.Add(this.dgbDatos);
            this.MaximumSize = new System.Drawing.Size(816, 502);
            this.MinimumSize = new System.Drawing.Size(816, 502);
            this.Name = "frmCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCompras";
            this.Load += new System.EventHandler(this.frmCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgbDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgbDatos;
        private System.Windows.Forms.ComboBox cbmProveedor;
        private System.Windows.Forms.ComboBox cbmMedicamento;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMedicamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.DataGridViewImageColumn clmBorrar;
        private System.Windows.Forms.Label label4;
    }
}