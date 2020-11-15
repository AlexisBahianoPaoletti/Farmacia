using Farmacia.Windows.Formularios;
using Farmacia.Windows.FormulariosAE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia.Windows
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void drogasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrogas frm = new frmDrogas();
            frm.ShowDialog(this);
        }

        private void tiposDeMedicamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposDeMedicamentos frm = new frmTiposDeMedicamentos();
            frm.ShowDialog(this);
        }

        private void formasFarmaceuticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormaFarmaceuticas frm = new frmFormaFarmaceuticas();
            frm.ShowDialog(this);
        }

        private void laboratoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLaboratorios frm = new frmLaboratorios();
            frm.ShowDialog(this);
        }

        private void tiposDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposDeDocumentos frm = new frmTiposDeDocumentos();
            frm.ShowDialog(this);
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProvincias frm = new frmProvincias();
            frm.ShowDialog(this);
        }

        private void tiposDeIngredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposDeIngredientes frm = new frmTiposDeIngredientes();
            frm.ShowDialog(this);
        }

        private void obrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmObrasSociales frm = new frmObrasSociales();
            frm.ShowDialog(this);
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalidades frm = new frmLocalidades();
            frm.ShowDialog(this);
        }
    }
}
