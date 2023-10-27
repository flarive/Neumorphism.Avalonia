using Avalonia.Themes.Neumorphism.Controls;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class MenusDemoViewModel : ViewModelBase
    {
        public void MenuItemClickMethod()
        {
            SnackbarHost.Post("Subscribe command not implemented !");
        }

        #region commands

        public void ButtonClick() => SnackbarHost.Post("You have clicked on the button !");

        public void ToggleButtonClick(object sender)
        {
            SnackbarHost.Post("You have switched the toggle button !");
        }

        #endregion

    }
}