using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanzaNet
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public int Plu { get; set; }
        public int Precio { get; set; }
        public string Texto { get; set; }
        public int Peso { get; set; }
        public List <Articulo> Articulos { get; set; }
    }
}
