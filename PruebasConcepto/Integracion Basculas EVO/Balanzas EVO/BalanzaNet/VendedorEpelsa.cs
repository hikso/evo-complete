using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanzaNet
{
    public class VendedorEpelsa
    {
        public int Identificador { get; set; }
        public string Nombre { get; set; }
        public int Seccion { get; set; }
        public int TeclaDirecta { get; set; }
        public int Estado { get; set; }
        public int EliminarVendedor { get; set; }

        public override string ToString()
        {
            return $"{Identificador} - {Nombre}";
        }
    }
}
