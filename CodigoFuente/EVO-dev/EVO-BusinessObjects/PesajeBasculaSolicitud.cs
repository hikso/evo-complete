using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 9-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo Pesaje Bascula Solicitud
    /// </summary>
    public class PesajeBasculaSolicitud
    {
        /// <summary>
        /// Id del Usuario
        /// </summary>
        /// <value>4</value>       
        public int UsuarioId { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        /// <value>Dominio\Usuario</value>       
        public string UsuarioName { get; set; }

        /// <summary>
        /// Id del detalle de la entrega
        /// </summary>
        /// <value>Id del detalle de la entrega</value>       
        public int DetalleEntregaId { get; set; }

        /// <summary>
        /// Id del tipo de la báscula
        /// </summary>
        /// <value>Id del tipo de la báscula</value>   
        public int TipoBasculaId { get; set; }

        /// <summary>
        /// Código de la bodega donde será sacado el artículo
        /// </summary>
        /// <value>Código de la bodega donde será sacado el artículo</value>       
        public string CodigoBodega { get; set; }

        /// <summary>
        /// Peso de la báscula
        /// </summary>
        /// <value>8907</value>       
        public decimal PesoBascula { get; set; }

        /// <summary>
        /// Peso del artículo
        /// </summary>
        /// <value>567</value>       
        public decimal PesoArticulos { get; set; }

        /// <summary>
        /// Pesaje Finalizado
        /// </summary>
        /// <value>True</value>       
        public bool PesajeFinalizado { get; set; }

        /// <summary>
        /// Gets or Sets ContenedoresSolicitud
        /// </summary>

        public List<PesajeContenedor> ContenedoresRequest { get; set; }
    }
}
