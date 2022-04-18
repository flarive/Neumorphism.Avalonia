using System;
using System.Globalization;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using AvaloniaMedia=Avalonia.Media;
using Avalonia.Threading;

namespace Neumorphism.Avalonia.Styles.Controls
{
    public class Arc : Control
    {
        static Arc()
        {
            AffectsRender<Arc>(ArcBrushProperty,
                              StrokeProperty,
                              StartAngleProperty,
                              SweepAngleProperty);
        }

        public AvaloniaMedia.IBrush ArcBrush
        {
            get => GetValue(ArcBrushProperty);
            set => SetValue(ArcBrushProperty, value);
        }

        public readonly static StyledProperty<AvaloniaMedia.IBrush> ArcBrushProperty =
            AvaloniaProperty.Register<Arc, AvaloniaMedia.IBrush>(nameof(ArcBrush), new AvaloniaMedia.SolidColorBrush(AvaloniaMedia.Colors.White));



        //public double Stroke
        //{
        //    get => GetValue(StrokeProperty);
        //    set => SetValue(StrokeProperty, value);
        //}

        //public readonly static StyledProperty<double> StrokeProperty =
        //    AvaloniaProperty.Register<Arc, double>(nameof(Stroke));


        public double Stroke
        {
            get => GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        public readonly static StyledProperty<double> StrokeProperty =
            AvaloniaProperty.Register<Arc, double>(nameof(Stroke), 2.0);




        //public static AvaloniaProperty<double> StrokeProperty2 = AvaloniaProperty.RegisterAttached<Arc, double>(
        //    "Stroke2", typeof(Arc));

        //public static void SetStroke2(AvaloniaObject element, double value)
        //{
        //    element.SetValue(StrokeProperty2, value);
        //}

        //public static double GetStroke2(AvaloniaObject element)
        //{
        //    return (double)element.GetValue(StrokeProperty2);
        //}



        public double StartAngle
        {
            get => GetValue(StartAngleProperty);
            set => SetValue(StartAngleProperty, value);
        }

        public readonly static StyledProperty<double> StartAngleProperty =
            AvaloniaProperty.Register<Arc, double>(nameof(StartAngle));

        public double SweepAngle
        {
            get => GetValue(SweepAngleProperty);
            set => SetValue(SweepAngleProperty, value);
        }

        public static readonly StyledProperty<double> SweepAngleProperty =
            AvaloniaProperty.Register<Arc, double>(nameof(SweepAngle), 90);



        public override void Render(AvaloniaMedia.DrawingContext context)
        {
            var offsetStroke = 0.5;
            var o = Stroke + offsetStroke;

            if (Stroke > 4)
            {
                string aaa = null;
            }
            //double pp = GetStroke2(this);


            
            // Create main circle for draw circle
            var mainCircle =
                new AvaloniaMedia.EllipseGeometry(new Rect(o / 2, o / 2, Bounds.Width - o, Bounds.Height - o));

            var paint = new AvaloniaMedia.Pen(ArcBrush, Stroke);
            
            // Push generated clip geometry for clipping circle figure
            using (context.PushGeometryClip(GetClip()))
            {
                context.DrawGeometry(AvaloniaMedia.SolidColorBrush.Parse("Transparent"), paint, mainCircle);
            }

            Dispatcher.UIThread.InvokeAsync(InvalidateVisual, DispatcherPriority.Background);
        }

        // TODO: Optimal clip geometry generator
        // Clip geometry generator
        private AvaloniaMedia.StreamGeometry GetClip()
        {
            var offset = StartAngle - 90;
            
            var w = Bounds.Width;
            var h = Bounds.Height;
            
            var halfW = w / 2;
            var halfH = h / 2;

            var sweep = (offset + SweepAngle) / 360;
            
            var path = new StringBuilder($"M {halfW.ToString(CultureInfo.InvariantCulture)} {halfH.ToString(CultureInfo.InvariantCulture)}");
            
            int length = 24;
            
            for (int i = 0; i < length; i++)
            {
                var limit = offset / 360 + i / (double)length;
                
                if (limit > sweep)
                    break;
                
                var r2 = limit * (Math.PI * 2);
                var x2 = halfW + Math.Round(halfW * Math.Cos(r2), 4);
                var y2 = halfH + Math.Round(halfH * Math.Sin(r2), 4);
                
                path.Append($" {x2.ToString(CultureInfo.InvariantCulture)} {y2.ToString(CultureInfo.InvariantCulture)}");
            }
            
            var r3 = sweep * (Math.PI * 2);
            var x3 = halfW + Math.Round(halfW * Math.Cos(r3), 4);
            var y3 = halfH + Math.Round(halfH * Math.Sin(r3), 4);
            
            path.Append($" {x3.ToString(CultureInfo.InvariantCulture)} {y3.ToString(CultureInfo.InvariantCulture)}");

            path.Append(" Z");
            var result = path.ToString().Replace(',', '.');
            return AvaloniaMedia.StreamGeometry.Parse(result);
        }
    }
}