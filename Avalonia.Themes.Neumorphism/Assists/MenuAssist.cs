using Avalonia.Controls;
using Avalonia.Controls.Primitives.PopupPositioning;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class MenuAssist
	{
        private static readonly PopupAnchor DefaultPopupAnchor = PopupAnchor.TopLeft;
        private static readonly CornerRadius DefaultPopupCornerRadius = new CornerRadius(10);
        private static readonly PlacementMode DefaultPopupPlacement = PlacementMode.BottomEdgeAlignedLeft;
        public static readonly Thickness DefaultPopuBorderThickness = new Thickness(1);
        public static readonly SolidColorBrush DefaultPopuBorderBrush = new SolidColorBrush();

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

        #region AttachedProperty : PopupHorizontalOffsetProperty

        public static readonly AvaloniaProperty<double> PopupHorizontalOffsetProperty = AvaloniaProperty.RegisterAttached<MenuItem, double>(
            "PopupHorizontalOffset", typeof(MenuAssist), 0, true);

        public static double GetPopupHorizontalOffset(AvaloniaObject element)
        {
            return (double)element.GetValue(PopupHorizontalOffsetProperty);
        }

        public static void SetPopupHorizontalOffset(AvaloniaObject element, double value)
        {
            element.SetValue(PopupHorizontalOffsetProperty, value);
        }

        #endregion

        #region AttachedProperty : PopupVerticalOffsetProperty

        public static readonly AvaloniaProperty<double> PopupVerticalOffsetProperty = AvaloniaProperty.RegisterAttached<MenuItem, double>(
            "PopupVerticalOffset", typeof(MenuAssist), 0, true);

        public static double GetPopupVerticalOffset(AvaloniaObject element)
        {
            return (double)element.GetValue(PopupVerticalOffsetProperty);
        }

        public static void SetPopupVerticalOffset(AvaloniaObject element, double value)
        {
            element.SetValue(PopupVerticalOffsetProperty, value);
        }

        #endregion

        #region AttachedProperty : PopupCornerRadiusProperty

        public static readonly AvaloniaProperty<CornerRadius> PopupCornerRadiusProperty = AvaloniaProperty.RegisterAttached<MenuItem, CornerRadius>(
            "PopupCornerRadius", typeof(MenuAssist), DefaultPopupCornerRadius, true);

        public static CornerRadius GetPopupCornerRadius(AvaloniaObject element)
        {
            return (CornerRadius)element.GetValue(PopupCornerRadiusProperty);
        }

        public static void SetPopupCornerRadius(AvaloniaObject element, CornerRadius value)
        {
            element.SetValue(PopupCornerRadiusProperty, value);
        }

        #endregion

        #region AttachedProperty : PopupPlacementProperty

        public static readonly AvaloniaProperty<PlacementMode> PopupPlacementProperty = AvaloniaProperty.RegisterAttached<MenuItem, PlacementMode>(
            "PopupPlacement", typeof(MenuAssist), DefaultPopupPlacement, true);

        public static PlacementMode GetPopupPlacement(AvaloniaObject element)
        {
            return (PlacementMode)element.GetValue(PopupPlacementProperty);
        }

        public static void SetPopupPlacement(AvaloniaObject element, PlacementMode value)
        {
            element.SetValue(PopupPlacementProperty, value);
        }

        #endregion


        #region AttachedProperty : PopupBorderThicknessProperty

        public static readonly AvaloniaProperty<Thickness> PopupBorderThicknessProperty = AvaloniaProperty.RegisterAttached<MenuItem, Thickness>(
            "PopupBorderThickness", typeof(MenuAssist), DefaultPopuBorderThickness, true);

        public static Thickness GetPopupBorderThickness(AvaloniaObject element)
        {
            return (Thickness)element.GetValue(PopupBorderThicknessProperty);
        }

        public static void SetPopupBorderThickness(AvaloniaObject element, Thickness value)
        {
            element.SetValue(PopupBorderThicknessProperty, value);
        }

        #endregion

        #region AttachedProperty : PopupBorderBrushProperty

        public static readonly AvaloniaProperty<IBrush> PopupBorderBrushProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush>(
            "PopupBorderBrush", typeof(MenuAssist), DefaultPopuBorderBrush, true);

        public static IBrush GetPopupBorderBrush(AvaloniaObject element)
        {
            return (IBrush)element.GetValue(PopupBorderBrushProperty);
        }

        public static void SetPopupBorderBrush(AvaloniaObject element, IBrush value)
        {
            element.SetValue(PopupBorderBrushProperty, value);
        }

        #endregion
    }
}