using Avalonia.Controls;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class TimePickerAssist
    {
        public static AvaloniaProperty<bool> UseFloatingWatermarkProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, bool>("UseFloatingWatermark", typeof(TimePickerAssist));

        public static void SetUseFloatingWatermark(AvaloniaObject element, bool value) => element.SetValue(UseFloatingWatermarkProperty, value);

        public static bool GetUseFloatingWatermark(AvaloniaObject element) => (bool)element.GetValue(UseFloatingWatermarkProperty);
    }
}