using Avalonia.Controls;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class ExpanderAssist
    {
        /// <summary>
        /// ToggleWidth
        /// </summary>
        public static AvaloniaProperty<double> ToggleWidthProperty = AvaloniaProperty.RegisterAttached<Expander, double>(
            "ToggleWidth", typeof(ExpanderAssist));

        public static void SetToggleWidth(AvaloniaObject element, double value) {
            element.SetValue(ToggleWidthProperty, value);
        }

        public static double GetToggleWidth(AvaloniaObject element) {
            return (double) element.GetValue(ToggleWidthProperty);
        }



        /// <summary>
        /// ToggleHeight
        /// </summary>
        public static AvaloniaProperty<double> ToggleHeightProperty = AvaloniaProperty.RegisterAttached<Expander, double>(
            "ToggleHeight", typeof(ExpanderAssist));

        public static void SetToggleHeight(AvaloniaObject element, double value)
        {
            element.SetValue(ToggleHeightProperty, value);
        }

        public static double GetToggleHeight(AvaloniaObject element)
        {
            return (double)element.GetValue(ToggleHeightProperty);
        }

    }
}