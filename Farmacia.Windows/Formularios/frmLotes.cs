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
    public partial class frmLotes : Form
    {
        public frmLotes()
        {
            InitializeComponent();
        }


        private List<Lote> lista;
        private ServicioLote _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var lote in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, lote);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Lote lote)
        {
            r.Cells[clmMedicamento.Index].Value = lote.Medicamento.NombreComercial;
            r.Cells[clmIdentificacion.Index].Value = lote.Identificacion;
            r.Cells[clmFechaDeIngreso.Index].Value = lote.FechaDeIngreso;
            r.Cells[clmVencimiento.Index].Value = lote.Vencimiento;
            r.Cells[clmCantidad.Index].Value = lote.Cantidad;


            r.Tag = lote;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(Lote lote)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, lote);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmLotes_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioLote();
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
            frmLotesAE frm = new frmLotesAE(this);
            frm.Text = "Nuevo Lote";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Lote lote = frm.GetLote();
                    if (!_servicio.Existe(lote))
                    {
                        _servicio.Guardar(lote);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, lote);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Lote repetido");
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
                Lote lote = (Lote)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el lote {lote.Identificacion}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(lote.LoteId);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Registro borrado");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);

                    }
                }
            }
        }


        private void tslEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Lote lote = (Lote)r.Tag;
                lote = _servicio.GetLotePorId(lote.LoteId);
                frmLotesAE frm = new frmLotesAE();
                frm.Text = "Editar Lote";
                frm.SetLote(lote);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        lote = frm.GetLote();
                        if (!_servicio.Existe(lote))
                        {
                            _servicio.Guardar(lote);
                            SetearFila(r, lote);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Lote Repetido");
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
