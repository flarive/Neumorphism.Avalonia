using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class TimePickerAssist
    {
        public static AvaloniaProperty<bool> UseFloatingWatermarkProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, bool>("UseFloatingWatermark", typeof(TimePickerAssist));

        public static void SetUseFloatingWatermark(AvaloniaObject element, bool value) => element.SetValue(UseFloatingWatermarkProperty, value);

        public static bool GetUseFloatingWatermark(AvaloniaObject element) => (bool)element.GetValue(UseFloatingWatermarkProperty);


        public static AvaloniaProperty<IBrush> InnerRightBackgroundProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, IBrush>(
            "InnerRightBackground", typeof(TimePickerAssist));

        public static void SetInnerRightBackground(AvaloniaObject element, IBrush value) => element.SetValue(InnerRightBackgroundProperty, value);

        public static IBrush GetInnerRightBackground(AvaloniaObject element) => (IBrush)element.GetValue(InnerRightBackgroundProperty);


        public static AvaloniaProperty<Thickness> InnerRightPaddingProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, Thickness>(
            "InnerRightPadding", typeof(TimePickerAssist));

        public static void SetInnerRightPadding(AvaloniaObject element, Thickness value) => element.SetValue(InnerRightPaddingProperty, value);

        public static Thickness GetInnerRightPadding(AvaloniaObject element) => (Thickness)element.GetValue(InnerRightPaddingProperty);
    }
}