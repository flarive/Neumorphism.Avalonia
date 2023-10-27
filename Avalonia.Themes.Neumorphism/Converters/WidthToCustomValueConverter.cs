using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class WidthToCustomValueConverter : IValueConverter
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
                            bool negative = false;
                            param = param.Replace("%", string.Empty);
                            negative = param.StartsWith("-");
                            if (negative) { param = param.Replace("-", string.Empty); }
                            
                            if (int.TryParse(param, out percent))
                            {
                                double res = 0;
                                double nn = (val * percent) / 100;

                                if (!negative)
                                {
                                    res = nn;
                                }
                                else
                                {
                                    res = -nn;
                                }

                                return res;
                            }
                        }
                    }
                    else
                    {
                        return -minus;
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