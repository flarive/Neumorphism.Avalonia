using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Themes.Neumorphism.Controls;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class TextBoxesDemoViewModel : ViewModelBase
    {
        private string _numerics;
        public string Numerics
        {
            get => _numerics;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && !Regex.IsMatch(value, @"^\d+([A-Za-z-+.']\d+)*$"))
                {
                    throw new DataValidationException("Invalid numerics");
                }

                _numerics = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(value);
                    if (!match.Success)
                    {
                        throw new DataValidationException("Invalid email");
                    }
                }

                _email = value;
                OnPropertyChanged();
            }
        }

        public void ButtonSearchClick(object sender)
        {
            var searchBox = sender as TextBox;
            if (searchBox != null)
            {
                if (!string.IsNullOrEmpty(searchBox.Text))
                {
                    SnackbarHost.Post("You are searching for '" + searchBox.Text + "' !");
                }
                else
                {
                    SnackbarHost.Post("Please enter something to search !");
                }
            }
        }
    }
}