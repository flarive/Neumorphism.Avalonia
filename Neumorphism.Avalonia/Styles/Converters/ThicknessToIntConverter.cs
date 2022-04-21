using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Neumorphism.Avalonia.Styles.Converters
{
    public class ThicknessToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness)
            {
                return (int)((Thickness)value).Top;
            }
                
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}