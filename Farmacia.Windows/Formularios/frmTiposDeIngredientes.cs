using Farmacia.Entidades.Entidades;
using Farmacia.Servicio.Servicios;
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

namespace Farmacia.Windows.Formularios
{
    public partial class frmTiposDeIngredientes : Form
    {
        public frmTiposDeIngredientes()
        {
            InitializeComponent();
        }


        private List<TipoDeIngrediente> lista;
        private ServicioTipoDeIngrediente _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tipoDeIngrediente in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDeIngrediente);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeIngrediente tipoDeIngrediente)
        {
            r.Cells[clmTipoDeIngredientes.Index].Value = tipoDeIngrediente.TipoDeIngredientes;

            r.Tag = tipoDeIngrediente;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(TipoDeIngrediente tipoDeIngrediente)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, tipoDeIngrediente);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmTiposDeIngredientes_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioTipoDeIngrediente();
                lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tslAgregar_Click(object sender, EventArgs e)
        {
            frmTiposDeIngredientesAE frm = new frmTiposDeIngredientesAE(this);
            frm.Text = "Nuevo TipoDeIngrediente";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeIngrediente tipoDeIngrediente = frm.GetTipoDeIngrediente();
                    if (!_servicio.Existe(tipoDeIngrediente))
                    {
                        _servicio.Guardar(tipoDeIngrediente);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, tipoDeIngrediente);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Tipo de ingrediente repetido");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }

        private void tslBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                TipoDeIngrediente tipoDeIngrediente = (TipoDeIngrediente)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el tipo de ingrediente {tipoDeIngrediente.TipoDeIngredientes}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(tipoDeIngrediente))
                    {
                        try
                        {
                            _servicio.Borrar(tipoDeIngrediente.TipoDeIngredienteId);
                            dgvDatos.Rows.Remove(r);
                            MessageBox.Show("Registro borrado");
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);

                        }
                    }
                    else
                    {
                        MessageBox.Show("El registro esta relacionado, no se puede borrar");
                    }
                }
            }
        }


        private void tslEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                TipoDeIngrediente tipoDeIngrediente = (TipoDeIngrediente)r.Tag;
                tipoDeIngrediente = _servicio.GetTipoDeIngredientePorId(tipoDeIngrediente.TipoDeIngredienteId);
                frmTiposDeIngredientesAE frm = new frmTiposDeIngredientesAE();
                frm.Text = "Editar TipoDeIngrediente";
                frm.SetTipoDeIngrediente(tipoDeIngrediente);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tipoDeIngrediente = frm.GetTipoDeIngrediente();
                        if (!_servicio.Existe(tipoDeIngrediente))
                        {
                            _servicio.Guardar(tipoDeIngrediente);
                            SetearFila(r, tipoDeIngrediente);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Tipo de ingrediente Repetido");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }
    }
}
