using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades.Entidades
{
    public class Localidad
    {
        public int LocalidadId { get; set; }
        public string NombreLocalidad { get; set; }
        public Provincia Provincia { get; set; }
    }
}
