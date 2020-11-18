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
    public partial class frmLocalidades : Form
    {
        public frmLocalidades()
        {
            InitializeComponent();
        }


        private List<Localidad> lista;
        private ServicioLocalidad _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var localidad in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, localidad);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Localidad localidad)
        {
            r.Cells[clmLocalidad.Index].Value = localidad.NombreLocalidad;
            r.Cells[clmProvincia.Index].Value = localidad.Provincia.NombreProvincia;

            r.Tag = localidad;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(Localidad localidad)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, localidad);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmLocalidades_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioLocalidad();
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
            frmLocalidadesAE frm = new frmLocalidadesAE(this);
            frm.Text = "Nueva Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Localidad localidad = frm.GetLocalidad();
                    if (!_servicio.Existe(localidad))
                    {
                        _servicio.Guardar(localidad);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, localidad);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Localidad repetida");
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
                Localidad localidad = (Localidad)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja la localidad {localidad.NombreLocalidad}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(localidad))
                    {
                        try
                        {
                            _servicio.Borrar(localidad.LocalidadId);
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
                Localidad localidad = (Localidad)r.Tag;
                frmLocalidadesAE frm = new frmLocalidadesAE();
                frm.Text = "Editar Localidad";
                frm.SetLocalidad(localidad);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        localidad = frm.GetLocalidad();
                        if (!_servicio.Existe(localidad))
                        {
                            _servicio.Guardar(localidad);
                            SetearFila(r, localidad);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Localidad Repetida");
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
