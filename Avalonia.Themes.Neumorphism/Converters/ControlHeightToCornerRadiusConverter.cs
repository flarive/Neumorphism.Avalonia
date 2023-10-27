using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class ControlHeightToCornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isLeft = parameter != null && parameter.Equals("1");
            bool isRight = parameter != null && parameter.Equals("2");
            

            if (value is double)
            {
                double height = (double)value;
                if (height > 0)
                {
                    double radius = (double)(height / 5);

                    if (isLeft)
                    {
                        return new CornerRadius(radius, 0, 0, radius);
                    }
                    else if (isRight)
                    {
                        return new CornerRadius(0, radius, radius, 0);
                    }
                    else
                    {
                        return new CornerRadius(radius);
                    }
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