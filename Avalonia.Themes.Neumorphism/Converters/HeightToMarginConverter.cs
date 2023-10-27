using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class HeightToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int minus = 0;
                
            double val = 0;

            if (value is double)
            {
                val = ((double)value);
            }

            double tLeft = 0;
            double tTop = 0;
            double tRight = 0;
            double tBottom = 0;


            if (parameter != null)
            {
                string param = parameter.ToString();
                if (!string.IsNullOrEmpty(param))
                {
                    string[] parts = param.Split("|");
                    if (parts.Length == 4)
                    {
                        for (int i = 0; i < parts.Length; i++)
                        {
                            double zz = 0;

                            string vparam = parts[i];
                            if (!int.TryParse(vparam, out minus))
                            {
                                // percent
                                if (vparam.EndsWith("%"))
                                {
                                    int percent = 0;
                                    bool negative = false;
                                    vparam = vparam.Replace("%", string.Empty);
                                    negative = vparam.StartsWith("-");
                                    if (negative) { vparam = vparam.Replace("-", string.Empty); }

                                    if (int.TryParse(vparam, out percent))
                                    {
                                        double nn = (val * percent) / 100;
                                        double res = val - nn;

                                        if (!negative)
                                        {
                                            zz = val - res;
                                        }
                                        else
                                        {
                                            zz = -(val - res);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // direct value
                                zz = val - minus;
                            }

                            if (i == 0)
                            {
                                tLeft = zz;
                            }
                            else if (i == 1)
                            {
                                tTop = zz;
                            }
                            else if (i == 2)
                            {
                                tRight = zz;
                            }
                            else if (i == 3)
                            {
                                tBottom = zz;
                            }
                        }
                    }
                }
            }

            return new Thickness(tLeft, tTop, tRight, tBottom);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}