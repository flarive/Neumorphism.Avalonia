using Avalonia.Controls;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public sealed class FloatingButton : Button
    {
        public static readonly StyledProperty<bool> IsExtendedProperty =
            AvaloniaProperty.Register<FloatingButton, bool>(nameof(IsExtended));

        public bool IsExtended
        {
            get => GetValue(IsExtendedProperty);
            set => SetValue(IsExtendedProperty, value);
        }
    }
}