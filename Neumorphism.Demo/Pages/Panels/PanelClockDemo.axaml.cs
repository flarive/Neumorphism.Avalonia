using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Neumorphism.Avalonia.Demo.ViewModels.Panels;
using System.ComponentModel;
using System.Timers;

namespace Neumorphism.Avalonia.Demo.Pages.Panels
{
    public class PanelClockDemo : UserControl
    {
        //private Timer _timer1;
        //private int _caseProgress1 = 0;

        public PanelClockDemo()
        {
            this.InitializeComponent();

            //_timer1 = new Timer(100);
            //_timer1.Elapsed += Timer1_Elapsed;


            this.DataContext = new PanelClockDemoViewModel();

            //this.AttachedToVisualTree += ProgressIndicatorDemo_AttachedToVisualTree;
            //this.DetachedFromVisualTree += ProgressIndicatorDemo_DetachedFromVisualTree;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        //private void ProgressIndicatorDemo_AttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
        //{
        //    _timer1.Start();
        //}

        //private void ProgressIndicatorDemo_DetachedFromVisualTree(object sender, VisualTreeAttachmentEventArgs e)
        //{
        //    _timer1.Stop();
        //}

        //private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    if (_caseProgress1 < 100)
        //    {
        //        _caseProgress1++;
        //    }
        //    else
        //    {
        //        _caseProgress1 = 0;
        //    }

        //    Dispatcher.UIThread.InvokeAsync(delegate
        //    {
        //        if (this.DataContext is PanelClockDemoViewModel)
        //        {
        //            ((PanelClockDemoViewModel)this.DataContext).Progress1 = _caseProgress1;
        //        }
        //    });
        //}
    }
}