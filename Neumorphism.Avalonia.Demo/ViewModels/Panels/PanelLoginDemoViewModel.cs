using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Controls;

namespace Neumorphism.Avalonia.Demo.ViewModels.Panels
{
    public sealed class PanelLoginDemoViewModel : ViewModelBase
    {

        #region properties

        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }


        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region commands

        public void ButtonLoginClick(object sender)
        {
            if (sender is Button)
            {
                if (string.IsNullOrEmpty(Login))
                {
                    SnackbarHost.Post("Please enter a login !");
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    SnackbarHost.Post("Please enter a password !");
                }
                else
                {
                    SnackbarHost.Post("You have signed in with login " + Login + " and password " + Password + " !");
                }
            }
        }

        #endregion
    }
}
