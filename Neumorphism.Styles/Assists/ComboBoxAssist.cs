using Avalonia;
using Avalonia.Controls;

namespace Neumorphism.Styles.Assists
{
    public class ComboBoxAssist
    {
        public static AvaloniaProperty<string> LabelProperty = AvaloniaProperty.RegisterAttached<ComboBox, string>(
            "Label", typeof(ComboBox));

        public static void SetLabel(AvaloniaObject element, string value) => element.SetValue(LabelProperty, value);

        public static string GetLabel(AvaloniaObject element) => (string)element.GetValue(LabelProperty);
    }
}