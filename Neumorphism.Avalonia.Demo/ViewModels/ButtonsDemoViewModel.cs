using Avalonia.Controls.Primitives;
using Avalonia.Themes.Neumorphism.Controls;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class ButtonsDemoViewModel : ViewModelBase
    {
        #region commands

        public void ButtonClick() => SnackbarHost.Post("You have clicked on the button !");

        public void ToggleButtonClick(object sender)
        {
            if (sender is ToggleButton)
            {
                bool toggled = ((ToggleButton)sender).IsChecked.HasValue ? ((ToggleButton)sender).IsChecked.Value : false;
                SnackbarHost.Post("You have switched " + (toggled ? "ON" : "OFF") + " the toggle button !");
            }
        }

        #endregion
    }   
}