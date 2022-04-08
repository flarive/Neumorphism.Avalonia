using Avalonia;
using Avalonia.Controls;

namespace Neumorphism.Avalonia.Styles.Assists
{
    public class ComboBoxAssist
    {
        public static AvaloniaProperty<string> LabelProperty = AvaloniaProperty.RegisterAttached<ComboBox, string>("Label", typeof(ComboBox));

        public static void SetLabel(AvaloniaObject element, string value) => element.SetValue(LabelProperty, value);

        public static string GetLabel(AvaloniaObject element) => (string)element.GetValue(LabelProperty);




        public static AvaloniaProperty<bool> UseFloatingWatermarkProperty = AvaloniaProperty.RegisterAttached<ComboBox, bool>("UseFloatingWatermark", typeof(ComboBox));

        public static void SetUseFloatingWatermark(AvaloniaObject element, bool value) => element.SetValue(UseFloatingWatermarkProperty, value);

        public static bool GetUseFloatingWatermark(AvaloniaObject element) => (bool)element.GetValue(UseFloatingWatermarkProperty);
    }
}