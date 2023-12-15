using Avalonia.Media;
using Avalonia.Themes.Neumorphism.Controls;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class SnackbarHostAssist
    {
        private static readonly CornerRadius DefaultSnackbarCornerRadius = new CornerRadius(10);
        private static readonly IBrush DefaultSnackbarBackground = new SolidColorBrush(Brushes.Transparent.Color);
        private static readonly double DefaultSnackbarWidth = 344;
        private static readonly double DefaultSnackbarHeight = 200;
        private static readonly double DefaultSnackbarVerticalOffset = 50;
        private static readonly bool DefaultSnackbarIsAnimated = false;
        


        #region AttachedProperty

        /// <summary>
        /// Controls the corner radius of the snackbar.
        /// </summary>
        public static readonly AvaloniaProperty<CornerRadius> SnackbarCornerRadiusProperty = AvaloniaProperty.RegisterAttached<SnackbarHost, CornerRadius>(
            "SnackbarCornerRadius", typeof(SnackbarHostAssist), DefaultSnackbarCornerRadius, true);

        public static CornerRadius GetSnackbarCornerRadius(AvaloniaObject element) {
            return (CornerRadius) element.GetValue(SnackbarCornerRadiusProperty);
        }

        public static void SetSnackbarCornerRadius(AvaloniaObject element, CornerRadius value) {
            element.SetValue(SnackbarCornerRadiusProperty, value);
        }





        /// <summary>
        /// Controls the background color of the snackbar.
        /// </summary>
        public static readonly AvaloniaProperty<IBrush> SnackbarBackgroundProperty = AvaloniaProperty.RegisterAttached<SnackbarHost, IBrush>(
            "SnackbarBackground", typeof(SnackbarHostAssist), DefaultSnackbarBackground, true);

        public static IBrush GetSnackbarBackground(AvaloniaObject element)
        {
            return (IBrush)element.GetValue(SnackbarBackgroundProperty);
        }

        public static void SetSnackbarBackground(AvaloniaObject element, IBrush value) {
            element.SetValue(SnackbarBackgroundProperty, value);
        }



        /// <summary>
        /// Controls the width of the snackbar.
        /// </summary>
        public static readonly AvaloniaProperty<double> SnackbarWidthProperty = AvaloniaProperty.RegisterAttached<SnackbarHost, double>(
            "SnackbarWidth", typeof(SnackbarHostAssist), DefaultSnackbarWidth, true);

        public static double GetSnackbarWidth(AvaloniaObject element)
        {
            return (double)element.GetValue(SnackbarWidthProperty);
        }

        public static void SetSnackbarWidth(AvaloniaObject element, double value)
        {
            element.SetValue(SnackbarWidthProperty, value);
        }



        /// <summary>
        /// Controls the height of the snackbar.
        /// </summary>
        public static readonly AvaloniaProperty<double> SnackbarHeightProperty = AvaloniaProperty.RegisterAttached<SnackbarHost, double>(
            "SnackbarHeight", typeof(SnackbarHostAssist), DefaultSnackbarHeight, true);

        public static double GetSnackbarHeight(AvaloniaObject element)
        {
            return (double)element.GetValue(SnackbarHeightProperty);
        }

        public static void SetSnackbarHeight(AvaloniaObject element, double value)
        {
            element.SetValue(SnackbarHeightProperty, value);
        }




        /// <summary>
        /// Controls the vertical offet of the snackbar.
        /// </summary>
        public static readonly AvaloniaProperty<double> SnackbarVerticalOffsetProperty = AvaloniaProperty.RegisterAttached<SnackbarHost, double>(
            "SnackbarVerticalOffset", typeof(SnackbarHostAssist), DefaultSnackbarVerticalOffset, true);

        public static double GetSnackbarVerticalOffset(AvaloniaObject element)
        {
            return (double)element.GetValue(SnackbarVerticalOffsetProperty);
        }

        public static void SetSnackbarVerticalOffset(AvaloniaObject element, double value)
        {
            element.SetValue(SnackbarVerticalOffsetProperty, value);
        }



        /// <summary>
        /// Controls if snackbar notifications are animated or not.
        /// </summary>
        public static readonly AvaloniaProperty<bool> SnackbarIsAnimatedProperty = AvaloniaProperty.RegisterAttached<SnackbarHost, bool>(
            "SnackbarIsAnimated", typeof(SnackbarHostAssist), DefaultSnackbarIsAnimated, true);

        public static bool GetSnackbarIsAnimated(AvaloniaObject element)
        {
            return (bool)element.GetValue(SnackbarIsAnimatedProperty);
        }

        public static void SetSnackbarIsAnimated(AvaloniaObject element, bool value)
        {
            element.SetValue(SnackbarIsAnimatedProperty, value);
        }

        #endregion
    }
}