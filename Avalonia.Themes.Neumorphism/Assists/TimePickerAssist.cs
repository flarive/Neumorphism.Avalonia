using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Themes.Neumorphism.Controls;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class TimePickerAssist
    {
        public static AvaloniaProperty<bool> UseFloatingWatermarkProperty = AvaloniaProperty.RegisterAttached<TimePicker, bool>("UseFloatingWatermark", typeof(TimePickerAssist));

        public static void SetUseFloatingWatermark(AvaloniaObject element, bool value) => element.SetValue(UseFloatingWatermarkProperty, value);

        public static bool GetUseFloatingWatermark(AvaloniaObject element) => (bool)element.GetValue(UseFloatingWatermarkProperty);





        public static AvaloniaProperty<string> WatermarkProperty = AvaloniaProperty.RegisterAttached<TimePicker, string>("Watermark", typeof(TimePickerAssist));

        public static void SetWatermark(AvaloniaObject element, string value) => element.SetValue(WatermarkProperty, value);

        public static string GetWatermark(AvaloniaObject element) => (string)element.GetValue(WatermarkProperty);







        public static AvaloniaProperty<IBrush> InnerRightBackgroundProperty = AvaloniaProperty.RegisterAttached<TimePicker, IBrush>("InnerRightBackground", typeof(TimePickerAssist));

        public static void SetInnerRightBackground(AvaloniaObject element, IBrush value) => element.SetValue(InnerRightBackgroundProperty, value);

        public static IBrush GetInnerRightBackground(AvaloniaObject element) => (IBrush)element.GetValue(InnerRightBackgroundProperty);


        public static AvaloniaProperty<Thickness> InnerRightPaddingProperty = AvaloniaProperty.RegisterAttached<TimePicker, Thickness>("InnerRightPadding", typeof(TimePickerAssist));

        public static void SetInnerRightPadding(AvaloniaObject element, Thickness value) => element.SetValue(InnerRightPaddingProperty, value);

        public static Thickness GetInnerRightPadding(AvaloniaObject element) => (Thickness)element.GetValue(InnerRightPaddingProperty);



        public static AvaloniaProperty<string> LabelProperty = AvaloniaProperty.RegisterAttached<TimePicker, string>(
            "Label", typeof(TimePickerAssist));

        public static void SetLabel(AvaloniaObject element, string value) => element.SetValue(LabelProperty, value);

        public static string GetLabel(AvaloniaObject element) => (string)element.GetValue(LabelProperty);

        
    }
}