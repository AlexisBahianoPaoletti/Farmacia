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
    }
}
