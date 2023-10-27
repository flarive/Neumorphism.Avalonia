using Avalonia.Themes.Neumorphism.Controls;
using System.Timers;

namespace Neumorphism.Avalonia.Demo.ViewModels.Panels
{
    public sealed class PanelPlayerDemoViewModel : ViewModelBase
    {
        #region properties

        private bool _isPlaying = false;
        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                _isPlaying = value;
                OnPropertyChanged();
            }
        }

        #endregion



        public PanelPlayerDemoViewModel()
        {

        }


        #region commands

        public void PlayPauseSongCommand(object sender)
        {
            if (IsPlaying)
            {
                SnackbarHost.Post("Play song not implemented !");
            }
            else
            {
                SnackbarHost.Post("Pause song not implemented !");
            }
        }

        public void PlayPreviousSongCommand(object sender)
        {
            SnackbarHost.Post("Play previous song not implemented !");
        }

        public void PlayNextSongCommand(object sender)
        {
            SnackbarHost.Post("Play next song not implemented !");
        }

        public void GoBackCommand(object sender)
        {
            SnackbarHost.Post("Go back not implemented !");
        }

        public void AddToFavoritesCommand()
        {
            SnackbarHost.Post("Add to favorites not implemented !");
        }

        #endregion
    }
}