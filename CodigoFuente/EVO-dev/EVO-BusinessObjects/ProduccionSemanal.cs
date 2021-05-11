using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    public class ProduccionSemanal
    {
        /// <summary>
        /// Indica el id del Archivo Plano
        /// </summary>
        public  int ProduccionSemanalId;

        /// <summary>
        /// Indica el Ano del Archivo Plano
        /// </summary>
        public int Ano;

        /// <summary>
        /// Indica el Mes del Archivo Plano
        /// </summary>
        public int Mes;

        /// <summary>
        /// Indica el Semana del Archivo Plano
        /// </summary>
        public int Semana;           
        

        /// <summary>
        /// Indica el peso total del artículo
        /// </summary>
        public decimal PesoTotal;


        /// <summary>
        /// Indica el Peso Deshuesado Total
        /// </summary>
        public decimal PesoDeshuesadoTotal;



        /// <summary>
        /// Indica el Porcentaje Articulo
        /// </summary>
        public decimal PorcentajeArticulo;


        /// <summary>
        /// Indica el  CodigoArticulo
        /// </summary>
        public string CodigoArticulo;
       
        /// <summary>
        /// Indica la fecha de carga del archivo
        /// </summary>
        public DateTime FechaCarga;

        /// <summary>
        /// Indica el  NombreArchivo
        /// </summary>
        public string NombreArchivo;
      
    }
}
