using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class ProgressBarAssist
    {
        public static readonly AvaloniaProperty<object> CircularInnerContentProperty = AvaloniaProperty.RegisterAttached<ProgressBar, object>(
            "CircularInnerContent", typeof(ProgressBarAssist), null, true);

        public static object GetCircularInnerContent(AvaloniaObject element)
        {
            return (object)element.GetValue(CircularInnerContentProperty);
        }

        public static void SetCircularInnerContent(AvaloniaObject element, object value)
        {
            element.SetValue(CircularInnerContentProperty, value);
        }


        /// <summary>
        /// Circular progress only
        /// </summary>
        public static readonly AvaloniaProperty<object> StrokeLineCapProperty = AvaloniaProperty.RegisterAttached<ProgressBar, object>(
            "StrokeLineCap", typeof(ProgressBarAssist), PenLineCap.Flat, true);

        public static PenLineCap GetStrokeLineCap(AvaloniaObject element)
        {
            return (PenLineCap)element.GetValue(StrokeLineCapProperty);
        }

        public static void SetStrokeLineCap(AvaloniaObject element, PenLineCap value)
        {
            element.SetValue(StrokeLineCapProperty, value);
        }
    }
}