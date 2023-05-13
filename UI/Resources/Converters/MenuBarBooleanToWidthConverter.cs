using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UI.Resources.Converters
{
    public class MenuBarBooleanToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolToConvert = (bool)value;
            return boolToConvert ? new GridLength(0.1, GridUnitType.Star) : new GridLength(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
