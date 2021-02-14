namespace Farmacia.Windows.Formularios
{
    partial class frmVentas
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cbmMedicamento = new System.Windows.Forms.ComboBox();
            this.cbmCliente = new System.Windows.Forms.ComboBox();
            this.dgbDatos = new System.Windows.Forms.DataGridView();
            this.clmCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMedicamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBorrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgbDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(523, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "TOTAL:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(461, 492);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(242, 20);
            this.txtTotal.TabIndex = 21;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Medicamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Cliente";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(749, 463);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(749, 495);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(75, 23);
            this.btnVender.TabIndex = 17;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(684, 42);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(121, 50);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(526, 58);
            this.txtCantidad.MaxLength = 100;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 15;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbmMedicamento
            // 
            this.cbmMedicamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmMedicamento.FormattingEnabled = true;
            this.cbmMedicamento.Location = new System.Drawing.Point(282, 58);
            this.cbmMedicamento.Name = "cbmMedicamento";
            this.cbmMedicamento.Size = new System.Drawing.Size(173, 21);
            this.cbmMedicamento.TabIndex = 14;
            // 
            // cbmCliente
            // 
            this.cbmCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmCliente.FormattingEnabled = true;
            this.cbmCliente.Location = new System.Drawing.Point(33, 58);
            this.cbmCliente.Name = "cbmCliente";
            this.cbmCliente.Size = new System.Drawing.Size(169, 21);
            this.cbmCliente.TabIndex = 13;
            // 
            // dgbDatos
            // 
            this.dgbDatos.AllowUserToAddRows = false;
            this.dgbDatos.AllowUserToDeleteRows = false;
            this.dgbDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCliente,
            this.clmMedicamento,
            this.clmCantidad,
            this.clmTotal,
            this.clmBorrar});
            this.dgbDatos.Location = new System.Drawing.Point(12, 125);
            this.dgbDatos.Name = "dgbDatos";
            this.dgbDatos.ReadOnly = true;
            this.dgbDatos.RowHeadersVisible = false;
            this.dgbDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgbDatos.Size = new System.Drawing.Size(845, 312);
            this.dgbDatos.TabIndex = 12;
            this.dgbDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbDatos_CellClick);
            // 
            // clmCliente
            // 
            this.clmCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCliente.HeaderText = "Cliente";
            this.clmCliente.Name = "clmCliente";
            this.clmCliente.ReadOnly = true;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 495);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Descuento";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Enabled = false;
            this.txtDescuento.Location = new System.Drawing.Point(144, 492);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(218, 20);
            this.txtDescuento.TabIndex = 24;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 469);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Subtotal";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Enabled = false;
            this.txtSubtotal.Location = new System.Drawing.Point(144, 466);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(218, 20);
            this.txtSubtotal.TabIndex = 26;
            this.txtSubtotal.Text = "0";
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 535);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cbmMedicamento);
            this.Controls.Add(this.cbmCliente);
            this.Controls.Add(this.dgbDatos);
            this.MaximumSize = new System.Drawing.Size(885, 574);
            this.MinimumSize = new System.Drawing.Size(885, 574);
            this.Name = "frmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVentas";
            this.Load += new System.EventHandler(this.frmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgbDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cbmMedicamento;
        private System.Windows.Forms.ComboBox cbmCliente;
        private System.Windows.Forms.DataGridView dgbDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMedicamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.DataGridViewImageColumn clmBorrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}