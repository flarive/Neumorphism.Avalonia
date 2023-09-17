using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public class TimeFormatStringConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Count >= 3
                && values[0] != AvaloniaProperty.UnsetValue && values[0] is string
                && values[1] != AvaloniaProperty.UnsetValue && values[1] is string
                && values[2] != AvaloniaProperty.UnsetValue && values[2] is string)
            {
                if (values[1].ToString() == "hour" && values[2].ToString() == "minute")
                {
                    return string.Empty;
                }

                if (values[0].ToString() == "12HourClock"
                    && values.Count == 4
                    && values[3] != AvaloniaProperty.UnsetValue && values[3] is string)
                {
                    return string.Format("{0}:{1} {2}", values[1], values[2], values[3]);
                }

                return string.Format("{0}:{1}", values[1], values[2]);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}