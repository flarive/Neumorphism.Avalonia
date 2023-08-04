using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public class SkiaControl : Control
    {
        /// <summary>
        /// Defines the <see cref="Blur"/> property.
        /// </summary>
        public static readonly StyledProperty<double> BlurProperty =
            AvaloniaProperty.Register<SkiaControl, double>(nameof(Blur));

        /// <summary>
        /// Defines the <see cref="BoxShadow"/> property.
        /// </summary>
        public static readonly StyledProperty<BoxShadows> BoxShadowProperty =
            AvaloniaProperty.Register<SkiaControl, BoxShadows>(nameof(BoxShadow));



        static SkiaControl()
        {
            AffectsRender<SkiaControl>(BlurProperty, BoxShadowProperty);
        }

        public double Blur
        {
            get { return GetValue(BlurProperty); }
            set { SetValue(BlurProperty, value); }
        }

        public BoxShadows BoxShadow
        {
            get { return GetValue(BoxShadowProperty); }
            set { SetValue(BoxShadowProperty, value); }
        }

        public static float BlurRadiusToSigma(double radius)
        {
            if (radius <= 0)
                return 0.0f;
            return (float)radius / 3.0f; //0.288675f * (float)radius + 0.5f;
        }
    }
}
