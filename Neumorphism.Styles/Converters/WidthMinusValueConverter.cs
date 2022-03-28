using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Neumorphism.Styles.Converters
{
    public class WidthMinusValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            int minus = 0;
            
            if (parameter != null)
            {
                int.TryParse(parameter.ToString(), out minus);
            }
            
            if (value is double)
            {
                return ((double)value) - minus;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}