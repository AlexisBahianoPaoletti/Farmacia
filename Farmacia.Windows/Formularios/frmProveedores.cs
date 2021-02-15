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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }


        private List<Proveedor> lista;
        private ServicioProveedor _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var proveedor in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, proveedor);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Proveedor proveedor)
        {
            r.Cells[clmCUIT.Index].Value = proveedor.CUIT;
            r.Cells[clmRazonSocial.Index].Value = proveedor.RazonSocial;
            r.Cells[clmPersonaDeContacto.Index].Value = proveedor.PersonaDeContacto;
            r.Cells[clmDireccion.Index].Value = proveedor.Direccion;
            r.Cells[clmLocalidad.Index].Value = proveedor.Localidad.NombreLocalidad;
            r.Cells[clmProvincia.Index].Value = proveedor.Provincia.NombreProvincia;
            r.Cells[clmTelefonoFijo.Index].Value = proveedor.TelefonoFijo;
            r.Cells[clmTelefonoMovil.Index].Value = proveedor.TelefonoMovil;
            r.Cells[clmCorreoElectronico.Index].Value = proveedor.CorreoElectronico;
            r.Cells[clmTipoDeIngrediente.Index].Value = proveedor.TipoDeIngrediente.TipoDeIngredientes;

            r.Tag = proveedor;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(Proveedor proveedor)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, proveedor);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmProveedores_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioProveedor();
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
            frmProveedoresAE frm = new frmProveedoresAE(this);
            frm.Text = "Nuevo Proveedor";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Proveedor proveedor = frm.GetProveedor();
                    if (!_servicio.Existe(proveedor))
                    {
                        _servicio.Guardar(proveedor);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, proveedor);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Proveedor repetido");
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
                Proveedor proveedor = (Proveedor)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el proveedor {proveedor.RazonSocial}, CUIT {proveedor.CUIT}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(proveedor.ProveedorId);
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
                Proveedor proveedor = (Proveedor)r.Tag;
                proveedor = _servicio.GetProveedorPorId(proveedor.ProveedorId);
                frmProveedoresAE frm = new frmProveedoresAE();
                frm.Text = "Editar Proveedor";
                frm.SetProveedor(proveedor);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        proveedor = frm.GetProveedor();
                        if (!_servicio.Existe(proveedor))
                        {
                            _servicio.Guardar(proveedor);
                            SetearFila(r, proveedor);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Proveedor Repetido");
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
