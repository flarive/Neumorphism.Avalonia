using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class ExpanderAssist
    {
        /// <summary>
        /// ExpanderWidth
        /// </summary>
        public static AvaloniaProperty<double> ExpanderWidthProperty = AvaloniaProperty.RegisterAttached<Expander, double>(
            "ExpanderWidth", typeof(ExpanderAssist));

        public static void SetExpanderWidth(AvaloniaObject element, double value) {
            element.SetValue(ExpanderWidthProperty, value);
        }

        public static double GetExpanderWidth(AvaloniaObject element) {
            return (double) element.GetValue(ExpanderWidthProperty);
        }



        /// <summary>
        /// ExpanderHeight
        /// </summary>
        public static AvaloniaProperty<double> ExpanderHeightProperty = AvaloniaProperty.RegisterAttached<Expander, double>(
            "ExpanderHeight", typeof(ExpanderAssist));

        public static void SetExpanderHeight(AvaloniaObject element, double value)
        {
            element.SetValue(ExpanderHeightProperty, value);
        }

        public static double GetExpanderHeight(AvaloniaObject element)
        {
            return (double)element.GetValue(ExpanderHeightProperty);
        }



        /// <summary>
        /// IconPath
        /// </summary>
        public static AvaloniaProperty<StreamGeometry> IconPathProperty = AvaloniaProperty.RegisterAttached<Expander, StreamGeometry>(
            "IconPath", typeof(ExpanderAssist));

        public static void SetIconPath(AvaloniaObject element, StreamGeometry value)
        {
            element.SetValue(IconPathProperty, value);
        }

        public static StreamGeometry GetIconPath(AvaloniaObject element)
        {
            return (StreamGeometry)element.GetValue(IconPathProperty);
        }
    }
}