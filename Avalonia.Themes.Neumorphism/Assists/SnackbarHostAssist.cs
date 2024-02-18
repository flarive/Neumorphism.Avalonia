using Avalonia.Media;
using Avalonia.Themes.Neumorphism.Controls;

namespace Avalonia.Themes.Neumorphism.Assist
{
    public static class SnackbarHostAssist
    {
        private static readonly CornerRadius DefaultSnackbarCornerRadius = new CornerRadius(10);
        private static readonly IBrush DefaultSnackbarBackground = new SolidColorBrush(Brushes.Transparent.Color);
        private static readonly double DefaultSnackbarVerticalOffset = 50;

        


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

        #endregion
    }
}