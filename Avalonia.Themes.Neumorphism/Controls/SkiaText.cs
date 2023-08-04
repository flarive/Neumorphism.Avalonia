using Avalonia.Media;
using System.Globalization;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public sealed class SkiaText : SkiaShape
    {
        /// <summary>
        /// Defines the <see cref="Text"/> property.
        /// </summary>
        public static readonly StyledProperty<string> TextProperty =
            AvaloniaProperty.Register<SkiaShape, string>(nameof(Text));

        /// <summary>
        /// Gets or sets the text of the SkiaText.
        /// </summary>
        public string Text
        {
            get { return GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }



        /// <summary>
        /// Defines the <see cref="FontFamily"/> property.
        /// </summary>
        public static readonly StyledProperty<string> FontFamilyProperty =
            AvaloniaProperty.Register<SkiaShape, string>(nameof(FontFamily));

        /// <summary>
        /// Gets or sets the font family of the SkiaText.
        /// </summary>
        public string FontFamily
        {
            get { return GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }



        /// <summary>
        /// Defines the <see cref="FontFamily"/> property.
        /// </summary>
        public static readonly StyledProperty<double> FontSizeProperty =
            AvaloniaProperty.Register<SkiaShape, double>(nameof(FontSize));

        /// <summary>
        /// Gets or sets the font size of the SkiaText.
        /// </summary>
        public double FontSize
        {
            get { return GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }


        static SkiaText()
        {
            AffectsGeometry<SkiaText>(BoundsProperty, StrokeThicknessProperty);
        }

        protected override Geometry CreateDefiningGeometry()
        {
            return new FormattedText(Text, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface(new FontFamily(FontFamily)), FontSize, Fill).BuildGeometry(new Point(0, 0));
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var strokeThickness = StrokeThickness;
            return new Size(strokeThickness, strokeThickness);
        }
    }
}
