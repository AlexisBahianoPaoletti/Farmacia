using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades.Entidades
{
    public class Venta
    {
        public int VentaId { get; set; }

        public Cliente Cliente { get; set; }

        public double PrecioTotal { get; set; }

        public DateTime Fecha { get; set; }
        public List<VentasMedicamentos> ventasMedicamentos { get; set; } = new List<VentasMedicamentos>();

    }
}
