using Avalonia.Media;
using Avalonia.Media.Immutable;
using Avalonia.Skia;
using Avalonia.Reactive;
using SkiaSharp;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public abstract partial class SkiaShape : SkiaControl
    {
        /// <summary>
         /// Defines the <see cref="Fill"/> property.
         /// </summary>
        public static readonly StyledProperty<IBrush> FillProperty =
            AvaloniaProperty.Register<SkiaShape, IBrush>(nameof(Fill));

        /// <summary>
        /// Defines the <see cref="Stretch"/> property.
        /// </summary>
        public static readonly StyledProperty<Stretch> StretchProperty =
            AvaloniaProperty.Register<SkiaShape, Stretch>(nameof(Stretch));

        /// <summary>
        /// Defines the <see cref="Stroke"/> property.
        /// </summary>
        public static readonly StyledProperty<IBrush> StrokeProperty =
            AvaloniaProperty.Register<SkiaShape, IBrush>(nameof(Stroke));

        /// <summary>
        /// Defines the <see cref="StrokeThickness"/> property.
        /// </summary>
        public static readonly StyledProperty<double> StrokeThicknessProperty =
            AvaloniaProperty.Register<SkiaShape, double>(nameof(StrokeThickness));




        private Matrix _transform = Matrix.Identity;
        private Geometry _definingGeometry;
        private Geometry _renderedGeometry;

        static SkiaShape()
        {
            AffectsMeasure<SkiaShape>(StretchProperty, StrokeThicknessProperty);

            AffectsRender<SkiaShape>(FillProperty, StrokeProperty,
                StrokeThicknessProperty);
        }

        /// <summary>
        /// Gets a value that represents the <see cref="Geometry"/> of the SkiaShape.
        /// </summary>
        public Geometry DefiningGeometry
        {
            get
            {
                if (_definingGeometry == null)
                {
                    _definingGeometry = CreateDefiningGeometry();
                }

                return _definingGeometry;
            }
        }

        /// <summary>
        /// Gets a value that represents the final rendered <see cref="Geometry"/> of the SkiaShape.
        /// </summary>
        public Geometry RenderedGeometry
        {
            get
            {
                if (_renderedGeometry == null && DefiningGeometry != null)
                {
                    if (_transform == Matrix.Identity)
                    {
                        _renderedGeometry = DefiningGeometry;
                    }
                    else
                    {
                        _renderedGeometry = DefiningGeometry.Clone();

                        if (_renderedGeometry.Transform == null ||
                            _renderedGeometry.Transform.Value == Matrix.Identity)
                        {
                            _renderedGeometry.Transform = new MatrixTransform(_transform);
                        }
                        else
                        {
                            _renderedGeometry.Transform = new MatrixTransform(
                                _renderedGeometry.Transform.Value * _transform);
                        }
                    }
                }

                return _renderedGeometry;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IBrush"/> that specifies how the SkiaShape's interior is painted.
        /// </summary>
        public IBrush Fill
        {
            get { return GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        /// <summary>
        /// Gets or sets a <see cref="Stretch"/> enumeration value that describes how the SkiaShape fills its allocated space.
        /// </summary>
        public Stretch Stretch
        {
            get { return GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        /// <summary>
        /// Gets or sets the <see cref="IBrush"/> that specifies how the SkiaShape's outline is painted.
        /// </summary>
        public IBrush Stroke
        {
            get { return GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the width of the SkiaShape outline.
        /// </summary>
        public double StrokeThickness
        {
            get { return GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }





        public sealed override void Render(DrawingContext context)
        {
            var geometry = RenderedGeometry;

            if (geometry != null)
            {
                var stroke = Stroke;

                ImmutablePen pen = null;

                if (stroke != null)
                {
                    pen = new ImmutablePen(
                        stroke.ToImmutable(),
                        StrokeThickness);
                }
                //context.DrawGeometry(Fill, pen, geometry);
               
                // I only use the first BoxShadow... 
                context.Custom(new ShapeCustomDrawOperation(geometry, new Rect(Bounds.Size), Blur, BoxShadow)
                {
                    Pen = pen,
                    Brush = Fill,
                    Opacity = (float)this.Opacity,
                });

            }
        }

        public sealed class ShapeCustomDrawOperation : CustomDrawOperation
        {
            private readonly SKPath _strokePath;
            //private readonly IGeometryImpl _impl;
            private readonly Size _size;

            public Geometry Geometry { get; set; }

            public ImmutablePen Pen { get; set; }

            public IBrush Brush { get; set; }

            public ShapeCustomDrawOperation(Geometry geometry, Rect bounds, double blurRadius, BoxShadows shadows) : base(bounds, blurRadius, shadows)
            {
                Geometry = geometry;
                // When the platform implementation is created properties of the mutable geometry are read.
                // This is only allowed on the ui thread. The custom draw op is executed on the render thread.
                //_impl = geometry.PlatformImpl;
                _size = geometry.Bounds.Size;
                _strokePath = GetStrokePath(geometry);
            }

            private static PropertyInfo s_geometryPlatformImpl;

            public static SKPath GetFillPath(Geometry geometry)
            {
                s_geometryPlatformImpl ??= typeof(Geometry).GetProperty("PlatformImpl", BindingFlags.NonPublic | BindingFlags.Instance);
                Debug.Assert(s_geometryPlatformImpl is not null);
                var platformImpl = s_geometryPlatformImpl.GetValue(geometry);
                var s_geometryPlatformImplFillPath = platformImpl.GetType().GetProperty("FillPath");
                Debug.Assert(s_geometryPlatformImplFillPath is not null);
                return s_geometryPlatformImplFillPath.GetValue(platformImpl) as SKPath;
            }
            public static SKPath GetStrokePath(Geometry geometry)
            {
                s_geometryPlatformImpl ??= typeof(Geometry).GetProperty("PlatformImpl", BindingFlags.NonPublic | BindingFlags.Instance);
                Debug.Assert(s_geometryPlatformImpl is not null);
                var platformImpl = s_geometryPlatformImpl.GetValue(geometry);
                Debug.Assert(platformImpl is not null);
                var s_geometryPlatformImplStrokePath = platformImpl.GetType().GetProperty("StrokePath");
                Debug.Assert(s_geometryPlatformImplStrokePath is not null);
                return s_geometryPlatformImplStrokePath.GetValue(platformImpl) as SKPath;
            }


            public override bool HitTest(Point p)
            {
                return base.HitTest(p) && Geometry?.FillContains(p) != false;
            }

            protected override void RenderCore(SKCanvas canvas)
            {
                if (_strokePath is null)
                    return;

                canvas.Save();

                //if (NeedsPaint())
                //{
                using (SKPaint paint = new SKPaint())
                {
                    paint.Color = new SKColor(255, 255, 255, (byte)(255 * Opacity));

                    if (ColorFilter is not null)
                        paint.ColorFilter = ColorFilter;

                    if (Blur > 0)
                    {
                        paint.ImageFilter = SKImageFilter.CreateBlur(Blur, Blur, paint.ImageFilter);
                    }

                    if (Shadows is BoxShadows shadows)
                    {
                        //BoxShadow shadow = shadows[0];

                        foreach (BoxShadow shadow in  shadows)
                        {
                            float blur = BlurRadiusToSigma((float)shadow.Blur);
                            paint.ImageFilter = SKImageFilter.CreateDropShadow((float)shadow.OffsetX, (float)shadow.OffsetY, blur, blur, shadow.Color.ToSKColor(), paint.ImageFilter);
                        }

                        //float blur = BlurRadiusToSigma((float)shadow.Blur);
                        //paint.ImageFilter = SKImageFilter.CreateDropShadow((float)shadow.OffsetX, (float)shadow.OffsetY, blur, blur, shadow.Color.ToSKColor(), paint.ImageFilter);
                    }

                    if (BlendMode is not null && BlendMode.Value != SKBlendMode.SrcOver)
                    {
                        paint.BlendMode = BlendMode.Value;
                    }

                    SKPicture picture;

                    using (var recorder = new SKPictureRecorder())
                    {
                        var cullRect = UnmodifiedBounds;

                        using (var recordingCanvas = recorder.BeginRecording(cullRect.ToSKRect()))
                        {
                            DrawShape(recordingCanvas);
                        }
                        picture = recorder.EndRecording();
                    }

                    canvas.DrawPicture(picture, paint);
                }
                //}
                //else
                //{
                //    DrawShape(canvas);
                //}

                canvas.Restore();
            }

            private double GetStrokeThickness()
            {
                if (Pen is { } pen && pen.Brush is not null)
                    return pen.Thickness;
                return 0;
            }

            private void DrawShape(SKCanvas canvas)
            {
                var geometry = Geometry!;

                if (Brush is { } brush)
                {
                    if (_strokePath/*_impl.GetType().GetProperty("FillPath").GetValue(_impl)*/ is SKPath fillPath)
                    {
                        using (var fill = CreatePaint(Brush, _size))
                        {
                            canvas.DrawPath(fillPath, fill);
                        }
                    }
                }

                if (Pen is { } pen &&
                    _strokePath is not null/*_impl.GetType().GetProperty("StrokePath").GetValue(_impl) is SKPath strokePath*/ &&
                    TryCreatePaint(pen, _size.Inflate(new Thickness(pen.Thickness / 2))) is { } stroke)
                {
                    using (stroke)
                    {
                        canvas.DrawPath(_strokePath, stroke);
                    }
                }
            }

            /// <summary>
            /// Creates paint wrapper for given brush.
            /// </summary>
            /// <param name="paint">The paint to wrap.</param>
            /// <param name="brush">Source brush.</param>
            /// <param name="targetSize">Target size.</param>
            /// <returns>Paint wrapper for given brush.</returns>
            internal SKPaint CreatePaint(IBrush brush, Size targetSize)
            {
                var paint = new SKPaint();
                paint.IsAntialias = true;

                double opacity = brush.Opacity;// * (_useOpacitySaveLayer ? 1 : _currentOpacity);

                if (brush is ISolidColorBrush solid)
                {
                    paint.Color = new SKColor(solid.Color.R, solid.Color.G, solid.Color.B, (byte)(solid.Color.A * opacity));

                    return paint;
                }

                throw new NotImplementedException();
            }

            private SKPaint TryCreatePaint(IPen pen, Size targetSize)
            {
                // In Skia 0 thickness means - use hairline rendering
                // and for us it means - there is nothing rendered.
                if (pen.Brush is not { } brush || pen.Thickness == 0d)
                {
                    return null;
                }

                var paint = CreatePaint(brush, targetSize);

                paint.IsStroke = true;
                paint.StrokeWidth = (float)pen.Thickness;
                /*
                // Need to modify dashes due to Skia modifying their lengths
                // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/paths/dots
                // TODO: Still something is off, dashes are now present, but don't look the same as D2D ones.

                switch (pen.LineCap)
                {
                    case PenLineCap.Round:
                        paint.StrokeCap = SKStrokeCap.Round;
                        break;
                    case PenLineCap.Square:
                        paint.StrokeCap = SKStrokeCap.Square;
                        break;
                    default:
                        paint.StrokeCap = SKStrokeCap.Butt;
                        break;
                }

                switch (pen.LineJoin)
                {
                    case PenLineJoin.Miter:
                        paint.StrokeJoin = SKStrokeJoin.Miter;
                        break;
                    case PenLineJoin.Round:
                        paint.StrokeJoin = SKStrokeJoin.Round;
                        break;
                    default:
                        paint.StrokeJoin = SKStrokeJoin.Bevel;
                        break;
                }

                paint.StrokeMiter = (float) pen.MiterLimit;

                if (pen.DashStyle?.Dashes != null && pen.DashStyle.Dashes.Count > 0)
                {
                    var srcDashes = pen.DashStyle.Dashes;

                    var count = srcDashes.Count % 2 == 0 ? srcDashes.Count : srcDashes.Count * 2;

                    var dashesArray = new float[count];

                    for (var i = 0; i < count; ++i)
                    {
                        dashesArray[i] = (float) srcDashes[i % srcDashes.Count] * paint.StrokeWidth;
                    }

                    var offset = (float) (pen.DashStyle.Offset * pen.Thickness);

                    var pe = SKPathEffect.CreateDash(dashesArray, offset);

                    paint.PathEffect = pe;
                    rv.AddDisposable(pe);
                }
                */
                return paint;
            }
        }

        /// <summary>
        /// Marks a property as affecting the SkiaShape's geometry.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <remarks>
        /// After a call to this method in a control's static constructor, any change to the
        /// property will cause <see cref="InvalidateGeometry"/> to be called on the element.
        /// </remarks>
        protected static void AffectsGeometry<TShape>(params AvaloniaProperty[] properties)
            where TShape : SkiaShape
        {
            foreach (var property in properties)
            {
                property.Changed.Subscribe(e =>
                {
                    if (e.Sender is TShape shape)
                    {
                        AffectsGeometryInvalidate(shape, e);
                    }
                });
            }
        }

        /// <summary>
        /// Creates the SkiaShape's defining geometry.
        /// </summary>
        /// <returns>Defining <see cref="Geometry"/> of the SkiaShape.</returns>
        protected abstract Geometry CreateDefiningGeometry();

        /// <summary>
        /// Invalidates the geometry of this SkiaShape.
        /// </summary>
        protected void InvalidateGeometry()
        {
            _renderedGeometry = null;
            _definingGeometry = null;

            InvalidateMeasure();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if (DefiningGeometry is null)
            {
                return default;
            }

            return CalculateSizeAndTransform(availableSize, DefiningGeometry.Bounds, Stretch).size;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (DefiningGeometry != null)
            {
                // This should probably use GetRenderBounds(strokeThickness) but then the calculations
                // will multiply the stroke thickness as well, which isn't correct.
                var (_, transform) = CalculateSizeAndTransform(finalSize, DefiningGeometry.Bounds, Stretch);

                if (_transform != transform)
                {
                    _transform = transform;
                    _renderedGeometry = null;
                }

                return finalSize;
            }

            return default;
        }

        internal static (Size size, Matrix transform) CalculateSizeAndTransform(Size availableSize, Rect shapeBounds, Stretch stretch)
        {
            Size shapeSize = new Size(shapeBounds.Right, shapeBounds.Bottom);
            Matrix translate = Matrix.Identity;
            double desiredX = availableSize.Width;
            double desiredY = availableSize.Height;
            double sx = 0.0;
            double sy = 0.0;

            if (stretch != Stretch.None)
            {
                shapeSize = shapeBounds.Size;
                translate = Matrix.CreateTranslation(-(Vector)shapeBounds.Position);
            }

            if (double.IsInfinity(availableSize.Width))
            {
                desiredX = shapeSize.Width;
            }

            if (double.IsInfinity(availableSize.Height))
            {
                desiredY = shapeSize.Height;
            }

            if (shapeBounds.Width > 0)
            {
                sx = desiredX / shapeSize.Width;
            }

            if (shapeBounds.Height > 0)
            {
                sy = desiredY / shapeSize.Height;
            }

            if (double.IsInfinity(availableSize.Width))
            {
                sx = sy;
            }

            if (double.IsInfinity(availableSize.Height))
            {
                sy = sx;
            }

            switch (stretch)
            {
                case Stretch.Uniform:
                    sx = sy = Math.Min(sx, sy);
                    break;
                case Stretch.UniformToFill:
                    sx = sy = Math.Max(sx, sy);
                    break;
                case Stretch.Fill:
                    if (double.IsInfinity(availableSize.Width))
                    {
                        sx = 1.0;
                    }

                    if (double.IsInfinity(availableSize.Height))
                    {
                        sy = 1.0;
                    }

                    break;
                default:
                    sx = sy = 1;
                    break;
            }

            var transform = translate * Matrix.CreateScale(sx, sy);
            var size = new Size(shapeSize.Width * sx, shapeSize.Height * sy);
            return (size, transform);
        }

        private static void AffectsGeometryInvalidate(SkiaShape control, AvaloniaPropertyChangedEventArgs e)
        {
            // If the geometry is invalidated when Bounds changes, only invalidate when the Size
            // portion changes.
            if (e.Property == BoundsProperty)
            {
                var oldBounds = (Rect)e.OldValue!;
                var newBounds = (Rect)e.NewValue!;

                if (oldBounds.Size == newBounds.Size)
                {
                    return;
                }
            }

            control.InvalidateGeometry();
        }
    }
}
