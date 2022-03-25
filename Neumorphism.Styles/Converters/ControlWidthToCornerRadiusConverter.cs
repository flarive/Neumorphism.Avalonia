using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Neumorphism.Styles.Converters
{
    public class ControlWidthToCornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                double height = (double)value;
                if (height > 0)
                {
                    double radius = (double)(height / 5);
                    return new CornerRadius(radius);
                }
            }

            return new CornerRadius(0);
        }
            

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}