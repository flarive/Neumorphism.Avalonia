using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class TextFieldAssist
    {
        public static AvaloniaProperty<string> HintsProperty = AvaloniaProperty.RegisterAttached<TextBox, string>(
            "Hints", typeof(TextBox));
        
        public static void SetHints(AvaloniaObject element, string value) => element.SetValue(HintsProperty, value);

        public static string GetHints(AvaloniaObject element) => (string)element.GetValue(HintsProperty);

        
        
        public static AvaloniaProperty<string> LabelProperty = AvaloniaProperty.RegisterAttached<TextBox, string>(
            "Label", typeof(TextBox));

        public static void SetLabel(AvaloniaObject element, string value) => element.SetValue(LabelProperty, value);

        public static string GetLabel(AvaloniaObject element) => (string)element.GetValue(LabelProperty);

  



        public static AvaloniaProperty<IBrush> InnerLeftBackgroundProperty = AvaloniaProperty.RegisterAttached<TextBox, IBrush>(
            "InnerLeftBackground", typeof(TextBox));

        public static void SetInnerLeftBackground(AvaloniaObject element, IBrush value) => element.SetValue(InnerLeftBackgroundProperty, value);

        public static IBrush GetInnerLeftBackground(AvaloniaObject element) => (IBrush)element.GetValue(InnerLeftBackgroundProperty);



        public static AvaloniaProperty<Thickness> InnerLeftPaddingProperty = AvaloniaProperty.RegisterAttached<TextBox, Thickness>(
            "InnerLeftPadding", typeof(TextBox));

        public static void SetInnerLeftPadding(AvaloniaObject element, Thickness value) => element.SetValue(InnerLeftPaddingProperty, value);

        public static Thickness GetInnerLeftPadding(AvaloniaObject element) => (Thickness)element.GetValue(InnerLeftPaddingProperty);




        public static AvaloniaProperty<IBrush> InnerRightBackgroundProperty = AvaloniaProperty.RegisterAttached<TextBox, IBrush>(
            "InnerRightBackground", typeof(TextBox));

        public static void SetInnerRightBackground(AvaloniaObject element, IBrush value) => element.SetValue(InnerRightBackgroundProperty, value);

        public static IBrush GetInnerRightBackground(AvaloniaObject element) => (IBrush)element.GetValue(InnerRightBackgroundProperty);




        public static AvaloniaProperty<Thickness> InnerRightPaddingProperty = AvaloniaProperty.RegisterAttached<TextBox, Thickness>(
            "InnerRightPadding", typeof(TextBox));

        public static void SetInnerRightPadding(AvaloniaObject element, Thickness value) => element.SetValue(InnerRightPaddingProperty, value);

        public static Thickness GetInnerRightPadding(AvaloniaObject element) => (Thickness)element.GetValue(InnerRightPaddingProperty);

    }
}