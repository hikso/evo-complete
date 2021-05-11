using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    public class ProduccionDiaria
    {
        /// <summary>
        /// Indica el id de la producción Diaria
        /// </summary>
        public  int ProduccionDiariaId;

        /// <summary>
        /// Indica la Fecha Produccion del archivo
        /// </summary>
        public DateTime FechaProduccion;    
       

        /// <summary>
        /// Indica el número de canales de cerditos
        /// </summary>
        public int NumeroCanales;


        /// <summary>
        /// Indica el peso caliente del artículo
        /// </summary>
        public decimal PesoCaliente;

        /// <summary>
        /// Indica el peso promedio del día
        /// </summary>
        public decimal PesoPromedioDia;
       

        /// <summary>
        /// Método que convierte las líneas del archivo plano en objetos de Negocio
        /// </summary>
        /// <param name="csvLine"></param>
        /// <param name="separadorDecimal"></param>
        /// <returns></returns>
        //public static ArchivosPlanosMapeo FromCsv(string csvLine,string separadorDecimal)
        //{
          
        //    string[] values = ValidarSeparadorDecimal(csvLine, separadorDecimal);
        //    ArchivosPlanosMapeo valoresArchivoPlano = new ArchivosPlanosMapeo();
        //    valoresArchivoPlano.CodigoArticulo= Convert.ToString(values[0]);
        //    valoresArchivoPlano.FechaCarga = System.DateTime.Now;
        //    valoresArchivoPlano.FechaInicial = System.DateTime.Now;
        //    valoresArchivoPlano.FechaFinal = System.DateTime.Now;
        //    valoresArchivoPlano.Nombre = Convert.ToString(values[1]);
        //    valoresArchivoPlano.NumeroCanales = Convert.ToInt32(values[5]);
        //    valoresArchivoPlano.PesoCaliente = Convert.ToDecimal(values[6]);
        //    valoresArchivoPlano.PesoPromedioDia = Convert.ToDecimal(values[7]);
        //    valoresArchivoPlano.PesoPromedio = Convert.ToDecimal(values[8]);
        //    valoresArchivoPlano.PesoTotal = Convert.ToDecimal(values[9]);
        //    valoresArchivoPlano.PesoDeshuesadoTotal = Convert.ToDecimal(values[10]);
        //    valoresArchivoPlano.PorcentajeArticulo = Convert.ToString(values[11]);
        //    valoresArchivoPlano.DiaUno = Convert.ToDecimal(values[12]);
        //    valoresArchivoPlano.DiaDos = Convert.ToDecimal(values[13]);
        //    valoresArchivoPlano.DiaTres = Convert.ToDecimal(values[14]);
        //    valoresArchivoPlano.DiaCuatro = Convert.ToDecimal(values[15]);
        //    valoresArchivoPlano.DiaCinco = Convert.ToDecimal(values[16]);
        //    valoresArchivoPlano.DiaSeis = Convert.ToDecimal(values[17]);
        //    valoresArchivoPlano.DiaSiete = Convert.ToDecimal(values[18]);
        //    valoresArchivoPlano.SemanaCarga = Convert.ToInt32(values[19]);           
        //    valoresArchivoPlano.ControlCarga = true;

        //    return valoresArchivoPlano;
        //}

        /// <summary>
        /// Método que valida el separador decimal
        /// </summary>
        /// <param name="csvLine"></param>
        /// <param name="separadorDecimal"></param>
        /// <returns></returns>
        //private static string[] ValidarSeparadorDecimal(string csvLine, string separadorDecimal)
        //{

        //    string[] values;

        //    if (separadorDecimal == ";")
        //    {
        //        values = csvLine.Split(';');
        //    }
        //    else if (separadorDecimal == ",")
        //    {
        //        values = csvLine.Split(',');
        //    }
        //    else
        //    {
        //        values = csvLine.Split('\t');
        //    }
        //    return values;
        //}
    }
}
