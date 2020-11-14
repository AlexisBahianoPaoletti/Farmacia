using Farmacia.Entidades;
using Farmacia.Servicio;
using Farmacia.Windows.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia.Windows.FormulariosAE
{
    public partial class frmDrogasAE : Form
    {
        public frmDrogasAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmDrogasAE(frmDrogas frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (droga != null)
            {
                txtDroga.Text = droga.NombreDroga;
                _esEdicion = true;
            }
        }

        private Droga droga;
        public void SetDroga(Droga droga)
        {
            this.droga = droga;
        }

        public Droga GetDroga()
        {
            return droga;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtDroga.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtDroga.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtDroga, "Debe ingresar una droga");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioDroga _servicio = new ServicioDroga();
        private frmDrogas frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (droga == null)
                {
                    droga = new Droga();
                }

                droga.NombreDroga = txtDroga.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(droga);
                            if (frm != null)
                            {
                                frm.AgregarFila(droga);

                            }
                            MessageBox.Show("Registro Guardado", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult dr = MessageBox.Show("¿Desea dar de alta otro registro?", "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.Cancel;
                            }
                            else
                            {
                                InicializarControles();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }

                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            }

        }

        private void InicializarControles()
        {
            txtDroga.Clear();
            txtDroga.Focus();
            droga = null;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(droga))
            {
                valido = false;
                errorProvider1.SetError(txtDroga, "Droga repetida");
            }

            return valido;
        }


    }
}
