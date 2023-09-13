using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public class ExtendedTimePicker : TimePicker
    {
        /// <summary>
        /// Defines the <see cref="Watermark"/> property
        /// </summary>
        public static readonly StyledProperty<string> WatermarkProperty =
            AvaloniaProperty.Register<TextBox, string>(nameof(Watermark));

        /// <summary>
        /// Defines the <see cref="UseFloatingWatermark"/> property
        /// </summary>
        public static readonly StyledProperty<bool> UseFloatingWatermarkProperty =
            AvaloniaProperty.Register<TextBox, bool>(nameof(UseFloatingWatermark));

        /// <summary>
        /// Gets or sets the placeholder or descriptive text that is displayed even if the <see cref="Text"/>
        /// property is not yet set.
        /// </summary>
        public string Watermark
        {
            get => GetValue(WatermarkProperty);
            set => SetValue(WatermarkProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="Watermark"/> will still be shown above the
        /// <see cref="Text"/> even after a text value is set.
        /// </summary>
        public bool UseFloatingWatermark
        {
            get => GetValue(UseFloatingWatermarkProperty);
            set => SetValue(UseFloatingWatermarkProperty, value);
        }

    }
}
