using Avalonia;
using Avalonia.Controls;
using Avalonia.Themes.Neumorphism.Controls;
using Avalonia.Themes.Neumorphism.Models;
using Neumorphism.Avalonia.Demo.Models;
using Neumorphism.Avalonia.Demo.Windows;
using System;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public class SnackbarsDemoViewModel : ViewModelBase
    {
        private readonly MainWindow _window;

        #region Properties

        private string _snackbarCloseResult1;
        public string SnackbarCloseResult1
        {
            get { return _snackbarCloseResult1; }
            set
            {
                _snackbarCloseResult1 = value;
                OnPropertyChanged(nameof(SnackbarCloseResult1));
            }
        }

        private string _snackbarCloseResult2;
        public string SnackbarCloseResult2
        {
            get { return _snackbarCloseResult2; }
            set
            {
                _snackbarCloseResult2 = value;
                OnPropertyChanged(nameof(SnackbarCloseResult2));
            }
        }

        #endregion


        #region Commands

        public void PostMessage1Command(string msg)
        {
            SnackbarHost.Post(msg);
        }

        public void PostMessage2Command(string msg)
        {
            SnackbarHost.Post(msg, 600, 120);
        }

        public void PostMessage3Command(string msg)
        {
            SnackbarHost.Post(msg, 600, 120, new TimeSpan(0,0,30));
        }

        public void PostMessage4Command(string msg)
        {
            SnackbarHost.Post(msg, 600, 130,
                        "OK, I GOT IT !",
                        new Action<object>((p) => OnWelcomeSnackbar1Closed("you closed it !")));
        }

        public void PostMessage5Command(string msg)
        {
            var model = new CustomSnackbarModel(msg, TimeSpan.Zero)
            {
                Width = 600,
                Height = 120,
                IsAnimated = true,
                Button = new SnackbarButtonModel() { Text = "OK, I GOT IT !", Action = new Action<object>((p) => OnWelcomeSnackbar2Closed("you closed it !")) }
            };

            SnackbarHost.Post(model);
        }

        public void PostMessage6Command(string msg)
        {
            var view = _window.Resources["CustomSnackbarTemplate"];

            var model = new CustomSnackbarModel(view, TimeSpan.Zero)
            {
                Width = 600,
                Height = 120,
                IsAnimated = true,
                Button = new SnackbarButtonModel() { Text = "OK, I GOT IT !", Action = new Action<object>((p) => OnWelcomeSnackbar2Closed("you closed it !")) }
            };

            SnackbarHost.Post(model);
        }

        #endregion



        public SnackbarsDemoViewModel(Window window)
        {
            _window = window as MainWindow;
        }



        private void OnWelcomeSnackbar1Closed(string msg)
        {
            SnackbarCloseResult1 = msg;
        }

        private void OnWelcomeSnackbar2Closed(string msg)
        {
            SnackbarCloseResult2 = msg;
        }
    }
}