using Farmacia.Entidades.Entidades;
using Farmacia.Servicio.Servicios;
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
    public partial class frmLaboratoriosAE : Form
    {
        public frmLaboratoriosAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmLaboratoriosAE(frmLaboratorios frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (laboratorio != null)
            {
                txtLaboratorio.Text = laboratorio.NombreLaboratorio;
                _esEdicion = true;
            }
        }

        private Laboratorio laboratorio;
        public void SetLaboratorio(Laboratorio laboratorio)
        {
            this.laboratorio = laboratorio;
        }

        public Laboratorio GetLaboratorio()
        {
            return laboratorio;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtLaboratorio.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtLaboratorio.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtLaboratorio, "Debe ingresar una laboratorio");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioLaboratorio _servicio = new ServicioLaboratorio();
        private frmLaboratorios frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (laboratorio == null)
                {
                    laboratorio = new Laboratorio();
                }

                laboratorio.NombreLaboratorio = txtLaboratorio.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(laboratorio);
                            if (frm != null)
                            {
                                frm.AgregarFila(laboratorio);

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
            txtLaboratorio.Clear();
            txtLaboratorio.Focus();
            laboratorio = null;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(laboratorio))
            {
                valido = false;
                errorProvider1.SetError(txtLaboratorio, "Laboratorio repetida");
            }

            return valido;
        }


    }
}
