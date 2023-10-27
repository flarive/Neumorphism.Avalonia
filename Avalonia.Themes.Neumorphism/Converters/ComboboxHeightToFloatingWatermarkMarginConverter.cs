using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class ComboboxHeightToFloatingWatermarkMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double height = 0;

            int offset = 0;
            if (parameter != null)
            {
                int.TryParse(parameter.ToString(), out offset);
            }

            if (value is double)
            {
                height = (double)value;

                return new Thickness(1, (-height/2) + offset, 30, 10);
            }

            return new Thickness(1, -16, 30, 10);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}