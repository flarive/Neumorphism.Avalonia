using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class HeightToCornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isAll = parameter == null || parameter.Equals("0");
            bool isLeftTopBottom = parameter == null || parameter.Equals("1");
            bool isRightTopBottom = parameter == null || parameter.Equals("2");
            bool isTopLeftRight = parameter == null || parameter.Equals("3");
            bool isBottomLeftRight = parameter == null || parameter.Equals("4");

            if (value is double)
            {
                double height = ((double)value) / 2;

                if (isAll)
                {
                    return new CornerRadius(height);
                }
                else if (isLeftTopBottom)
                {
                    return new CornerRadius(0, height, height, 0);
                }
                else if (isRightTopBottom)
                {
                    return new CornerRadius(height, 0, 0, height);
                }
                else if (isTopLeftRight)
                {
                    return new CornerRadius(height, height, 0, 0);
                }
                else if (isBottomLeftRight)
                {
                    return new CornerRadius(0, 0, height, height);
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