namespace Farmacia.Windows
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drogasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeMedicamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formasFarmaceuticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laboratoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeDocumentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provinciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeIngredientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drogasToolStripMenuItem,
            this.tiposDeMedicamentosToolStripMenuItem,
            this.formasFarmaceuticasToolStripMenuItem,
            this.laboratoriosToolStripMenuItem,
            this.tiposDeDocumentosToolStripMenuItem,
            this.provinciasToolStripMenuItem,
            this.tiposDeIngredientesToolStripMenuItem,
            this.obrasToolStripMenuItem,
            this.localidadesToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.medicamentosToolStripMenuItem,
            this.lotesToolStripMenuItem});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // drogasToolStripMenuItem
            // 
            this.drogasToolStripMenuItem.Name = "drogasToolStripMenuItem";
            this.drogasToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.drogasToolStripMenuItem.Text = "Drogas";
            this.drogasToolStripMenuItem.Click += new System.EventHandler(this.drogasToolStripMenuItem_Click);
            // 
            // tiposDeMedicamentosToolStripMenuItem
            // 
            this.tiposDeMedicamentosToolStripMenuItem.Name = "tiposDeMedicamentosToolStripMenuItem";
            this.tiposDeMedicamentosToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.tiposDeMedicamentosToolStripMenuItem.Text = "Tipos de medicamentos";
            this.tiposDeMedicamentosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeMedicamentosToolStripMenuItem_Click);
            // 
            // formasFarmaceuticasToolStripMenuItem
            // 
            this.formasFarmaceuticasToolStripMenuItem.Name = "formasFarmaceuticasToolStripMenuItem";
            this.formasFarmaceuticasToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.formasFarmaceuticasToolStripMenuItem.Text = "Formas farmaceuticas";
            this.formasFarmaceuticasToolStripMenuItem.Click += new System.EventHandler(this.formasFarmaceuticasToolStripMenuItem_Click);
            // 
            // laboratoriosToolStripMenuItem
            // 
            this.laboratoriosToolStripMenuItem.Name = "laboratoriosToolStripMenuItem";
            this.laboratoriosToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.laboratoriosToolStripMenuItem.Text = "Laboratorios";
            this.laboratoriosToolStripMenuItem.Click += new System.EventHandler(this.laboratoriosToolStripMenuItem_Click);
            // 
            // tiposDeDocumentosToolStripMenuItem
            // 
            this.tiposDeDocumentosToolStripMenuItem.Name = "tiposDeDocumentosToolStripMenuItem";
            this.tiposDeDocumentosToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.tiposDeDocumentosToolStripMenuItem.Text = "Tipos de documentos";
            this.tiposDeDocumentosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeDocumentosToolStripMenuItem_Click);
            // 
            // provinciasToolStripMenuItem
            // 
            this.provinciasToolStripMenuItem.Name = "provinciasToolStripMenuItem";
            this.provinciasToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.provinciasToolStripMenuItem.Text = "Provincias";
            this.provinciasToolStripMenuItem.Click += new System.EventHandler(this.provinciasToolStripMenuItem_Click);
            // 
            // tiposDeIngredientesToolStripMenuItem
            // 
            this.tiposDeIngredientesToolStripMenuItem.Name = "tiposDeIngredientesToolStripMenuItem";
            this.tiposDeIngredientesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.tiposDeIngredientesToolStripMenuItem.Text = "Tipos de ingredientes";
            this.tiposDeIngredientesToolStripMenuItem.Click += new System.EventHandler(this.tiposDeIngredientesToolStripMenuItem_Click);
            // 
            // obrasToolStripMenuItem
            // 
            this.obrasToolStripMenuItem.Name = "obrasToolStripMenuItem";
            this.obrasToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.obrasToolStripMenuItem.Text = "Obras sociales";
            this.obrasToolStripMenuItem.Click += new System.EventHandler(this.obrasToolStripMenuItem_Click);
            // 
            // localidadesToolStripMenuItem
            // 
            this.localidadesToolStripMenuItem.Name = "localidadesToolStripMenuItem";
            this.localidadesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.localidadesToolStripMenuItem.Text = "Localidades";
            this.localidadesToolStripMenuItem.Click += new System.EventHandler(this.localidadesToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // medicamentosToolStripMenuItem
            // 
            this.medicamentosToolStripMenuItem.Name = "medicamentosToolStripMenuItem";
            this.medicamentosToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.medicamentosToolStripMenuItem.Text = "Medicamentos";
            this.medicamentosToolStripMenuItem.Click += new System.EventHandler(this.medicamentosToolStripMenuItem_Click);
            // 
            // lotesToolStripMenuItem
            // 
            this.lotesToolStripMenuItem.Name = "lotesToolStripMenuItem";
            this.lotesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.lotesToolStripMenuItem.Text = "Lotes";
            this.lotesToolStripMenuItem.Click += new System.EventHandler(this.lotesToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drogasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeMedicamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formasFarmaceuticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laboratoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeDocumentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provinciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeIngredientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lotesToolStripMenuItem;
    }
}

