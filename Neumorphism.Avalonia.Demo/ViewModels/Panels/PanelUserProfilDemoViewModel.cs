using Avalonia.Themes.Neumorphism.Controls;

namespace Neumorphism.Avalonia.Demo.ViewModels.Panels
{
    public sealed class PanelUserProfilDemoViewModel : ViewModelBase
    {
        #region properties

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }


        private string _job;
        public string Job
        {
            get => _job;
            set
            {
                _job = value;
                OnPropertyChanged();
            }
        }



        private float _countLikes;
        public float CountLikes
        {
            get => _countLikes;
            set
            {
                _countLikes = value;
                OnPropertyChanged();
            }
        }

        private float _countComments;
        public float CountComments
        {
            get => _countComments;
            set
            {
                _countComments = value;
                OnPropertyChanged();
            }
        }

        private float _countFollowers;
        public float CountFollowers
        {
            get => _countFollowers;
            set
            {
                _countFollowers = value;
                OnPropertyChanged();
            }
        }

        #endregion



        public PanelUserProfilDemoViewModel()
        {

            Name = "CodingKiller";
            Job = "Designer & Developer";

            CountLikes = 20700 / 1000.0f;
            CountComments = 15200 / 1000.0f;
            CountFollowers = 156400 / 1000.0f;
        }


        #region commands


        public void GoToSocialNetworkCommand(int index)
        {
            SnackbarHost.Post("Go to social network not implemented !");
        }


        public void SendMessageCommand()
        {
            SnackbarHost.Post("Send message command not implemented !");
        }


        public void SubscribeCommand()
        {
            SnackbarHost.Post("Subscribe command not implemented !");
        }

        public void GoBackCommand(object sender)
        {
            SnackbarHost.Post("Go back command not implemented !");
        }

        public void SettingsCommand()
        {
            SnackbarHost.Post("Settings command not implemented !");
        }

        #endregion
    }
}