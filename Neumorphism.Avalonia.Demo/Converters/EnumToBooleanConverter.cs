using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace Neumorphism.Avalonia.Demo.Converters
{
    public sealed class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? res = value?.Equals(parameter);

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.Equals(true) == true ? parameter : BindingOperations.DoNothing;
        }
    }
}