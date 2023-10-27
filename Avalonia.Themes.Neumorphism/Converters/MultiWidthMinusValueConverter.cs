using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class MultiWidthMinusValueConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            double res = 0;

            if (values != null && values.Count == 2
                && values[0] != AvaloniaProperty.UnsetValue && values[0] is double
                && values[1] != AvaloniaProperty.UnsetValue && values[1] is double)
            {

                int minus = 0;
                
                double val1 = (double)values[0];
                double val2 = (double)values[1];


                res = val1;

                
                double val = 0;

                if (val1 < val2)
                {
                    val = val1;
                }
                else
                {
                    val = val2;
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
                                    double p = (val * percent) / 100;

                                    res = res - p;
                                }
                            }
                        }
                        else
                        {
                            res = res - minus;
                        }
                    }
                }
            }

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}