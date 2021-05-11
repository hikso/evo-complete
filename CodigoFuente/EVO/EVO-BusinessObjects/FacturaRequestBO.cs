using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 24-May/2020
    /// Descripción     : Clase que representa un objeto de negocio de factura
    /// </summary>
    public class FacturaRequestBO
    {
        /// <summary>
        /// Indica el código del punto de venta
        /// </summary>
        /// <value>Indica el código del punto de venta</value>
        public string CodigoPuntoVenta { get; set; }

        /// <summary>
        /// Indica el id del vendedor
        /// </summary>
        /// <value>Indica el id del vendedor</value>
        public int VendedorId { get; set; }

        /// <summary>
        /// Indica la identificación del socio de negocio(cliente de la factura)
        /// </summary>
        /// <value>Indica la identificación del socio de negocio(cliente de la factura)</value>
        public string IdentificacionCliente { get; set; }

        /// <summary>
        /// Indica el id del tipo de báscula
        /// </summary>
        /// <value>Indica el id del tipo de báscula</value>
        public int TipoBasculaId { get; set; }

        /// <summary>
        /// Indica las observaciones de la factura(Opcional)
        /// </summary>
        /// <value>Indica las observaciones de la factura(Opcional)</value>
        public string Observaciones { get; set; }

        /// <summary>
        /// Indica la sumatoria de los totales por artículo
        /// </summary>
        /// <value>Indica la sumatoria de los totales por artículo</value>
        public int TotalAntesDescuento { get; set; }

        /// <summary>
        /// Indica el porcentaje de descuento(Opcional)
        /// </summary>
        /// <value>Indica el porcentaje de descuento(Opcional)</value>
        public decimal? PorcentajeDescuento { get; set; }

        /// <summary>
        /// Indica el total con descuento(Opcional)
        /// </summary>
        /// <value>345</value>
        public int? TotalConDescuento { get; set; }

        /// <summary>
        /// Indica la cantidad de bolsas
        /// </summary>
        /// <value>Indica la cantidad de bolsas</value>
        public int CantidadBolsas { get; set; }

        /// <summary>
        /// Indica el porcentaje de cobro del valor de la bolsa(Opcional)
        /// </summary>
        /// <value>40</value>
        public int? PorcentajeCobroBolsa { get; set; }

        /// <summary>
        /// Indica el valor de la bolsa(Opcional)
        /// </summary>
        /// <value>40</value>
        public int? ValorBolsa { get; set; }

        /// <summary>
        /// Indica el impuesto de bolsa(Opcional)
        /// </summary>
        /// <value>400,564</value>
        public int? ImpuestoBolsas { get; set; }

        /// <summary>
        /// Indica el valor de los impuestos de la factura
        /// </summary>
        /// <value>75000</value>
        public int ValorImpuestos { get; set; }

        /// <summary>
        /// Indica la retención
        /// </summary>
        /// <value>Indica la retención</value>
        public int? Retencion { get; set; }

        /// <summary>
        /// Indica la retención ICA
        /// </summary>
        /// <value>Indica la retención ICA</value>
        public int? RetencionICA { get; set; }

        /// <summary>
        /// Indica el total de la factura
        /// </summary>
        /// <value>Indica el total de la factura</value>
        public int TotalDocumento { get; set; }

        /// <summary>
        /// Gets or Sets Articulos
        /// </summary>
        public List<ArticuloRequestBO> Articulos { get; set; }

        /// <summary>
        /// Gets or Sets FormasPago
        /// </summary>        
        public List<FormaPagoRequestBO> FormasPago { get; set; }

        /// <summary>
        /// Indica la devuelta
        /// </summary>
        /// <value>5,000</value>
        public int? Devuelta { get; set; }

        /// <summary>
        /// Indica la fecha de facturación
        /// </summary>
        /// <value>12/12/2020</value>
        public DateTime FechaFactura { get; set; }

        /// <summary>
        /// Indica la IP del cliente
        /// </summary>
        /// <value>192.50.1.145</value>
        public string IP { get; set; }

        /// <summary>
        /// Indica la del cuadre de apertura de caja
        /// </summary>
        /// <value>22</value>
        public int CuadreCajaId { get; set; }

        /// <summary>
        /// Indica el nombre de usuario EVO
        /// </summary>
        /// <value>cg-jcusuga</value>
        public string UserName { get; set; }

        /// <summary>
        /// Indica el id del usuario EVO
        /// </summary>
        /// <value>22</value>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Indica el id del tipo de factura
        /// </summary>
        /// <value>2</value>
        public int TipoFacturaId { get; set; }
    }
}
