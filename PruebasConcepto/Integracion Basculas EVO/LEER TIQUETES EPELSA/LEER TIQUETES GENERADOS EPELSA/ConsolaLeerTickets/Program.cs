using System;
using System.Collections.Generic;

namespace ConsolaLeerTickets
{
    class Ticket
    {
        public int numero { get; set; }
        public int seccion { get; set; }
        public string teclaVendedor { get; set; }
        public decimal peso { get; set; }
        public TimeSpan hora { get; set; }
        public DateTime fecha { get; set; }
        public decimal precio { get; set; }
        public List<Articulo> articulos { get; set; }
    }

    class Articulo
    {
        public int transaccion { get; set; }
        public string codigoArticulo { get; set; }
        public DateTime fecha { get; set; }
        public decimal precio { get; set; }
        public decimal kilogramo { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\ticketes\Tiquete_Epelsa.txt");
            List<Ticket> tickets = new List<Ticket>();
            Ticket ticket = null;
            int indice = -1;
            foreach (string line in lines)
            {
                string[] lineArray = line.Split(',');

                if (lineArray.Length > 10)
                {
                    ticket = new Ticket()
                    {
                        numero = int.Parse(lineArray[1]),
                        seccion = int.Parse(lineArray[2]),
                        teclaVendedor = lineArray[3],
                        peso = decimal.Parse(lineArray[8]),
                        hora = new TimeSpan(int.Parse(lineArray[9].Substring(0, 2)), int.Parse(lineArray[9].Substring(2, 2)), int.Parse(lineArray[9].Substring(4, 2))),
                        fecha = new DateTime(2000+int.Parse(lineArray[10].Substring(4, 2)),int.Parse(lineArray[10].Substring(2, 2)), int.Parse(lineArray[10].Substring(0, 2))),
                        precio = decimal.Parse(lineArray[12]),
                        articulos = new List<Articulo>()
                    };

                    tickets.Add(ticket);
                    indice++;
                    continue;
                }
                else
                {
                    Articulo articulo = new Articulo()
                    {
                        transaccion = int.Parse(lineArray[1]),
                        codigoArticulo = lineArray[2],
                        precio = decimal.Parse(lineArray[3]),
                        kilogramo = decimal.Parse(lineArray[4])
                    };

                    tickets[indice].articulos.Add(articulo);
                }
            }

            Console.WriteLine($"Total Tiquetes: {indice}");
            Console.ReadLine();
        }
    }
}
