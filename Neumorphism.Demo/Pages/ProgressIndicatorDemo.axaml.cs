using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.ComponentModel;
using System.Timers;

namespace Neumorphism.Avalonia.Demo.Pages
{
    public class ProgressIndicatorDemo : UserControl
    { 
        private Timer _timer1;
        private Timer _timer2;
        private Timer _timer3;
        private int _caseProgress1 = 0;
        private int _caseProgress2 = 0;
        private int _caseProgress3 = 60;

        private Context context;

        public class Context : INotifyPropertyChanged
        {
            private double _progress1= 0;
            public double Progress1
            {
                get => _progress1;
                set
                {
                    _progress1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress1)));
                }
            }

            private double _progress2 = 0;
            public double Progress2
            {
                get => _progress2;
                set
                {
                    _progress2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress2)));
                }
            }

            private double _progress3 = 0;
            public double Progress3
            {
                get => _progress3;
                set
                {
                    _progress3 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress3)));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

        

        public ProgressIndicatorDemo()
        {
            this.InitializeComponent();

            _timer1 = new Timer(100);
            _timer1.Elapsed += Timer1_Elapsed;

            _timer2 = new Timer(10);
            _timer2.Elapsed += Timer2_Elapsed;

            _timer3 = new Timer(500);
            _timer3.Elapsed += Timer3_Elapsed;



            this.DataContext = context = new Context();

            this.AttachedToVisualTree += ProgressIndicatorDemo_AttachedToVisualTree;
            this.DetachedFromVisualTree += ProgressIndicatorDemo_DetachedFromVisualTree;
        }

        private void ProgressIndicatorDemo_AttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
        {
            _timer1.Start();
            _timer2.Start();
            _timer3.Start();
        }

        private void ProgressIndicatorDemo_DetachedFromVisualTree(object sender, VisualTreeAttachmentEventArgs e)
        {
            _timer1.Stop();
            _timer2.Stop();
            _timer3.Stop();
        }

        private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_caseProgress1 < 100)
            {
                _caseProgress1++;
            }
            else
            {
                _caseProgress1 = 0;
            }

            context.Progress1 = _caseProgress1;
        }

        private void Timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_caseProgress2 < 100)
            {
                _caseProgress2++;
            }
            else
            {
                _caseProgress2 = 0;
            }

            context.Progress2 = _caseProgress2;
        }

        private void Timer3_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_caseProgress3 > 0)
            {
                _caseProgress3--;
            }
            else
            {
                _caseProgress3 = 60;
            }

            context.Progress3 = _caseProgress3;
        }




        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
