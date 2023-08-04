using Avalonia.Media;
using Avalonia.Rendering.SceneGraph;
using Avalonia.Platform;
using Avalonia.Skia;
using SkiaSharp;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public partial class SkiaShape
    {
        public abstract class CustomDrawOperation : ICustomDrawOperation
        {
            public static Rect ComputeBounds(Rect bounds, double blur, BoxShadows? shadows = null)
            {
                if (blur > 0)
                    bounds = bounds.Inflate(blur);

                if (shadows.HasValue)
                {
                    if (shadows is BoxShadows shad)
                    {
                        if (shadows.Value.Count > 0)
                        {
                            BoxShadow shadow = shadows.Value[0];

                            var offset = new Vector(shadow.OffsetX, shadow.OffsetY);
                            bounds = bounds.Union(bounds.Translate(offset).Inflate(shadow.Blur));
                        }
                    }
                }

                return bounds;
            }

            public CustomDrawOperation(Rect bounds, double blurRadius = 0, BoxShadows? shadows = null)
            {
                UnmodifiedBounds = bounds;
                Bounds = ComputeBounds(bounds, blurRadius, shadows);
                Blur = SkiaControl.BlurRadiusToSigma((float)blurRadius);
                Shadows = shadows;
                //ShadowBlur = SkiaControl.BlurRadiusToSigma((float)shadowBlurRadius);
            }

            protected virtual bool NeedsPaint()
            {
                return Opacity < 1 ||
                    Blur > 0 ||
                    ShadowAffectsRender ||
                    BlendModeAffectsRender ||
                    ColorFilter is not null;
            }

            protected bool BlendModeAffectsRender => BlendMode is not null && BlendMode != SKBlendMode.SrcOver;

            protected bool ShadowAffectsRender => Shadows is not null & Shadows.Value.Count > 0 && Shadows.Value[0].Color.A > 0;

            public float Opacity { get; set; } = 1;

            public float Blur { get; }

            public BoxShadows? Shadows { get; }

            public SKBlendMode? BlendMode { get; set; }

            public SKColorFilter ColorFilter { get; set; }

            public Rect UnmodifiedBounds { get; }

            public Rect Bounds { get; protected set; }

            public virtual void Dispose()
            {
                // No-op
            }

            public virtual bool Equals(ICustomDrawOperation other) => false;

            public virtual bool HitTest(Point p) => UnmodifiedBounds.Contains(p);

            protected virtual void RenderCore(SKCanvas canvas)
            {
            }

            public virtual void Render(ImmediateDrawingContext context)
            {
                var leaseFeature = context.TryGetFeature<ISkiaSharpApiLeaseFeature>();
                if (leaseFeature != null)
                {
                    using var lease = leaseFeature.Lease();
                    var canvas = lease.SkCanvas;
                    RenderCore(canvas);
                }
            }
        }
    }
}
