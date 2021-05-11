using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 22-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de Pesaje
    /// </summary>
    public class BOPesaje
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int PesajeId { get; set; }

        /// <summary>
        /// Define la clave foránea a PesajesArticulo
        /// </summary>       
        public int PesajeArticuloId { get; set; }      

        /// <summary>
        /// Define la clave foránea del usuario
        /// </summary>     
        public int UsuarioId { get; set; }      

        /// <summary>
        /// Define la clave foránea de TiposBascula
        /// </summary>      
        public int TipoBasculaId { get; set; }

        /// <summary>
        /// Define el código de la bodega donde está almacenado el artículo a pesar
        /// </summary>       
        public string CodigoBodega { get; set; }

        /// <summary>
        /// Define el peso de la báscula kg
        /// </summary>
        public decimal PesoBascula { get; set; }

        /// <summary>
        /// Define el peso báscula menos peso de los contenedores en kg
        /// </summary>
        public decimal PesoBasculaArticulos { get; set; }      

        /// <summary>
        /// Define el peso de todos los códigos de barras asociados a este pesaje kg
        /// </summary>
        public decimal? PesoCodigosBarras { get; set; }

        /// <summary>
        /// Cantidad de contenedores máxima por pesaje
        /// </summary>    
        public string PesajeAl { get; set; }

        public BOPesajeArticulo PesajeArticulo { get; set; }

        public List<BOPesajeContenedor> PesajeContenedor { get; set; }

        public List<BOPesajeCodigoBarras> PesajesCodigoBarras { get; set; }

    }
}
