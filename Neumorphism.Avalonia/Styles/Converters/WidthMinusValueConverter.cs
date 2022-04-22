using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Neumorphism.Avalonia.Styles.Converters
{
    public class WidthMinusValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int minus = 0;
            double val = 0;

            if (value is double)
            {
                val = ((double)value);
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

            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}