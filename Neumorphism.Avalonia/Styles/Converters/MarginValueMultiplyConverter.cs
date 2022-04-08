using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Neumorphism.Avalonia.Styles.Converters.Parameters;

namespace Neumorphism.Avalonia.Styles.Converters
{
    public class MarginMultiplyConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var param = parameter switch
            {
                MarginMultiplyParameter p => p,
                double m => new MarginMultiplyParameter
                {
                    BottomMultiplier = m, LeftMultiplier = m, RightMultiplier = m, TopMultiplier = m
                },
                _ => MarginMultiplyParameter.Default
            };

            if (value is double v && !double.IsNaN(v))
                return new Thickness(v * param.LeftMultiplier, v * param.TopMultiplier, v * param.RightMultiplier,
                    v * param.BottomMultiplier);

            return Thickness.Parse("0");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}