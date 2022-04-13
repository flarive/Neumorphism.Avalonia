using Neumorphism.Avalonia.Styles;

namespace Neumorphism.Demo.ViewModels
{
    public class ButtonFieldsViewModel : ViewModelBase
    {
        public static void ButtonClick() => SnackbarHost.Post("You have clicked on the button !");
    }   
}