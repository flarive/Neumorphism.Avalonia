using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class ThicknessToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int minus = 0;

            double val = 0;

            if (value is Thickness)
            {
                val = (int)((Thickness)value).Top;
            }

            if (parameter != null)
            {
                string param = parameter.ToString();
                if (!string.IsNullOrEmpty(param))
                {
                    if (!int.TryParse(param, out minus))
                    {
                        // percent
                        if (param.EndsWith("%"))
                        {
                            int percent = 0;
                            param = param.Replace("%", string.Empty);
                            if (int.TryParse(param, out percent))
                            {
                                double nn = (val * percent) / 100;
                                return val - nn;
                            }
                        }
                    }
                    else
                    {
                        return val - minus;
                    }
                }
            }

            //if (value is Thickness)
            //{
            //    return (int)((Thickness)value).Top;
            //}

            return (int)val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}