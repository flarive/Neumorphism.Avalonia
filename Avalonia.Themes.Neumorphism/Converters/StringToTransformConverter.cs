using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media.Transformation;

namespace Avalonia.Themes.Neumorphism.Converters
{
    public sealed class StringToTransformConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return TransformOperation.Identity;
            var r = TransformOperations.Parse(value.ToString());
            return r;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
