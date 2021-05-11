

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 9-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo alistamiento pesaje
    /// </summary>
    public class AlistamientoPesaje
    {
      
        public int AlistamientoPesajeId { get; set; }

        /// <summary>
        /// Define la clave foránea a AlistamientoArticulo
        /// </summary>       
      
        public int AlistamientoArticuloId { get; set; }        

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
        /// Define el peso real de los artículos por tipo de pesaje en kg
        /// </summary>      
        public decimal PesoArticulos { get; set; }
    }
}
