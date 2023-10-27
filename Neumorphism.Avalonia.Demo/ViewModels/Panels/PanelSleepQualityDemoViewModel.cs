using Avalonia.Themes.Neumorphism.Controls;

namespace Neumorphism.Avalonia.Demo.ViewModels.Panels
{
    public sealed class PanelSleepQualityDemoViewModel : ViewModelBase
    {
        #region properties

        private SleepQualityFrequency _frequency;
        public SleepQualityFrequency Frequency
        {
            get => _frequency;
            set
            {
                _frequency = value;
                OnPropertyChanged();
            }
        }

        #endregion



        public PanelSleepQualityDemoViewModel()
        {
            Frequency = SleepQualityFrequency.Days;
        }


        #region commands

        public void ButtonSettings()
        {
            SnackbarHost.Post("Clock settings not implemented !");
        }

        #endregion
    }



    public enum SleepQualityFrequency
    {
        Days = 1,
        Weeks = 2,
        Months = 3
    }

}