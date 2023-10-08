using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class TimePickerAssist
    {
        public static AvaloniaProperty<IBrush> InnerRightBackgroundProperty = AvaloniaProperty.RegisterAttached<TimePicker, IBrush>("InnerRightBackground", typeof(TimePickerAssist));

        public static void SetInnerRightBackground(AvaloniaObject element, IBrush value) => element.SetValue(InnerRightBackgroundProperty, value);

        public static IBrush GetInnerRightBackground(AvaloniaObject element) => (IBrush)element.GetValue(InnerRightBackgroundProperty);


        public static AvaloniaProperty<Thickness> InnerRightPaddingProperty = AvaloniaProperty.RegisterAttached<TimePicker, Thickness>("InnerRightPadding", typeof(TimePickerAssist));

        public static void SetInnerRightPadding(AvaloniaObject element, Thickness value) => element.SetValue(InnerRightPaddingProperty, value);

        public static Thickness GetInnerRightPadding(AvaloniaObject element) => (Thickness)element.GetValue(InnerRightPaddingProperty);



        public static AvaloniaProperty<string> LabelProperty = AvaloniaProperty.RegisterAttached<TimePicker, string>("Label", typeof(TimePickerAssist));

        public static void SetLabel(AvaloniaObject element, string value) => element.SetValue(LabelProperty, value);

        public static string GetLabel(AvaloniaObject element) => (string)element.GetValue(LabelProperty);
    }
}