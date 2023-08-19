using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    /// <summary>
    ///     Contains attached properties for <code>TabControl</code>.
    /// </summary>
    public static class TabControlAssist
    {
        /// <summary>
        ///     Use highlight colored stroke for the selected tab item header.
        /// </summary>
        public static readonly AvaloniaProperty<bool> UseHighlightStrokeProperty = AvaloniaProperty.RegisterAttached<TabItem, bool>(
            "UseHighlightStroke", typeof(TabControlAssist), false, true
        );


        /// <summary>
        ///     The highlight stroke color of the selected tab item header.
        /// </summary>
        public static readonly AvaloniaProperty<IBrush> HighlightStrokeBrushProperty = AvaloniaProperty.RegisterAttached<TabItem, IBrush>(
            "HighlightStrokeBrush", typeof(TabControlAssist), null, true
        );


        /// <summary>
        ///     The highlight stroke size of the selected tab item header.
        /// </summary>
        public static readonly AvaloniaProperty<double> HighlightStrokeSizeProperty = AvaloniaProperty.RegisterAttached<TabItem, double>(
            "HighlightStrokeSize", typeof(TabControlAssist), 6.0, true
        );


        /// <summary>
        ///     The height of the tab item header.
        /// </summary>
        public static readonly AvaloniaProperty<double> TabHeightProperty = AvaloniaProperty.RegisterAttached<TabItem, double>(
            "TabHeight", typeof(TabControlAssist), 42.0, true
        );


        /// <summary>
        ///     The height of the selected tab item header.
        /// </summary>
        public static readonly AvaloniaProperty<double> SelectedTabHeightProperty = AvaloniaProperty.RegisterAttached<TabItem, double>(
            "SelectedTabHeight", typeof(TabControlAssist), 52.0, true
        );





        /// <summary>
        ///     Gets the highlight stroke usage of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetUseHighlightStroke(AvaloniaObject element)
        {
            return (bool)element.GetValue(UseHighlightStrokeProperty);
        }

        /// <summary>
        ///     Sets the highlight stroke usage of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetUseHighlightStroke(AvaloniaObject element, bool value)
        {
            element.SetValue(UseHighlightStrokeProperty, value);
        }




        /// <summary>
        ///     Gets the highlight stroke color of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IBrush GetHighlightStrokeBrush(AvaloniaObject element) {
            return (IBrush) element.GetValue(HighlightStrokeBrushProperty);
        }

        /// <summary>
        ///     Sets the highlight stroke color of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetHighlightStrokeBrush(AvaloniaObject element, IBrush value) {
            element.SetValue(HighlightStrokeBrushProperty, value);
        }



        /// <summary>
        ///     Gets the highlight stroke size of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static double GetHighlightStrokeSize(AvaloniaObject element)
        {
            return (double)element.GetValue(HighlightStrokeSizeProperty);
        }

        /// <summary>
        ///     Sets the highlight stroke size of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetHighlightStrokeSize(AvaloniaObject element, double value)
        {
            element.SetValue(HighlightStrokeSizeProperty, value);
        }



        /// <summary>
        ///     Gets the height of the tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static double GetTabHeight(AvaloniaObject element)
        {
            return (double)element.GetValue(TabHeightProperty);
        }

        /// <summary>
        ///     Sets the height of the tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetTabHeight(AvaloniaObject element, double value)
        {
            element.SetValue(TabHeightProperty, value);
        }




        /// <summary>
        ///     Gets the height of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static double GetSelectedTabHeight(AvaloniaObject element)
        {
            return (double)element.GetValue(SelectedTabHeightProperty);
        }

        /// <summary>
        ///     Sets the height of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetSelectedTabHeight(AvaloniaObject element, double value)
        {
            element.SetValue(SelectedTabHeightProperty, value);
        }


    }
}