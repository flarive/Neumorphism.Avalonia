using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Neumorphism.Avalonia.Styles.Converters
{
    public class WidthToRenderTransformConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Count == 2
                && values[0] != AvaloniaProperty.UnsetValue
                && values[1] != AvaloniaProperty.UnsetValue)
            {
                double width = (double)values[0];
                double heigth = (double)values[1];


                var conv = new TransformConverter();

                if (width is double.NaN || heigth is double.NaN)
                {
                    // no translate
                    return conv.ConvertFromString("translate(0px, 0px)");
                }

                return conv.ConvertFromString("translate(" + (width - heigth) + "px, 0px)");
            }

            return new TranslateTransform(0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}