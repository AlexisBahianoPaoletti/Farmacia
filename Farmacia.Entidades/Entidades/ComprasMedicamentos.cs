using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades.Entidades
{
    public class ComprasMedicamentos
    {
        public Compra Compra { get; set; }

        public Medicamento  Medicamento { get; set; }

        public int Cantidad { get; set; }

        public double Precio { get; set; }
    }
}
