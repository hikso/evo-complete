using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace EVO_PV.Utilities
{
    public class BrushColorBasculeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case "onchange":
                    return new SolidColorBrush(Colors.Red);
                case "stable":
                    return new SolidColorBrush(Colors.Green);
                case "init":
                    return new SolidColorBrush(Colors.Yellow);
                default:
                    return new SolidColorBrush(Colors.Black);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
