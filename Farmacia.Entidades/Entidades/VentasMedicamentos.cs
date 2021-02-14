using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades.Entidades
{
    public class VentasMedicamentos
    {
        public Venta venta { get; set; }
        public Medicamento medicamento { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
