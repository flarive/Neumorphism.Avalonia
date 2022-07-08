using Avalonia.Controls.Primitives;
using Neumorphism.Avalonia.Styles;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public class ButtonFieldsViewModel : ViewModelBase
    {
        #region commands

        public static void ButtonClick() => SnackbarHost.Post("You have clicked on the button !");

        public static void ToggleButtonClick(object sender)
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