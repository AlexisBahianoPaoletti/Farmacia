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
    public partial class frmTiposDeMedicamentosAE : Form
    {
        public frmTiposDeMedicamentosAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmTiposDeMedicamentosAE(frmTiposDeMedicamentos frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoDeMedicamento != null)
            {
                txtTipoDeMedicamento.Text = tipoDeMedicamento.Descripcion;
                _esEdicion = true;
            }
        }

        private TipoDeMedicamento tipoDeMedicamento;
        public void SetTipoDeMedicamento(TipoDeMedicamento tipoDeMedicamento)
        {
            this.tipoDeMedicamento = tipoDeMedicamento;
        }

        public TipoDeMedicamento GetTipoDeMedicamento()
        {
            return tipoDeMedicamento;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtTipoDeMedicamento.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtTipoDeMedicamento.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeMedicamento, "Debe ingresar una tipoDeMedicamento");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioTipoDeMedicamento _servicio = new ServicioTipoDeMedicamento();
        private frmTiposDeMedicamentos frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoDeMedicamento == null)
                {
                    tipoDeMedicamento = new TipoDeMedicamento();
                }

                tipoDeMedicamento.Descripcion = txtTipoDeMedicamento.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(tipoDeMedicamento);
                            if (frm != null)
                            {
                                frm.AgregarFila(tipoDeMedicamento);

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
            txtTipoDeMedicamento.Clear();
            txtTipoDeMedicamento.Focus();
            tipoDeMedicamento = null;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(tipoDeMedicamento))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeMedicamento, "TipoDeMedicamento repetida");
            }

            return valido;
        }



    }
}
