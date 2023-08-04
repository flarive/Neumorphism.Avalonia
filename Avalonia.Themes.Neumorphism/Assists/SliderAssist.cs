using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class SliderAssist
    {
        //private static readonly double DefaultThicknessTick = 1.0;
        //private static readonly double DefaultSizeTick = 1.0;

        #region AttachedProperty
        
        //public static readonly AvaloniaProperty<double> ThicknessTickProperty = AvaloniaProperty.RegisterAttached<Slider, double>(
        //    "ThicknessTick", typeof(SliderAssist), DefaultThicknessTick, true);

        //public static double GetThicknessTick(AvaloniaObject element) {
        //    return (double) element.GetValue(ThicknessTickProperty);
        //}

        //public static void SetThicknessTick(AvaloniaObject element, double value) {
        //    element.SetValue(ThicknessTickProperty, value);
        //}
        
        
        //public static readonly AvaloniaProperty<double> SizeTickProperty = AvaloniaProperty.RegisterAttached<Slider, double>(
        //    "SizeTick", typeof(SliderAssist), DefaultSizeTick, true);

        //public static double GetSizeTick(AvaloniaObject element) {
        //    return (double) element.GetValue(SizeTickProperty);
        //}

        //public static void SetSizeTick(AvaloniaObject element, double value) {
        //    element.SetValue(SizeTickProperty, value);
        //}


        public static readonly AvaloniaProperty<IBrush> ThumbForegroundProperty = AvaloniaProperty.RegisterAttached<Slider, IBrush>(
           "ThumbForeground", typeof(SliderAssist), null, true);

        public static void SetThumbForeground(AvaloniaObject element, IBrush value)
        {
            element.SetValue(ThumbForegroundProperty, value);
        }

        public static IBrush GetThumbForeground(AvaloniaObject element)
        {
            return (IBrush)element.GetValue(ThumbForegroundProperty);
        }


        public static readonly AvaloniaProperty<object> ThumbContentProperty = AvaloniaProperty.RegisterAttached<Slider, object>(
            "ThumbContent", typeof(SliderAssist), null, true);

        public static object GetThumbContent(AvaloniaObject element)
        {
            return (object)element.GetValue(ThumbContentProperty);
        }

        public static void SetThumbContent(AvaloniaObject element, object value)
        {
            element.SetValue(ThumbContentProperty, value);
        }



        public static readonly AvaloniaProperty<bool> ValueTooltipProperty = AvaloniaProperty.RegisterAttached<Slider, bool>(
           "ValueTooltip", typeof(SliderAssist), false, true);

        public static void SetValueTooltip(AvaloniaObject element, bool value)
        {
            element.SetValue(ValueTooltipProperty, value);
        }

        public static bool GetValueTooltip(AvaloniaObject element)
        {
            return (bool)element.GetValue(ValueTooltipProperty);
        }


        #endregion
    }
}