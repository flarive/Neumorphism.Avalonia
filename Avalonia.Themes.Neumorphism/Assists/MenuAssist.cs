using Avalonia.Controls;
using Avalonia.Controls.Primitives.PopupPositioning;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class MenuAssist
	{
        private static readonly PopupAnchor DefaultPopupAnchor = PopupAnchor.TopLeft;

        #region AttachedProperty : PopupAnchorProperty

        public static readonly AvaloniaProperty<PopupAnchor> PopupAnchorProperty = AvaloniaProperty.RegisterAttached<MenuItem, PopupAnchor>(
            "PopupAnchor", typeof(MenuAssist), DefaultPopupAnchor, true);

        public static PopupAnchor GetPopupAnchor(AvaloniaObject element) {
            return (PopupAnchor) element.GetValue(PopupAnchorProperty);
        }

        public static void SetPopupAnchor(AvaloniaObject element, PopupAnchor value) {
            element.SetValue(PopupAnchorProperty, value);
        }

        #endregion

        #region AttachedProperty : HorizontalOffsetProperty

        public static readonly AvaloniaProperty<double> HorizontalOffsetProperty = AvaloniaProperty.RegisterAttached<MenuItem, double>(
            "HorizontalOffset", typeof(MenuAssist), 0, true);

        public static double GetHorizontalOffset(AvaloniaObject element)
        {
            return (double)element.GetValue(HorizontalOffsetProperty);
        }

        public static void SetHorizontalOffset(AvaloniaObject element, double value)
        {
            element.SetValue(HorizontalOffsetProperty, value);
        }

        #endregion

        #region AttachedProperty : VerticalOffsetProperty

        public static readonly AvaloniaProperty<double> VerticalOffsetProperty = AvaloniaProperty.RegisterAttached<MenuItem, double>(
            "VerticalOffset", typeof(MenuAssist), 0, true);

        public static double GetVerticalOffset(AvaloniaObject element)
        {
            return (double)element.GetValue(VerticalOffsetProperty);
        }

        public static void SetVerticalOffset(AvaloniaObject element, double value)
        {
            element.SetValue(VerticalOffsetProperty, value);
        }

        #endregion
    }
}