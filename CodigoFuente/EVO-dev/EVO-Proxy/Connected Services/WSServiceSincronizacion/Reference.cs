//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSServiceSincronizacion
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://WSSincronizacion", ConfigurationName="WSServiceSincronizacion.WSSincronizacion")]
    public interface WSSincronizacion
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WSSincronizacion/WSSincronizacion/EnviarDatosSAP", ReplyAction="http://WSSincronizacion/WSSincronizacion/EnviarDatosSAPResponse")]
        System.Threading.Tasks.Task<string> EnviarDatosSAPAsync(string unXML);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WSSincronizacion/WSSincronizacion/ConsultarDatosSAP", ReplyAction="http://WSSincronizacion/WSSincronizacion/ConsultarDatosSAPResponse")]
        System.Threading.Tasks.Task<string> ConsultarDatosSAPAsync(string unXML);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface WSSincronizacionChannel : WSServiceSincronizacion.WSSincronizacion, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class WSSincronizacionClient : System.ServiceModel.ClientBase<WSServiceSincronizacion.WSSincronizacion>, WSServiceSincronizacion.WSSincronizacion
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WSSincronizacionClient() : 
                base(WSSincronizacionClient.GetDefaultBinding(), WSSincronizacionClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_WSSincronizacion.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSSincronizacionClient(EndpointConfiguration endpointConfiguration) : 
                base(WSSincronizacionClient.GetBindingForEndpoint(endpointConfiguration), WSSincronizacionClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSSincronizacionClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WSSincronizacionClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSSincronizacionClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WSSincronizacionClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WSSincronizacionClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string> EnviarDatosSAPAsync(string unXML)
        {
            return base.Channel.EnviarDatosSAPAsync(unXML);
        }
        
        public System.Threading.Tasks.Task<string> ConsultarDatosSAPAsync(string unXML)
        {
            return base.Channel.ConsultarDatosSAPAsync(unXML);           
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_WSSincronizacion))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_WSSincronizacion))
            {
                return new System.ServiceModel.EndpointAddress("http://192.168.1.25/WSSincronizacionPruebas/ServiceSincronizacion.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return WSSincronizacionClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_WSSincronizacion);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return WSSincronizacionClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_WSSincronizacion);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_WSSincronizacion,
        }
    }
}
