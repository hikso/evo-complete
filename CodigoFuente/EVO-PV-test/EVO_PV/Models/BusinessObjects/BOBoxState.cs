using EVO_PV.Utilities;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOBoxState : NotifyPropertyChanged
    {
        /// <summary>
        /// Indica el estado del cierre de caja del día anterior
        /// </summary>
        /// <value>Indica el estado del cierre de caja del día anterior</value>
        public bool YesterdayIsClosed { get; set; }

        /// <summary>
        /// Indica el estado del apertura de caja del día de hoy
        /// </summary>
        /// <value>Indica el estado del apertura de caja del día de hoy</value>
        public bool TodayIsConfigured { get; set; }

    }
}
