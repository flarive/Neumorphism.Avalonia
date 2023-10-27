using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public sealed class CircularProgress : ContentControl
    {
        private double _radius;

        public static readonly StyledProperty<IBrush> StrokeBrushProperty =
            AvaloniaProperty.Register<CircularProgress, IBrush>(nameof(StrokeBrush));

        public static readonly StyledProperty<int> StrokeThicknessProperty =
            AvaloniaProperty.Register<CircularProgress, int>(nameof(StrokeThickness), 5);

        public static readonly StyledProperty<double> ProgressValueProperty =
            AvaloniaProperty.Register<CircularProgress, double>(
                nameof(ProgressValue), 1);

        public static readonly StyledProperty<double> MinValueProperty =
            AvaloniaProperty.Register<CircularProgress, double>(
                nameof(MinValue), 0);

        public static readonly StyledProperty<double> MaxValueProperty =
            AvaloniaProperty.Register<CircularProgress, double>(
                nameof(MaxValue), 100);


        public static readonly StyledProperty<bool> IsIndeterminateProperty =
            AvaloniaProperty.Register<CircularProgress, bool>(
                nameof(IsIndeterminate), false);


        public static readonly StyledProperty<double> SweepAngleProperty =
            AvaloniaProperty.Register<CircularProgress, double>(
                nameof(SweepAngle), 0);


        public static readonly StyledProperty<PenLineCap> StrokeLineCapProperty =
            AvaloniaProperty.Register<CircularProgress, PenLineCap>(
                nameof(StrokeLineCap), 0);




        public IBrush StrokeBrush
        {
            get => GetValue(StrokeBrushProperty);
            set => SetValue(StrokeBrushProperty, value);
        }

        public int StrokeThickness
        {
            get => GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        public double MinValue
        {
            get => GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public double MaxValue
        {
            get => GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public double ProgressValue
        {
            get => GetValue(ProgressValueProperty);
            set => SetValue(ProgressValueProperty, value);
        }

        public bool IsIndeterminate
        {
            get => GetValue(IsIndeterminateProperty);
            set => SetValue(IsIndeterminateProperty, value);
        }

        public double SweepAngle
        {
            get => GetValue(SweepAngleProperty);
            set => SetValue(SweepAngleProperty, value);
        }

        public PenLineCap StrokeLineCap
        {
            get => GetValue(StrokeLineCapProperty);
            set => SetValue(StrokeLineCapProperty, value);
        }


        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == StrokeBrushProperty ||
                e.Property == StrokeThicknessProperty ||
                e.Property == ProgressValueProperty)
            {
                RenderArc();
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            _radius = availableSize.Height / 2;
            _radius -= StrokeThickness;
            RenderArc();
            return new Size(_radius * 2, _radius * 2);
        }

        private void RenderArc()
        {
            double percentage = ProgressValue / MaxValue;

            SweepAngle = percentage * 360;
        }
    }
}
