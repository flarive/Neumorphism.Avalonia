using Avalonia.Themes.Neumorphism.Controls;

namespace Neumorphism.Avalonia.Demo.ViewModels
{
    public sealed class ComboBoxesDemoViewModel : ViewModelBase
    {
        public void ButtonClick() => SnackbarHost.Post("You have clicked on the button !");
    }
}
