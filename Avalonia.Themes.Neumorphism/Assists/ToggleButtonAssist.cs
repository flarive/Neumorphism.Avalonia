using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class ToggleButtonAssist
    {
        public static readonly AvaloniaProperty<IBrush> UncheckedForegroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush>(
            "UncheckedForeground", typeof(ToggleButtonAssist));
        
        public static void SetUncheckedForeground(AvaloniaObject element, IBrush value) {
            element.SetValue(UncheckedForegroundProperty, value);
        }

        public static IBrush GetUncheckedForeground(AvaloniaObject element) {
            return (IBrush) element.GetValue(UncheckedForegroundProperty);
        }
        
        public static readonly AvaloniaProperty<IBrush> UncheckedBackgroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush>(
            "UncheckedBackground", typeof(ToggleButtonAssist));
        
        public static void SetUncheckedBackground(AvaloniaObject element, IBrush value) {
            element.SetValue(UncheckedBackgroundProperty, value);
        }

        public static IBrush GetUncheckedBackground(AvaloniaObject element) {
            return (IBrush) element.GetValue(UncheckedBackgroundProperty);
        }




        public static readonly AvaloniaProperty<IBrush> CheckedForegroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush>(
           "CheckedForeground", typeof(ToggleButtonAssist));

        public static void SetCheckedForeground(AvaloniaObject element, IBrush value)
        {
            element.SetValue(CheckedForegroundProperty, value);
        }

        public static IBrush GetCheckedForeground(AvaloniaObject element)
        {
            return (IBrush)element.GetValue(CheckedForegroundProperty);
        }



        public static readonly AvaloniaProperty<IBrush> CheckedBackgroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush>(
            "CheckedBackground", typeof(ToggleButtonAssist));

        public static void SetCheckedBackground(AvaloniaObject element, IBrush value)
        {
            element.SetValue(CheckedBackgroundProperty, value);
        }

        public static IBrush GetCheckedBackground(AvaloniaObject element)
        {
            return (IBrush)element.GetValue(CheckedBackgroundProperty);
        }
    }
}