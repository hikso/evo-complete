using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Utils;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using WSServiceSincronizacion;

namespace EVO_PV_Proxy
{
    /// <summary>
    /// Autor            : Juan Esteban Giraldo
    /// Fecha de Creación: 21-Oct/2019
    /// Descripción      : Esta clase implementa los métodos de integración de pedidos entre EVO y SAP.
    /// </summary>
    /// 

    public class PedidosProxy : Automapper
    {
        #region Métodos Públicos
        /// <summary>
        /// Este método se encarga de enviar un pedido a SAP
        /// </summary>
        /// <param name="pedido">Datos del pedido</param>
        public async Task<string> EnviarPedido(Pedido pedido)
        {
            WSSincronizacionClient clienteSAP = new WSSincronizacionClient();           
            string pedidoSerializado = this.SerializarPedido(pedido);
            var respuesta = await clienteSAP.EnviarDatosSAPAsync(pedidoSerializado);
            return respuesta;

        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Este método se encarga de serializar una instancia de un objeto Pedido a un archivo XML que entiende el integrador SAP
        /// </summary>
        /// <param name="pedido">Instancia del objeto de pedido</param>
        /// <returns>Archivo XML con el contrato de datos para el integrador SAP</returns>
        private string SerializarPedido(Pedido pedido)
        {

            string pedidoSerializado = null;

            XmlDocument doc = new XmlDocument();
            XmlElement SAPBOElement, SAPElement;

            doc = this.CrearEncabezdoDocumento(out SAPBOElement, out SAPElement);

            this.CrearSAPElement(pedido, doc, SAPElement);

            SAPBOElement.AppendChild(SAPElement);

            //Se encarga de quitar la estructura de configuracion del XML
            using (StringWriter stringWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = true,
                    IndentChars = "  ",
                    NewLineChars = "\n",
                    NewLineHandling = NewLineHandling.Replace
                };

                using (XmlWriter xmlTextWriter = XmlWriter.Create(stringWriter, settings))
                {
                    doc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    pedidoSerializado = stringWriter.GetStringBuilder().ToString();
                }
            }

            return pedidoSerializado;
        }

        /// <summary>
        /// Se crean los elementos XML exigidos por la integración con SAP
        /// </summary>
        /// <param name="pedido">Datos del objeto de negocio de Pedido</param>
        /// <param name="doc">Documento XML que contiene la estructura de integración</param>
        /// <param name="SAPElement">Elemento SAP que se va a completar con las propiedades del pedido</param>
        private void CrearSAPElement(Pedido pedido, XmlDocument doc, XmlElement SAPElement)
        {
            AppConfiguration appConfig = new AppConfiguration();

            //Encabezado del XML         
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, appConfig.AppSettings["Tabla"], "Series", pedido.Series.ToString())); 
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, appConfig.AppSettings["Tabla"], "ReqName", pedido.NombreUsuario.ToString())); 
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, appConfig.AppSettings["Tabla"], "Email",   pedido.EmailBodega.ToString())); 
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, appConfig.AppSettings["Tabla"], "ReqDate", pedido.FechaEntrega.Value.ToString("dd/MM/yyyy")));
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, appConfig.AppSettings["Tabla"], "DocDate", pedido.FechaPedido.ToString("dd/MM/yyyy"))); 
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, appConfig.AppSettings["Tabla"], "TaxDate", pedido.FechaPedido.ToString("dd/MM/yyyy"))); 
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, appConfig.AppSettings["Tabla"], "DocDueDate",pedido.FechaPedido.ToString("dd/MM/yyyy"))); 

            // Variable NumeroLinea, Se encarga de contar uno a uno cada articulo y este valor lo asigna al numero de linea del XML
            int NumeroLinea = 0;

            // Variable LineasAfectadas, Se encarga de contar cuantos articulos hay en total y este valor lo asigna  a las lineas afectadas del XML
            int LineasAfectadas = pedido.Detalles.Count;

            ////Detalle del XML 
            foreach (var detalle in pedido.Detalles)
            {
    
                SAPElement.AppendChild(CrearPropiedadDetalle(doc, appConfig.AppSettings["TablaDetalle"], "ItemCode", detalle.ItemCode, LineasAfectadas, NumeroLinea));
                SAPElement.AppendChild(CrearPropiedadDetalle(doc, appConfig.AppSettings["TablaDetalle"], "LineVendor", string.Empty, LineasAfectadas, NumeroLinea)); //Proveedor ?
                SAPElement.AppendChild(CrearPropiedadDetalle(doc, appConfig.AppSettings["TablaDetalle"], "Quantity", detalle.Cantidad.ToString(), LineasAfectadas, NumeroLinea));
                SAPElement.AppendChild(CrearPropiedadDetalle(doc, appConfig.AppSettings["TablaDetalle"], "WhsCode", pedido.WhsCode, LineasAfectadas, NumeroLinea)); //cuando es de tipo Compra ?
                SAPElement.AppendChild(CrearPropiedadDetalle(doc, appConfig.AppSettings["TablaDetalle"], "OcrCode2", "2502", LineasAfectadas, NumeroLinea));


                NumeroLinea++;
            }
        }

        /// <summary>
        /// Crea las estructuras del encabezado del documento XML que se envía a SAP
        /// </summary>
        /// <param name="SAPBOElement">Elemento SAPBO requerido por la integración con SAP. Parámetro pasado por referencia.</param>
        /// <param name="SAPElement">Elemento SAP requerido por la integración con SAP. Parámetro pasado por referencia.</param>
        /// <returns>Documento XML con los encabezados recién agregados</returns>
        private XmlDocument CrearEncabezdoDocumento(out XmlElement SAPBOElement, out XmlElement SAPElement)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement ObjetosIntegracionElement = doc.CreateElement(string.Empty, "ObjetosIntegracion", string.Empty);

            XmlAttribute BaseDatosAttr = doc.CreateAttribute("BaseDatos");

            AppConfiguration appConfig = new AppConfiguration();

            //Esta es la base de datos de sap
            BaseDatosAttr.Value = appConfig.AppSettings["BaseDeDatos"];

            ObjetosIntegracionElement.Attributes.Append(BaseDatosAttr);

            doc.AppendChild(ObjetosIntegracionElement);

            SAPBOElement = doc.CreateElement(string.Empty, "SAPBO", string.Empty);
            ObjetosIntegracionElement.AppendChild(SAPBOElement);

            SAPElement = doc.CreateElement(string.Empty, "SAP", string.Empty);
            XmlAttribute ObjetoAttr = doc.CreateAttribute("Objeto");

            //Este Valor es la tabla  de sap que tiene los campos del xml 
            ObjetoAttr.Value = appConfig.AppSettings["Tabla"];

            SAPElement.Attributes.Append(ObjetoAttr);

            XmlAttribute LlaveprimariaAttr = doc.CreateAttribute("Llaveprimaria");

            //Este Valor es la llave primaria de la tabla
            LlaveprimariaAttr.Value = appConfig.AppSettings["LlavePrimaria"];

            SAPElement.Attributes.Append(LlaveprimariaAttr);

            XmlAttribute ValorLlavePrimariaAttr = doc.CreateAttribute("ValorLlavePrimaria");

            //Este es el valor de la llave primaria
            ValorLlavePrimariaAttr.Value = appConfig.AppSettings["ValorLlave"];

            SAPElement.Attributes.Append(ValorLlavePrimariaAttr);

            XmlAttribute OperacionAttr = doc.CreateAttribute("Operacion");

            //Este valor es la accion que hace el xml que es agregar 
            OperacionAttr.Value = appConfig.AppSettings["Accion"];

            SAPElement.Attributes.Append(OperacionAttr);

            return doc;
        }
        #endregion

        private XmlElement CrearPropiedadEncabezado(XmlDocument doc, string nombreTabla, string nombreColumna, string valor)
        {
            XmlElement Propiedad_EncabezadoElement = doc.CreateElement(string.Empty, "Propiedad_Encabezado", string.Empty);
            // Propiedad del encabezado Nombre de la tabla 
            XmlAttribute NombreTablaAttr = doc.CreateAttribute("NombreTabla");

            NombreTablaAttr.Value = nombreTabla;

            Propiedad_EncabezadoElement.Attributes.Append(NombreTablaAttr);
            // Propiedad del encabezado Nombre de la columna 
            XmlElement NombreColumnaElement = doc.CreateElement(string.Empty, "NombreColumna", string.Empty);

            NombreColumnaElement.InnerText = nombreColumna;

            Propiedad_EncabezadoElement.AppendChild(NombreColumnaElement);
            // Propiedad del encabezado se asigna el valor de la columna 
            XmlElement ValorColumnaElement = doc.CreateElement(string.Empty, "ValorColumna", string.Empty);

            ValorColumnaElement.InnerText = valor;

            Propiedad_EncabezadoElement.AppendChild(ValorColumnaElement);

            return Propiedad_EncabezadoElement;
        }

        private XmlElement CrearPropiedadDetalle(XmlDocument doc, string nombreTablaDetalle, string nombreColumnaDetalle, string valor, int lineas, int numero)
        {
            //Propiedad de detalle Nombre de tabla 
            XmlElement Propiedad_DetalleElement = doc.CreateElement(string.Empty, "Propiedad_Detalle", string.Empty);

            XmlAttribute NombreTablaADetallettr = doc.CreateAttribute("NombreTabla");

            NombreTablaADetallettr.Value = nombreTablaDetalle;

            Propiedad_DetalleElement.Attributes.Append(NombreTablaADetallettr);

            //Nombre de los campos 
            XmlElement NombreColumnaDetalleElement = doc.CreateElement(string.Empty, "NombreColumna", string.Empty);

            NombreColumnaDetalleElement.InnerText = nombreColumnaDetalle;

            Propiedad_DetalleElement.AppendChild(NombreColumnaDetalleElement);

            // Valor del campo 
            XmlElement ValorColumnaElement = doc.CreateElement(string.Empty, "ValorColumna", string.Empty);

            ValorColumnaElement.InnerText = valor;

            Propiedad_DetalleElement.AppendChild(ValorColumnaElement);

            //Lineas afectadas XML
            XmlElement LineasAfectadasElement = doc.CreateElement(string.Empty, "LineasAfectadas", string.Empty);

            LineasAfectadasElement.InnerText = lineas.ToString();

            Propiedad_DetalleElement.AppendChild(LineasAfectadasElement);

            //Numero de linea XML
            XmlElement NumeroLineaElement = doc.CreateElement(string.Empty, "NumeroLinea", string.Empty);

            NumeroLineaElement.InnerText = numero.ToString();

            Propiedad_DetalleElement.AppendChild(NumeroLineaElement);

            return Propiedad_DetalleElement;
        }




    }
}