using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Assist
{
    /// <summary>
    ///     Contains attached properties for <code>TabControl</code>.
    /// </summary>
    public static class TabControlAssist
    {
        /// <summary>
        ///     The alignment of the horizontal tab headers in the <code>TabControl</code>.
        /// </summary>
        public static readonly AttachedProperty<HorizontalAlignment> TabHeaderHorizontalAlignmentProperty =
            AvaloniaProperty.RegisterAttached<TabControl, HorizontalAlignment>(
                "TabHeaderHorizontalAlignment", typeof(TabControlAssist), HorizontalAlignment.Left, true
            );

        /// <summary>
        ///     The alignment of the vertical tab headers in the <code>TabControl</code>.
        /// </summary>
        public static readonly AttachedProperty<VerticalAlignment> TabHeaderVerticalAlignmentProperty =
            AvaloniaProperty.RegisterAttached<TabControl, VerticalAlignment>(
                "TabHeaderVerticalAlignment", typeof(TabControlAssist), VerticalAlignment.Top, true
            );


        /// <summary>
        ///     Use highlight color for the selected tab item header.
        /// </summary>
        public static readonly AvaloniaProperty<bool> HighlightSelectedItemProperty = AvaloniaProperty.RegisterAttached<TabItem, bool>(
            "HighlightSelectedItem", typeof(TabControlAssist), false, true
        );


        /// <summary>
        ///     The highlight color of the selected tab item header.
        /// </summary>
        public static readonly AvaloniaProperty<IBrush> HighlightBrushProperty = AvaloniaProperty.RegisterAttached<TabItem, IBrush>(
            "HighlightBrush", typeof(TabControlAssist), null, true
        );



        /// <summary>
        ///     Gets the alignment of the horizontal tab headers in the <code>TabControl</code>.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static HorizontalAlignment GetTabHeaderHorizontalAlignment(AvaloniaObject element) {
            return element.GetValue(TabHeaderHorizontalAlignmentProperty);
        }

        /// <summary>
        ///     Sets the alignment of the horizontal tab headers in the <code>TabControl</code>.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetTabHeaderHorizontalAlignment(AvaloniaObject element, HorizontalAlignment value) {
            element.SetValue(TabHeaderHorizontalAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets the alignment of the vertical tab headers in the <code>TabControl</code>.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static VerticalAlignment GetTabHeaderVerticalAlignment(AvaloniaObject element) {
            return element.GetValue(TabHeaderVerticalAlignmentProperty);
        }

        /// <summary>
        ///     Sets the alignment of the vertical tab headers in the <code>TabControl</code>.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetTabHeaderVerticalAlignment(AvaloniaObject element, VerticalAlignment value) {
            element.SetValue(TabHeaderVerticalAlignmentProperty, value);
        }


        /// <summary>
        ///     Gets the highlight status of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetHighlightSelectedItem(AvaloniaObject element)
        {
            return (bool)element.GetValue(HighlightSelectedItemProperty);
        }

        /// <summary>
        ///     Sets the highlight status of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetHighlightSelectedItem(AvaloniaObject element, bool value)
        {
            element.SetValue(HighlightSelectedItemProperty, value);
        }




        /// <summary>
        ///     Gets the highlight color of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IBrush GetHighlightBrush(AvaloniaObject element) {
            return (IBrush) element.GetValue(HighlightBrushProperty);
        }

        /// <summary>
        ///     Sets the highlight color of the selected tab item header.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetHighlightBrush(AvaloniaObject element, IBrush value) {
            element.SetValue(HighlightBrushProperty, value);
        }


    }
}