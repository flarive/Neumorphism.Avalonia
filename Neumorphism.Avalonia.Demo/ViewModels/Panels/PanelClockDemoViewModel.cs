using Avalonia.Themes.Neumorphism.Controls;
using System.Timers;

namespace Neumorphism.Avalonia.Demo.ViewModels.Panels
{
    public sealed class PanelClockDemoViewModel : ViewModelBase
    {
        private Timer _timer;
        private int _caseProgress = 0;

        #region properties

        private double _progress = 0;
        public double Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }

        private string _label = null;
        public string Label
        {
            get => _label;
            set
            {
                _label = value;
                OnPropertyChanged();
            }
        }

        #endregion



        public PanelClockDemoViewModel()
        {
            Label = "Start";
            Progress = 0;
        }


        #region commands

        public void ButtonStartStopStopwatch(object sender)
        {
            if (_timer == null)
            {
                // start
                Label = "Stop";

                _timer = new Timer(1000);
                _timer.Elapsed += Timer_Elapsed;

                _timer.Start();
            }
            else
            {
                // stop
                Label = "Start";

                _timer.Stop();

                _timer.Elapsed -= Timer_Elapsed;
                _timer = null;
            }
            
            
        }

        public void ButtonResetStopwatch(object sender)
        {
            if (_timer != null)
            {
                _timer.Stop();

                _timer.Elapsed -= Timer_Elapsed;
                _timer = null;
            }

            Progress = 0;
            _caseProgress = 0;
        }

        public void ButtonSettings()
        {
            SnackbarHost.Post("Clock settings not implemented !");
        }

        #endregion


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_caseProgress < 100)
            {
                _caseProgress++;
            }
            else
            {
                _caseProgress = 0;
            }

            Progress = _caseProgress;
        }
    }
}