using Avalonia;
using Avalonia.Controls;
using Neumorphism.Avalonia.Demo.ViewModels;
using System.Timers;

namespace Neumorphism.Avalonia.Demo.Pages
{ 
    public partial class ProgressBarsDemo : UserControl
    { 
        private readonly Timer _timer1;
        private readonly Timer _timer2;
        private readonly Timer _timer3;
        private int _caseProgress1 = 0;
        private int _caseProgress2 = 0;
        private int _caseProgress3 = 60;

        private readonly ProgressBarsViewModel _context;

        
        

        public ProgressBarsDemo()
        {
            InitializeComponent();

            _timer1 = new Timer(100);
            _timer1.Elapsed += Timer1_Elapsed;

            _timer2 = new Timer(10);
            _timer2.Elapsed += Timer2_Elapsed;

            _timer3 = new Timer(500);
            _timer3.Elapsed += Timer3_Elapsed;


            _context = new ProgressBarsViewModel();

            DataContext = _context;

            AttachedToVisualTree += ProgressIndicatorDemo_AttachedToVisualTree;
            DetachedFromVisualTree += ProgressIndicatorDemo_DetachedFromVisualTree;
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

            _context.Progress1 = _caseProgress1;
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

            _context.Progress2 = _caseProgress2;
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

            _context.Progress3 = _caseProgress3;
        }
    }
}
