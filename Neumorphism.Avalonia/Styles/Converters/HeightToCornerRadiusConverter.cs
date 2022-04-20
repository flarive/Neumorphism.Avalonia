using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Neumorphism.Avalonia.Styles.Converters
{
    public class HeightToCornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                double height = (double)value;

                return new CornerRadius(height / 2);
            }

            return new CornerRadius(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}