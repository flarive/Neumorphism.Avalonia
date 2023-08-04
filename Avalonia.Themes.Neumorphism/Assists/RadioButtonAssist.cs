using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class RadioButtonAssist
    {
        public static readonly AvaloniaProperty<IBrush> UncheckedForegroundProperty = AvaloniaProperty.RegisterAttached<RadioButton, IBrush>(
            "UncheckedForeground", typeof(RadioButtonAssist));
        
        public static void SetUncheckedForeground(AvaloniaObject element, IBrush value) {
            element.SetValue(UncheckedForegroundProperty, value);
        }

        public static IBrush GetUncheckedForeground(AvaloniaObject element) {
            return (IBrush) element.GetValue(UncheckedForegroundProperty);
        }
        
        public static readonly AvaloniaProperty<IBrush> UncheckedBackgroundProperty = AvaloniaProperty.RegisterAttached<RadioButton, IBrush>(
            "UncheckedBackground", typeof(RadioButtonAssist));
        
        public static void SetUncheckedBackground(AvaloniaObject element, IBrush value) {
            element.SetValue(UncheckedBackgroundProperty, value);
        }

        public static IBrush GetUncheckedBackground(AvaloniaObject element) {
            return (IBrush) element.GetValue(UncheckedBackgroundProperty);
        }




        public static readonly AvaloniaProperty<IBrush> CheckedForegroundProperty = AvaloniaProperty.RegisterAttached<RadioButton, IBrush>(
           "CheckedForeground", typeof(RadioButtonAssist));

        public static void SetCheckedForeground(AvaloniaObject element, IBrush value)
        {
            element.SetValue(CheckedForegroundProperty, value);
        }

        public static IBrush GetCheckedForeground(AvaloniaObject element)
        {
            return (IBrush)element.GetValue(CheckedForegroundProperty);
        }



        public static readonly AvaloniaProperty<IBrush> CheckedBackgroundProperty = AvaloniaProperty.RegisterAttached<RadioButton, IBrush>(
            "CheckedBackground", typeof(RadioButtonAssist));

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