using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class CustomCornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int factor = 0;

            var radius = new CornerRadius();

            if (value is CornerRadius)
            {
                radius = (CornerRadius)value;
            }

            double topLeft = radius.TopLeft;
            double topRight = radius.TopRight;
            double bottomLeft = radius.BottomLeft;
            double bottomRight = radius.BottomRight;


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
                            if (!int.TryParse(vparam, out factor))
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
                                        if (i == 0)
                                        {
                                            zz = (topLeft * percent) / 100;
                                        }
                                        else if (i == 1)
                                        {
                                            zz = (topRight * percent) / 100;
                                        }
                                        else if (i == 2)
                                        {
                                            zz = (bottomRight * percent) / 100;
                                        }
                                        else if (i == 3)
                                        {
                                            zz = (bottomLeft * percent) / 100;
                                        }
                                    }
                                }
                            }


                            if (i == 0)
                            {
                                topLeft = zz;
                            }
                            else if (i == 1)
                            {
                                topRight = zz;
                            }
                            else if (i == 2)
                            {
                                bottomRight = zz;
                            }
                            else if (i == 3)
                            {
                                bottomLeft = zz;
                            }
                        }
                    }
                }
            }

            return new CornerRadius(topLeft, topRight, bottomRight, bottomLeft);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}