using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    public class ArchivosPlanosMapeo
    {
        /// <summary>
        /// Indica el id del Archivo Plano
        /// </summary>
        public  int ArchivoId;

        /// <summary>
        /// Indica el  CodigoArticulo
        /// </summary>
        public string CodigoArticulo;

        /// <summary>
        /// Indica nombre del Artículo
        /// </summary>
        public string Nombre;

        /// <summary>
        /// Indica la fecha de carga del archivo
        /// </summary>

        public DateTime FechaCarga;

        /// <summary>
        /// Indica la fecha de inicio  del archivo
        /// </summary>
        public DateTime FechaInicial;

        /// <summary>
        /// Indica la fecha final  del archivo
        /// </summary>
        public DateTime FechaFinal;

        /// <summary>
        /// Indica el número de canales de cerditos
        /// </summary>
        public int NumeroCanales;


        /// <summary>
        /// Indica el peso del día uno de la semana
        /// </summary>
        public decimal DiaUno;

        /// <summary>
        /// Indica el peso del día dos de la semana
        /// </summary>
        public decimal DiaDos;

        /// <summary>
        /// Indica el día tres de la semana
        /// </summary>
        public decimal DiaTres;

        /// <summary>
        /// Indica el peso del día cuatro de la semana
        /// </summary>
        public decimal DiaCuatro;

        /// <summary>
        /// Indica el día cinco de la semana 
        /// </summary>
        public decimal DiaCinco;

        /// <summary>
        /// Indica el día seis de la semana
        /// </summary>
        public decimal DiaSeis;

        /// <summary>
        /// Indica el peso del día siete de la semana
        /// </summary>
        public decimal DiaSiete;

        /// <summary>
        /// Indica el peso caliente del artículo
        /// </summary>
        public decimal PesoCaliente;

        /// <summary>
        /// Indica el peso promedio del día
        /// </summary>
        public decimal PesoPromedioDia;

        /// <summary>
        /// Indica el peso total del artículo
        /// </summary>
        public decimal PesoTotal;

        /// <summary>
        /// Indica el Peso Deshuesado Total
        /// </summary>
        public decimal PesoDeshuesadoTotal;

        /// <summary>
        /// Indica el Peso Promedio
        /// </summary>
        public decimal PesoPromedio;


        /// <summary>
        /// Indica el Porcentaje Articulo
        /// </summary>
        public string PorcentajeArticulo;


        /// <summary>
        /// Indica en que semana se cargó
        /// </summary>
        public int SemanaCarga;

        /// <summary>
        /// Indica el nombre del archivo
        /// </summary>
        public string NombreArchivo;

        /// <summary>
        /// Indica el control si el artículo se cargó
        /// </summary>
        public bool ControlCarga;

        /// <summary>
        /// Método que convierte las líneas del archivo plano en objetos de Negocio
        /// </summary>
        /// <param name="csvLine"></param>
        /// <param name="separadorDecimal"></param>
        /// <returns></returns>
        public static ArchivosPlanosMapeo FromCsv(string csvLine,string separadorDecimal)
        {
          
            string[] values = ValidarSeparadorDecimal(csvLine, separadorDecimal);
            ArchivosPlanosMapeo valoresArchivoPlano = new ArchivosPlanosMapeo();
            valoresArchivoPlano.CodigoArticulo= Convert.ToString(values[0]);
            valoresArchivoPlano.FechaCarga = System.DateTime.Now;
            valoresArchivoPlano.FechaInicial = System.DateTime.Now;
            valoresArchivoPlano.FechaFinal = System.DateTime.Now;
            valoresArchivoPlano.Nombre = Convert.ToString(values[1]);
            valoresArchivoPlano.NumeroCanales = Convert.ToInt32(values[5]);
            valoresArchivoPlano.PesoCaliente = Convert.ToDecimal(values[6]);
            valoresArchivoPlano.PesoPromedioDia = Convert.ToDecimal(values[7]);
            valoresArchivoPlano.PesoPromedio = Convert.ToDecimal(values[8]);
            valoresArchivoPlano.PesoTotal = Convert.ToDecimal(values[9]);
            valoresArchivoPlano.PesoDeshuesadoTotal = Convert.ToDecimal(values[10]);
            valoresArchivoPlano.PorcentajeArticulo = Convert.ToString(values[11]);
            valoresArchivoPlano.DiaUno = Convert.ToDecimal(values[12]);
            valoresArchivoPlano.DiaDos = Convert.ToDecimal(values[13]);
            valoresArchivoPlano.DiaTres = Convert.ToDecimal(values[14]);
            valoresArchivoPlano.DiaCuatro = Convert.ToDecimal(values[15]);
            valoresArchivoPlano.DiaCinco = Convert.ToDecimal(values[16]);
            valoresArchivoPlano.DiaSeis = Convert.ToDecimal(values[17]);
            valoresArchivoPlano.DiaSiete = Convert.ToDecimal(values[18]);
            valoresArchivoPlano.SemanaCarga = Convert.ToInt32(values[19]);           
            valoresArchivoPlano.ControlCarga = true;

            return valoresArchivoPlano;
        }

        /// <summary>
        /// Método que valida el separador decimal
        /// </summary>
        /// <param name="csvLine"></param>
        /// <param name="separadorDecimal"></param>
        /// <returns></returns>
        private static string[] ValidarSeparadorDecimal(string csvLine, string separadorDecimal)
        {

            string[] values;

            if (separadorDecimal == ";")
            {
                values = csvLine.Split(';');
            }
            else if (separadorDecimal == ",")
            {
                values = csvLine.Split(',');
            }
            else
            {
                values = csvLine.Split('\t');
            }
            return values;
        }
    }
}
