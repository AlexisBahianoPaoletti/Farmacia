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
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formasFarmaceuticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.formasFarmaceuticasToolStripMenuItem});
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
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // formasFarmaceuticasToolStripMenuItem
            // 
            this.formasFarmaceuticasToolStripMenuItem.Name = "formasFarmaceuticasToolStripMenuItem";
            this.formasFarmaceuticasToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.formasFarmaceuticasToolStripMenuItem.Text = "Formas farmaceuticas";
            this.formasFarmaceuticasToolStripMenuItem.Click += new System.EventHandler(this.formasFarmaceuticasToolStripMenuItem_Click);
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
    }
}

