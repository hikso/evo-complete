using BalanzaNet;
using System;

namespace ConsolaNet
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Variables Globales
            Epelsa balanza = new Epelsa();
            //Las balanzas deben de estar en cada hilo, luego se implementan los hilos
            //Epelsa conexionBallanza = new Epelsa(0, 0, $"172.050.0.{i}:6000");
            balanza.MostrarMensajeEvento += new Epelsa.MostrarMensajeDelegate(MostrarMensaje);
            balanza.EnviarVendedor += new Epelsa.EnviarVendedorDelegate(EnviarVendedor);
            #endregion

            #region Configurar Balanza
            balanza.Configurar(0, 0, $"172.050.0.38:6000");
            #endregion

            //balanza.ReiniciarNumeracionTiquete(ReiniciarTiquete.Reiniciar); //Reinicia numeración Tiquete


            #region Enviar Vendedor (Agregar/Actualizar/Eliminar)
            //Agregar Vendedor
            //for (int v = 101; v <= 128; v++)
            //{
            //    //Epelsa conexionOK = new Epelsa(0, 0, $"172.050.0.{x}:6000");
            //    balanza.AgregarVendedor(v, $"Vendedor {v}", 1, v - 100);
            //}

            //Actualizar Vendedor
            //for (int v = 101; v <= 128; v++)
            //{
            //    //Epelsa conexionOK = new Epelsa(0, 0, $"172.050.0.{x}:6000");
            //    balanza.ActualizarVendedor(v, $"Vendedor Actualizado {v}", 1, v - 100);
            //}

            //Eliminar Vendedor
            //for (int v = 101; v <= 128; v++)
            //{
            //    //Epelsa conexionOK = new Epelsa(0, 0, $"172.050.0.{x}:6000");
            //    balanza.EliminarVendedor(v, $"Vendedor Actualizado {v}", 1, v - 100);
            //}
            #endregion

            #region Exportar Tiquetes Archivo Plano
            balanza.GenerarTiquetes();
            #endregion

            #region Reiniciar Tiquete
            //balanza.ReiniciarNumeracionTiquete(1);
            #endregion


            #region Enviar Articulo + Tecla Directa

            //balanza.AgregarArticulo(2070, "Lomillo camilillo", TipoPesoEnum.Peso, 0, 1, 0, 43); // si es Cero se toma el peso por cantidad. ( ͠~ ͜ʖ ͡°)

            //balanza.ActualizarArticulo(2070, "Lomillo Camilillo", TipoPesoEnum.Peso, 0, 1, 0, 44); // si es Cero se toma el peso por cantidad.

            //balanza.EliminarArticulo(2026, 0, 1, 0, 45);

            //balanza.ConsultarArticulo(1330);
            //balanza.ConsultarArticulo(1485);
            #endregion

            balanza.Reset();
            Console.ReadLine();
        }

        private static void EnviarVendedor(VendedorEpelsa vendedor)
        {
            Console.WriteLine(vendedor.ToString());
            //  Console.ReadLine();
        }

        public static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
            // Console.ReadLine();
        }
    }
}
