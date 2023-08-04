using Avalonia.Controls.Primitives;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class ThumbAssist
    {
        #region AttachedProperty
        
        public static readonly AvaloniaProperty<bool> ValueTooltipProperty = AvaloniaProperty.RegisterAttached<Thumb, bool>(
           "ValueTooltip", typeof(ThumbAssist), false, true);

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