using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class ExpanderAssist
    {
        public static readonly SolidColorBrush DefaultExpanderStrokeBrushProperty = new SolidColorBrush();


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
        /// ExpanderStrokeBrush
        /// </summary>
        public static AvaloniaProperty<IBrush> ExpanderStrokeBrushProperty = AvaloniaProperty.RegisterAttached<Expander, IBrush>(
            "ExpanderStrokeBrush", typeof(ExpanderAssist), DefaultExpanderStrokeBrushProperty, true);

        public static void SetExpanderStrokeBrush(AvaloniaObject element, IBrush value)
        {
            element.SetValue(ExpanderStrokeBrushProperty, value);
        }

        public static IBrush GetExpanderStrokeBrush(AvaloniaObject element)
        {
            return (IBrush)element.GetValue(ExpanderStrokeBrushProperty);
        }
    }
}