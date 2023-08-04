using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public sealed class SkiaGeometry : SkiaShape
    {
        /// <summary>
        /// Defines the <see cref="Path"/> property.
        /// </summary>
        public static readonly StyledProperty<string> PathProperty =
            AvaloniaProperty.Register<SkiaShape, string>(nameof(Path));



        /// <summary>
        /// Gets or sets the path of the SkiaGeometry outline.
        /// </summary>
        public string Path
        {
            get { return GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }



        static SkiaGeometry()
        {
            AffectsGeometry<SkiaGeometry>(BoundsProperty, StrokeThicknessProperty);
        }

        protected override Geometry CreateDefiningGeometry()
        {
            if (!string.IsNullOrEmpty(Path))
            {
                return StreamGeometry.Parse(Path);
            }

            return new StreamGeometry();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var strokeThickness = StrokeThickness;
            return new Size(strokeThickness, strokeThickness);
        }
    }
}
