using System;
using System.Globalization;
using System.Threading;
using System.Windows.Data;

namespace EVO_PB.Utilities
{
    /// <summary>
    /// Autor            : Edwin Tapie
    /// Fecha de Creación: 24-Ene/2019
    /// Descripción      : Esta clase implementa la conversión de los valores de tipo Decimal en las vistas
    /// </summary>
    public class DecimalConverter : IValueConverter
    {
        /// <summary>
        /// Método que convierte los valores al tipo de dato que se defina
        /// </summary>
        /// <param name="value">valor a darle a el formato</param>
        /// <param name="targetType">Tipo de dato al que se quiere convertir</param>
        /// <param name="parameter">Parámetro para definir criterio de conversión</param>
        /// <param name="culture">Cultura a tener en cuenta en la conversión</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            culture = Thread.CurrentThread.CurrentCulture;
            decimal val = 0;
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            if (value != null)
                decimal.TryParse(value.ToString(), style, culture, out val);
            if (val == 0)
                return string.Format("{0:0}", val);
            else
                return string.Format("{0:#,#.#}", val);
        }
        /// <summary>
        /// Método que en caso de que el valor sea null lo convierta en un valor númerico válido
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "0.00";

            return ((string)value);
        }
    }
}
