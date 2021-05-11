using EVO_PV.Utilities;
using IntegracionBasculasPorcicarnes.Adapter;
using IntegracionBasculasPorcicarnes.Factory;
using System;
using System.Configuration;
using System.Threading;

namespace EVO_PV.Proxy
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 22-Abr/2020
    /// Descripción      : Esta clase implementa proxys a básculas 
    class WeighingMachinesIPProxy
    {
        #region Atributos
        public BasculasIPAdapter adapter = null;
        private BasculasIPFactory factory = null;
        private int port = 0;
        private string ip = string.Empty;
        #endregion

        #region Contructores
        public WeighingMachinesIPProxy()
        {
            try
            {
                this.ip = Helpers.GetLocalIPAddress();

                string portSetting = ConfigurationManager.AppSettings["PORT_CONNECT_WEIGHING_MACHINE"];

                this.port = 0;

                if (!string.IsNullOrEmpty(portSetting))
                {
                    port = int.Parse(portSetting);
                }

                factory = new BasculasIPAveryZM201();

                adapter = factory.GetAdapter();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Métodos
        public bool Connect()
        {
            try
            {
                if (adapter == null)
                {
                    return false;
                }

                adapter.AbrirEndPoint(ip, port);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion

    }
}
