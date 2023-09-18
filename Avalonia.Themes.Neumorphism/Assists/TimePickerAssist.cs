using Avalonia.Media;
using Avalonia.Themes.Neumorphism.Controls;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class TimePickerAssist
    {
        public static AvaloniaProperty<IBrush> InnerRightBackgroundProperty = AvaloniaProperty.RegisterAttached<ExtendedTimePicker, IBrush>("InnerRightBackground", typeof(TimePickerAssist));

        public static void SetInnerRightBackground(AvaloniaObject element, IBrush value) => element.SetValue(InnerRightBackgroundProperty, value);

        public static IBrush GetInnerRightBackground(AvaloniaObject element) => (IBrush)element.GetValue(InnerRightBackgroundProperty);


        public static AvaloniaProperty<Thickness> InnerRightPaddingProperty = AvaloniaProperty.RegisterAttached<ExtendedTimePicker, Thickness>("InnerRightPadding", typeof(TimePickerAssist));

        public static void SetInnerRightPadding(AvaloniaObject element, Thickness value) => element.SetValue(InnerRightPaddingProperty, value);

        public static Thickness GetInnerRightPadding(AvaloniaObject element) => (Thickness)element.GetValue(InnerRightPaddingProperty);
    }
}