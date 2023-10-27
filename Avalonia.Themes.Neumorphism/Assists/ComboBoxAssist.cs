using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public sealed class ComboBoxAssist
    {
        public static readonly AvaloniaProperty<object> WatermarkContentProperty = AvaloniaProperty.RegisterAttached<ComboBox, object>(
           "WatermarkContent", typeof(ComboBoxAssist), null, true);

        public static object GetWatermarkContent(AvaloniaObject element)
        {
            return (object)element.GetValue(WatermarkContentProperty);
        }

        public static void SetWatermarkContent(AvaloniaObject element, object value)
        {
            element.SetValue(WatermarkContentProperty, value);
        }





        public static AvaloniaProperty<bool> UseFloatingWatermarkProperty = AvaloniaProperty.RegisterAttached<ComboBox, bool>("UseFloatingWatermark", typeof(ComboBoxAssist));

        public static void SetUseFloatingWatermark(AvaloniaObject element, bool value) => element.SetValue(UseFloatingWatermarkProperty, value);

        public static bool GetUseFloatingWatermark(AvaloniaObject element) => (bool)element.GetValue(UseFloatingWatermarkProperty);



        public static readonly AvaloniaProperty<object> InnerLeftContentProperty = AvaloniaProperty.RegisterAttached<ComboBox, object>(
            "InnerLeftContent", typeof(ComboBoxAssist), null, true);

        public static object GetInnerLeftContent(AvaloniaObject element)
        {
            return (object)element.GetValue(InnerLeftContentProperty);
        }

        public static void SetInnerLeftContent(AvaloniaObject element, object value)
        {
            element.SetValue(InnerLeftContentProperty, value);
        }



        public static AvaloniaProperty<IBrush> InnerLeftBackgroundProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush>(
            "InnerLeftBackground", typeof(ComboBoxAssist));

        public static void SetInnerLeftBackground(AvaloniaObject element, IBrush value) => element.SetValue(InnerLeftBackgroundProperty, value);

        public static IBrush GetInnerLeftBackground(AvaloniaObject element) => (IBrush)element.GetValue(InnerLeftBackgroundProperty);



        public static AvaloniaProperty<Thickness> InnerLeftPaddingProperty = AvaloniaProperty.RegisterAttached<ComboBox, Thickness>(
            "InnerLeftPadding", typeof(ComboBoxAssist));

        public static void SetInnerLeftPadding(AvaloniaObject element, Thickness value) => element.SetValue(InnerLeftPaddingProperty, value);

        public static Thickness GetInnerLeftPadding(AvaloniaObject element) => (Thickness)element.GetValue(InnerLeftPaddingProperty);



        public static readonly AvaloniaProperty<object> InnerRightContentProperty = AvaloniaProperty.RegisterAttached<ComboBox, object>(
           "InnerRightContent", typeof(ComboBoxAssist), null, true);

        public static object GetInnerRightContent(AvaloniaObject element)
        {
            return (object)element.GetValue(InnerRightContentProperty);
        }

        public static void SetInnerRightContent(AvaloniaObject element, object value)
        {
            element.SetValue(InnerRightContentProperty, value);
        }



        public static AvaloniaProperty<IBrush> InnerRightBackgroundProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush>(
            "InnerRightBackground", typeof(ComboBoxAssist));

        public static void SetInnerRightBackground(AvaloniaObject element, IBrush value) => element.SetValue(InnerRightBackgroundProperty, value);

        public static IBrush GetInnerRightBackground(AvaloniaObject element) => (IBrush)element.GetValue(InnerRightBackgroundProperty);


        public static AvaloniaProperty<Thickness> InnerRightPaddingProperty = AvaloniaProperty.RegisterAttached<ComboBox, Thickness>(
            "InnerRightPadding", typeof(ComboBoxAssist));

        public static void SetInnerRightPadding(AvaloniaObject element, Thickness value) => element.SetValue(InnerRightPaddingProperty, value);

        public static Thickness GetInnerRightPadding(AvaloniaObject element) => (Thickness)element.GetValue(InnerRightPaddingProperty);
    }
}