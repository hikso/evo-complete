using EVO_BusinessObjects.Enum;
using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 23-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio BOPesajeRequest
    /// </summary>
    public class BOPesajeRequest
    {
        /// <summary>
        /// Código artículo
        /// </summary>
        /// <value>PT-1485</value>        
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Id del articuloPesaje
        /// </summary>
        /// <value>1</value>        
        public int PesajeArticuloId { get; set; }

        /// <summary>
        /// Id del tipo de báscula
        /// </summary>
        /// <value>2</value>        
        public int TipoBasculaId { get; set; }

        /// <summary>
        /// Id del usuario
        /// </summary>
        /// <value>3</value>        
        public int UsuarioId { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        /// <value>cg-jcusuga</value>        
        public string Usuario { get; set; }

        /// <summary>
        /// Id de la entrega
        /// </summary>
        /// <value>Id de la entrega</value>        
        public int EntregaId { get; set; }

        /// <summary>
        /// Id del detalle de la entrega
        /// </summary>
        /// <value>Id del detalle de la entrega</value>        
        public int DetalleEntregaId { get; set; }

        /// <summary>
        /// Peso de la báscula
        /// </summary>
        /// <value>Peso de la báscula</value>       
        public decimal PesoBascula { get; set; }

        /// <summary>
        /// Peso del artículo
        /// </summary>
        /// <value>Peso del artículo</value>       
        public decimal PesoArticulo { get; set; }

        /// <summary>
        /// Fecha del pesaje
        /// </summary>
        /// <value>Fecha del pesaje</value>       
        public DateTime FechaPesaje { get; set; }

        /// <summary>
        /// Gets or Sets Contenedores
        /// </summary>      
        public List<BOContenedorRequest> Contenedores { get; set; }

        /// <summary>
        /// Cantidad de contenedores en un pesaje
        /// </summary>
        /// <value>Cinco</value>      
        public PesajeAlEnum PesajeAl { get; set; }
    }
}
