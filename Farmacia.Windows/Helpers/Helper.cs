using Farmacia.Entidades.Entidades;
using Farmacia.Servicio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia.Windows.Helpers
{
    public class Helper
    {

        public static void CargarComboProvincias(ref ComboBox cbo)
        {
           ServicioProvincia servicioProvincia = new ServicioProvincia();
            cbo.DataSource = null;
            List<Provincia> lista = servicioProvincia.GetLista();
            var defaultProvincia = new Provincia { ProvinciaId = 0, NombreProvincia = "[Seleccione]" };
            lista.Insert(0, defaultProvincia);
            cbo.DataSource = lista;
            cbo.DisplayMember = "NombreProvincia";
            cbo.ValueMember = "ProvinciaId";
            cbo.SelectedIndex = 0;
        }

    }
}
