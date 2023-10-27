using System;
using Avalonia.Markup.Xaml;

namespace Avalonia.Themes.Neumorphism.Controls.Extensions
{
    public sealed class MaterialInternalIconExtension : MarkupExtension
    {
        public MaterialInternalIconExtension()
        {
        }

        public MaterialInternalIconExtension(string kind)
        {
            Kind = kind;
        }

        public MaterialInternalIconExtension(string kind, double? size)
        {
            Kind = kind;
            Size = size;
        }

        [ConstructorArgument("kind")] public string Kind { get; set; }

        [ConstructorArgument("size")] public double? Size { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var result = new MaterialInternalIcon
            {
                Kind = Kind ?? string.Empty
            };

            if (!Size.HasValue)
                return result;

            result.Height = Size.Value;
            result.Width = Size.Value;

            return result;
        }
    }
}