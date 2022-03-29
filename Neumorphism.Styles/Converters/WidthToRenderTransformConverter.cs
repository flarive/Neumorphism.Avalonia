using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Neumorphism.Styles.Converters
{
    public class WidthToRenderTransformConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Count == 2
                && values[0] != AvaloniaProperty.UnsetValue
                && values[1] != AvaloniaProperty.UnsetValue
                )
            {
                double width = (double)values[0];
                double heigth = (double)values[1];

                //return new TranslateTransform(width - heigth, 0);
                
                var p = new TranslateTransform();
                p.X = width - heigth;
                p.Y = 0;

                p.Transitions = new Transitions();

                var x = new TransformOperationsTransition();// { Duration = new TimeSpan(50), Easing, Property = AvaloniaRenderTransformProperty }
                x.Duration = new TimeSpan(50);
                x.Easing = new LinearEasing();
                x.Property = new AvaloniaProperty()

                p.Transitions.Add(x);

                return p;
            }

            return new TranslateTransform(0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}