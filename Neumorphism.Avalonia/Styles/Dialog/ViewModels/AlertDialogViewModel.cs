using Neumorphism.Avalonia.Styles.Dialog.Views;

namespace Neumorphism.Avalonia.Styles.Dialog.ViewModels
{
    public class AlertDialogViewModel : DialogWindowViewModel
    {
        public AlertDialogViewModel(AlertDialog dialog)
        {
            _window = dialog;
        }
    }
}
