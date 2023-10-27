using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class DoubleToLeftRightCornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isLeft = parameter != null && parameter.Equals("0");
            bool isRight = parameter != null && parameter.Equals("1");

            CornerRadius radius = new CornerRadius();

            if (value is CornerRadius)
            {
                radius = (CornerRadius)value;

                if (isLeft)
                {
                    // left : 10 0 0 10
                    return new CornerRadius(radius.BottomLeft, 0, 0, radius.BottomLeft);
                }
                else if (isRight)
                {
                    // right : 0 10 10 0
                    return new CornerRadius(0, radius.BottomLeft, radius.BottomLeft, 0);
                }
            }

            return radius;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}